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
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        [DllImport("Kernel32")]
        public static extern void AllocConsole();

        [DllImport("Kernel32")]
        public static extern void FreeConsole();
        private NetNamedPipeBinding mBinding;
        private EndpointAddress mEp;
        private IWCF mChannel;
        private string mAddress = "net.pipe://localhost/gorillacoding/IPCTest";

        public MainWindow()
        {
            InitializeComponent();
            mBinding = new NetNamedPipeBinding(NetNamedPipeSecurityMode.None);
            mEp = new EndpointAddress(mAddress);
            mChannel = ChannelFactory<IWCF>.CreateChannel(mBinding, mEp);
            AllocConsole();
            Console.WriteLine("Client Connected");
        }

        private void Button_Load_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Insert [name] [password]");
            string command = Console.ReadLine();
            string[] exCommand = command.Split(' ');
            mChannel.LoadKeyStore(exCommand[0], exCommand[1]);
        }

        private void Button_Create_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Insert [name] [password]");
            string command = Console.ReadLine();
            string[] exCommand = command.Split(' ');
            mChannel.GenerateKeyStore(exCommand[0], exCommand[1]);
        }
    }
}
