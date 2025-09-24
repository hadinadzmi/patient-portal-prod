using System.Net.Http.Json;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Patient_Portal.WebApi;
using PatientPortalBackend.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Patient_Portal.Core;

namespace Patient_Portal.Pages
{
    public partial class DocumentsPageView : McComponentBase
    {
        private List<PatientDocument> allDocuments = new();
        private List<PatientDocument> filteredDocuments = new();
        private long? selectedDocumentType = null;

        // Map document type values to display names and icons
        private readonly Dictionary<long, (string Name, string Icon)> documentTypes = new()
        {
            { 166, ("Discharge Summary", "/ICON/image-7.png") },
            { 131, ("Imaging Reports", "/ICON/image-9.png") },
            { 132, ("Lab Results", "/ICON/image-8.png") },
            { 137, ("Outstanding Bills", "/ICON/image-10.png") },
            // Allergies can be added if you know its DocumentType value
        };

        [Inject]
        private IJSRuntime JSRuntime { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await CheckAllowed(LocalStorage);

            if (!IsAllowed)
            {
                await Task.Delay(3000);
                NavigationManager.NavigateTo("/", false, true);
                return;
            }

            await LoadAllDocuments();
        }

        private async Task LoadAllDocuments()
        {
            SetBusy(true);

            var request = new ServiceMedimaxGetPatientDocumentsRequest
            {
                PatientId = GlobalData.PatientId
            };

            var prx = new ServiceProxy(this);
            var response = await prx.CallWebApi<ServiceMedimaxGetPatientDocumentsResponse, ServiceMedimaxGetPatientDocumentsRequest>(
                _httpClient, request, ServiceUris.GetPatientDocumentsUri);

            if (response != null && response.Success)
            {
                allDocuments = response.DocumentList ?? new List<PatientDocument>();
            }
            else
            {
                allDocuments = new List<PatientDocument>();
            }

            SetBusy(false);
        }

        private void ShowDocumentsByType(long documentType)
        {
            selectedDocumentType = documentType;
            filteredDocuments = allDocuments
                .Where(d => d.DocumentType == documentType)
                .ToList();
        }

        private void BackToTypeSelection()
        {
            selectedDocumentType = null;
            filteredDocuments.Clear();
        }

        private async Task DownloadDocument(PatientDocument doc)
        {
            SetBusy(true);

            var request = new ServiceMedimaxDownloadPatientDocumentRequest
            {
                DocumentId = doc.DocumentId,
                Version = doc.Version,
                DocumentKey = doc.DocumentKey,
                IsDocumentInfoRecordAttached = true,
                DocumentPassword = null
            };

            var prx = new ServiceProxy(this);
            var response = await prx.CallWebApi<ServiceMedimaxDownloadPatientDocumentResponse, ServiceMedimaxDownloadPatientDocumentRequest>(
                _httpClient, request, ServiceUris.DownloadPatientDocumentsUri);

            if (response != null && response.Success && response.DocumentContent != null)
            {
                await JSRuntime.InvokeVoidAsync(
                    "blazorDownloadFile",
                    response.FileName ?? doc.Name ?? "document",
                    response.MimeType ?? "application/octet-stream",
                    Convert.ToBase64String(response.DocumentContent)
                );
            }

            SetBusy(false);
        }

        private PatientDocument? documentToView = null;
        private byte[]? documentContentToView = null;
        private bool showDocumentModal = false;

        private async Task ViewDocument(PatientDocument doc)
        {
            SetBusy(true);

            var request = new ServiceMedimaxDownloadPatientDocumentRequest
            {
                DocumentId = doc.DocumentId,
                Version = doc.Version,
                DocumentKey = doc.DocumentKey,
                IsDocumentInfoRecordAttached = true,
                DocumentPassword = null
            };

            var prx = new ServiceProxy(this);
            var response = await prx.CallWebApi<ServiceMedimaxDownloadPatientDocumentResponse, ServiceMedimaxDownloadPatientDocumentRequest>(
                _httpClient, request, ServiceUris.DownloadPatientDocumentsUri);

            if (response != null && response.Success && response.DocumentContent != null)
            {
                documentToView = doc;
                documentContentToView = response.DocumentContent;
                showDocumentModal = true;
                StateHasChanged();
            }

            SetBusy(false);
        }

        private string searchText = string.Empty;

        private bool sortDateAsc = false; // Default: New to Old

        private IEnumerable<PatientDocument> GetFilteredDocuments()
        {
            IEnumerable<PatientDocument> docs = filteredDocuments;

            // Filter
            if (!string.IsNullOrWhiteSpace(searchText))
            {
                var lower = searchText.Trim().ToLowerInvariant();
                docs = docs.Where(d =>
                    (!string.IsNullOrEmpty(d.Name) && d.Name.ToLowerInvariant().Contains(lower)) ||
                    (!string.IsNullOrEmpty(d.DateTimeCreatedStr) && d.DateTimeCreatedStr.ToLowerInvariant().Contains(lower))
                );
            }

            // Sort by date
            docs = sortDateAsc
                ? docs.OrderBy(d => ParseDate(d.DateTimeCreatedStr))
                : docs.OrderByDescending(d => ParseDate(d.DateTimeCreatedStr));

            return docs;
        }

        // Helper to parse the date string
        private DateTime ParseDate(string dateStr)
        {
            if (DateTime.TryParse(dateStr, out var dt))
                return dt;
            return DateTime.MinValue;
        }

        private void ToggleDateSort()
        {
            sortDateAsc = !sortDateAsc;
        }
    }
}
