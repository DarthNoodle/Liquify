using System;

namespace Liquify.Code.Util
{
    public class AccountStateContainer
    {

        private bool? _HasMetaMask;
        private bool? _IsConnected;
        private string _Address;

        public string Address { 
            get { return _Address ?? string.Empty; } 
            set {
                _Address = value;
                NotifyStateChanged();
            }
        }//public string Address { 


        public bool IsConnected
        {
            get { return _IsConnected ?? false; }
            set
            {
                _IsConnected = value;
                NotifyStateChanged();
            }
        }//public string IsConnected

        public bool HasMetaMask
        {
            get { return _HasMetaMask ?? false; }
            set
            {
                _HasMetaMask = value;
                NotifyStateChanged();
            }
        }//public string IsConnected

        public event Action OnChange;
        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
