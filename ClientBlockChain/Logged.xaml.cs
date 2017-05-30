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
    /// Logica di interazione per Logged.xaml
    /// </summary>
    /// 

    public partial class Logged : Page
    {
        [DllImport("Kernel32")]
        public static extern void AllocConsole();

        [DllImport("Kernel32")]
        public static extern void FreeConsole();
        private NetNamedPipeBinding mBinding;
        private EndpointAddress mEp;
        private IWCF mChannel;
        private string mAddress = "net.pipe://localhost/WCFServices";
        public Window window;
        
        public Keystore Keystore
        {
            get;
            set;
        }
        

        public Logged(Window window, Keystore keystore)
        {
            InitializeComponent();
            mBinding = new NetNamedPipeBinding(NetNamedPipeSecurityMode.None);
            mEp = new EndpointAddress(mAddress);
            mChannel = ChannelFactory<IWCF>.CreateChannel(mBinding, mEp);
            Console.WriteLine("Client Connected");
            this.Keystore = keystore;
            this.DataContext = this;
            this.window = window;
        }


        private void Button_SendTransaction_Click(object sender, RoutedEventArgs e)
        {
            string address, amountString;
            address = Address.Text;
            amountString = Amount.Text;
            double amount = Convert.ToDouble(amountString);
            mChannel.SendTransaction(address, amount);
        }

        private void Button_StartMining_Click(object sender, RoutedEventArgs e)
        {
            
            mChannel.StartMining();
        }
    }
}
