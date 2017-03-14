using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ClientBlockChain
{
    [ServiceContract]
    interface IWCF
    {
        [OperationContract]
        void LoadKeyStore(string name, string password);
        [OperationContract]
        void GenerateKeyStore(string name, string password);
        
    }
}
