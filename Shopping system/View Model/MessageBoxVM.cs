using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Shopping_system.View_Model
{
    public class MessageBoxVM : BaseVM, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _message { get; set; }
        private string _icon { get; set; }
        private string _header { get; set; }
        private Brush _backGround { get; set; }
        private Brush _foreground { get; set; }
        private MessageType _messageType { get; set; }

        public MessageBoxVM(string message, MessageType messageType)
        {
            //PropertyChanged = new PropertyChangedEventHandler(this);
            Message = message;
            MessageType = messageType;
            switch (messageType)
            {
                case MessageType.Info:
                    {
                        Header = "Information";
                        BackGround = (Brush)new BrushConverter().ConvertFrom("#BDE5F8");
                        Foreground = (Brush)new BrushConverter().ConvertFrom("#00529B");
                        break;
                    }

                case MessageType.Success:
                    {
                        Header = "Success";
                        BackGround = (Brush)new BrushConverter().ConvertFrom("#DFF2BF");
                        Foreground = (Brush)new BrushConverter().ConvertFrom("#4F8A10");
                        break;
                    }

                case MessageType.Error:
                    {
                        Header = "Error";
                        BackGround = (Brush)new BrushConverter().ConvertFrom("#FFD2D2");
                        Foreground = (Brush)new BrushConverter().ConvertFrom("#D8000C");
                        break;
                    }
            }
        }

        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;
                //PropertyChanged(this, new PropertyChangedEventArgs("_message"));
            }
        }

        public string Icon
        {
            get { return _icon; }
            set
            {
                _icon = value;
                //PropertyChanged(this, new PropertyChangedEventArgs("_icon"));
            }
        }

        public string Header
        {
            get { return _header; }
            set
            {
                _header = value;
                //PropertyChanged(this, new PropertyChangedEventArgs("_header"));
            }
        }

        public Brush BackGround
        {
            get { return _backGround; }
            set
            {
                _backGround = value;
                //PropertyChanged(this, new PropertyChangedEventArgs("_backGround"));
            }
        }

        public Brush Foreground
        {
            get { return _foreground; }
            set
            {
                _foreground = value;
                //PropertyChanged(this, new PropertyChangedEventArgs("_foreground"));
            }
        }

        public MessageType MessageType
        {
            get { return _messageType; }
            set
            {
                _messageType = value;
                //PropertyChanged(this, new PropertyChangedEventArgs("_messageType"));
            }
        }
    }

    public enum MessageType
    {
        Info,
        Success,
        Error,
    }

}
