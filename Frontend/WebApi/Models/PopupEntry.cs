namespace Patient_Portal.WebApi.Models
{
    public class PopupEntry
    {
        public string PopupKey { get; set; } // Unique identifier for the popup
        public int SortOrder { get; set; } // Sort order of the popup
        public int PopupEntryCode { get; set; } // Code for the popup entry
        public string Text { get; set; } // Text for the popup entry
        public long PkID { get; set; } // Unique identifier for the popup entry
        public long TenantId { get; set; } // Tenant identifier for multi-tenant systems
    }
}