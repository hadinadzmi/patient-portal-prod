using System.Text;
using Blazored.Modal;
using Blazored.Modal.Services;
using Patient_Portal.Core;

namespace Patient_Portal.MessageBox
{
    public static class MessageBoxHandler
    {
        private static ModalOptions GetDefaultOptions()
        {
            var options = new ModalOptions()
                { DisableBackgroundCancel = true, Position = ModalPosition.TopCenter, HideCloseButton = true, HideHeader = true, Class = "blazored-modalMessagebox" };
            return options;
        }

        private static ModalParameters GetParameters(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, object callingObject = null)
        {
            var parameters = new ModalParameters();
            parameters.Add("DialogTitle", caption);
            parameters.Add("Text", text);
            parameters.Add("Buttons", buttons);
            parameters.Add("Icon", icon);
            return parameters;
        }

        public static async Task<MessageBoxResult> ShowMsg(IModalService modal, string message,
            string caption = "", MessageBoxButtons button = MessageBoxButtons.Ok,
            MessageBoxIcon icon = MessageBoxIcon.Information, object callingObject = null)
        {
            return await ShowMsg(modal, new List<string> { message }, caption, button, icon, callingObject);
        }

        public static async Task<MessageBoxResult> ShowMsg(IModalService modal, List<string> listOfMessages, string caption = "", MessageBoxButtons button = MessageBoxButtons.Ok, MessageBoxIcon icon = MessageBoxIcon.Information, object callingObject = null)
        {
            if (listOfMessages == null)
                return new MessageBoxResult();

            var msg = GetMessageBoxText(listOfMessages, callingObject);

            var parameters = GetParameters(msg, caption, button, icon);
            var options = GetDefaultOptions();
            var msgBox = modal.Show<McMessageBox>(null, parameters, options);
            var msgBoxResult = await msgBox.Result;
            return (MessageBoxResult)msgBoxResult.Data;
        }

        public static async Task<MessageBoxResult> ShowError(IModalService modal, string title, List<string> messageBoxTextList)
        {
            return await ShowMsg(modal, messageBoxTextList, title, MessageBoxButtons.Ok, MessageBoxIcon.Error);
        }

        public static async Task<MessageBoxResult> ShowError(IModalService modal, string title, string messageBoxText)
        {
            return await ShowMsg(modal, new List<string> { messageBoxText }, title, MessageBoxButtons.Ok, MessageBoxIcon.Error);
        }

        private static String GetMessageBoxText(List<string> listOfMessages, object callingObject)
        {
            var messageBoxText = new StringBuilder();
            listOfMessages.ForEach(messageLine => messageBoxText.Append(messageLine).Append(Environment.NewLine));
            return messageBoxText.ToString();
        }
    }
}
