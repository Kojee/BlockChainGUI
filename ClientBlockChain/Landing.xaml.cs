using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Logica di interazione per Landing.xaml
    /// </summary>
    public partial class Landing : Page
    {
        private NetNamedPipeBinding mBinding;
        private EndpointAddress mEp;
        private IWCF mChannel;
        private string mAddress = "net.pipe://localhost/WCFServices";

        public Keystore Keystore
        {
            get; set;
        }

        public Window window;

        public Landing(Window window)
        {
            InitializeComponent();
            mBinding = new NetNamedPipeBinding(NetNamedPipeSecurityMode.None);
            mEp = new EndpointAddress(mAddress);
            mChannel = ChannelFactory<IWCF>.CreateChannel(mBinding, mEp);
            this.Keystore = new Keystore("No address loaded");
            this.DataContext = Keystore;
            this.window = window;
            this.DataContext = this;
        }

        private void Button_Load_Click(object sender, RoutedEventArgs e)
        {
            string[] exCommand = new string[2];
            exCommand[0] = "marco1";
            exCommand[1] = "password";
            mChannel.LoadKeyStore(exCommand[0], exCommand[1]);
            string address = mChannel.GetKeystore();
            this.Keystore.Address = address;
            this.Keystore.Balance = mChannel.GetBalance();
            window.Content = new Logged(this.window, Keystore);

        }

        private void Button_Create_Click(object sender, RoutedEventArgs e)
        {
            string[] exCommand = new string[2];
            exCommand[0] = "marco1";
            exCommand[1] = "password";
            mChannel.GenerateKeyStore(exCommand[0], exCommand[1]);
            string address = mChannel.GetKeystore();
            this.Keystore.Address = address;
            this.Keystore.Balance = mChannel.GetBalance();
            window.Content = new Logged(this.window, Keystore);
        }
    }
}
