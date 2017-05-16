using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ClientBlockChain
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private NetNamedPipeBinding mBinding;
        private EndpointAddress mEp;
        private IWCF mChannel;
        private string mAddress = "net.pipe://localhost/WCFServices";
        public Keystore Keystore
        {
            get;set;
        }

        

        public MainWindow()
        {
            InitializeComponent();
            //Connessione al canale WCF con il processo "Backend"
            mBinding = new NetNamedPipeBinding(NetNamedPipeSecurityMode.None);
            mEp = new EndpointAddress(mAddress);
            mChannel = ChannelFactory<IWCF>.CreateChannel(mBinding, mEp);
            this.Keystore = new Keystore("Non caricato");
            
            this.DataContext = this;
        }

        private void Keystore_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            
        }

        private void Button_Load_Click(object sender, RoutedEventArgs e)
        {
            string[] exCommand = new string[2];
            exCommand[0] = "marco";
            exCommand[1] = "password";
            mChannel.LoadKeyStore(exCommand[0], exCommand[1]);
            string address = mChannel.GetKeystore();
            this.Keystore.Address = address;
            this.Keystore.Balance = mChannel.GetBalance();
        }

        private void Button_Create_Click(object sender, RoutedEventArgs e)
        {
            string[] exCommand = new string[2];
            exCommand[0] = "marco";
            exCommand[1] = "password";
            mChannel.GenerateKeyStore(exCommand[0], exCommand[1]);
            string address = mChannel.GetKeystore();
            this.Keystore.Address = address;
            this.Keystore.Balance = mChannel.GetBalance();
        }

       
    }
}
