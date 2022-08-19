using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayRoll.Core.Model
{
    public enum MessageTypes
    {
        None = 0,
        Success = 1,
        Error = 2,
        Warning = 3,
        Information = 4
    }
    public class Message
    {
        public string ReturnMessage { get; set; }
        public MessageTypes MessageType { get; set; }
        public List<string> MessageList { get; set; }
        public string RedirectUrl { get; set; }

        public Message()
        {
            ReturnMessage = string.Empty;
            MessageType = MessageTypes.None;
            MessageList = new List<string>();
            RedirectUrl = string.Empty;
        }

        public class SetMessages
        {
            public static string CommenSaveMessage = "Data has been saved";
            public static string CommenDeleteMessage = "Data has been deleted";
            public static string CommenErrorMessage = "An error occured";

            public static Message SetSuccessMessage(string message, List<string> lst = null)
            {
                var ret = new Message();
                ret.ReturnMessage = message;
                ret.MessageType = MessageTypes.Success;

                if (lst != null)
                {
                    ret.MessageList = lst;
                }

                return ret;
            }

            public static Message SetErrorMessage(string message, List<string> lst = null)
            {
                var ret = new Message();
                ret.ReturnMessage = message;
                ret.MessageType = MessageTypes.Error;

                if (lst != null)
                {
                    ret.MessageList = lst;
                }

                return ret;
            }

            public static Message SetWarningMessage(string message, List<string> lst = null)
            {
                var ret = new Message();
                ret.ReturnMessage = message;
                ret.MessageType = MessageTypes.Warning;

                if (lst != null)
                {
                    ret.MessageList = lst;
                }

                return ret;
            }

            public static Message SetInformationMessage(string message, List<string> lst = null)
            {
                var ret = new Message();
                ret.ReturnMessage = message;
                ret.MessageType = MessageTypes.Information;

                if (lst != null)
                {
                    ret.MessageList = lst;
                }

                return ret;
            }
        }
    }
}
