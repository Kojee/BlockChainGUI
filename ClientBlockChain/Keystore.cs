using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ClientBlockChain
{
    public class Keystore : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string mAddress;
        private bool mStatus;
        private double mBalance;
        public bool Status
        {
            get
            {
                return mStatus;
            }
            set
            {
                if (value != mStatus)
                {
                    mStatus = value;
                }
            }
        }

        public double Balance
        {
            get
            {
                return mBalance;
            }
            set
            {
                mBalance = value;
                NotifyPropertyChanged("Balance");
            }
        }
        public string Address
        {
            get
            {
                return mAddress;
            }
            set
            {
                if (value != mAddress)
                {
                    mAddress = value;
                    NotifyPropertyChanged("Address");
                }
            }
        }

        public Keystore(string address)
        {
            this.Address = address;
            this.Status = true;
        }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
