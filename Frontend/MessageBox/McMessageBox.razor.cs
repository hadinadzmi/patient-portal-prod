using Blazored.Modal;
using Blazored.Modal.Services;
using Microsoft.AspNetCore.Components;
using Patient_Portal.Core;

namespace Patient_Portal.MessageBox
{
    public enum MessageBoxResult
    {
        Cancel = 2,
        No = 7,
        None = 0,
        OK = 1,
        Yes = 6
    }

    public enum MessageBoxButtons
    {
        Ok, YesNo, YesNoCancel, OkCancel
    }

    public enum MessageBoxIcon
    {
        Question, Information, Error, None, Warning
    }

    public partial class McMessageBox
    {
        private const string IMG_ERROR = "/images/MessageError.png";
        private const string IMG_QUESTION = "/images/MessageQuestion.png";
        private const string IMG_WARNING = "/images/MessageWarning.png";
        private const string IMG_INFO = "/images/MessageInfo.png";

        [CascadingParameter] 
        BlazoredModalInstance BlazoredModal { get; set; }

        [Parameter]
        public string DialogTitle { get; set; }
        [Parameter]
        public string Text { get; set; }

        [Parameter]
        public MessageBoxButtons Buttons { get; set; }

        [Parameter] 
        public MessageBoxIcon Icon { get; set; }

        [Parameter] 
        public string Class { get; set; }

        public string IconName
        {
            get
            {
                switch (Icon)
                {
                    case MessageBoxIcon.Error:
                        return IMG_ERROR;
                    case MessageBoxIcon.Question:
                        return IMG_QUESTION;
                    case MessageBoxIcon.Warning:
                        return IMG_WARNING;
                    default:   // MessageBoxIcon.Information
                        return IMG_INFO;
                }
            }
        }

        public MessageBoxResult Result { get; set; }

        private async void BtnOk_OnClick()
        {
            await BlazoredModal.CloseAsync(ModalResult.Ok(MessageBoxResult.OK));
        }

        private async void BtnYes_OnClick()
        {
            await BlazoredModal.CloseAsync(ModalResult.Ok(MessageBoxResult.Yes));
        }

        private async void BtnNo_OnClick()
        {
            await BlazoredModal.CloseAsync(ModalResult.Ok(MessageBoxResult.No));
        }

        private async void BtnCancel_OnClick()
        {
            await BlazoredModal.CloseAsync(ModalResult.Ok(MessageBoxResult.Cancel));
        }
    }
}
