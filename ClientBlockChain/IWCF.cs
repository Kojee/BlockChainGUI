﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ClientBlockChain
{
    /// <summary>
    /// Interfaccia per le comunicazioni interprocessuali
    /// </summary>
    /// Implementazione a https://github.com/Quantum1248/BlockChain2/blob/WCF/BlockChain/BlockChain/Services.cs 
    [ServiceContract]
    interface IWCF
    {
        /// <summary>
        /// Carica in memoria i parametri RSA del dato keystore
        /// </summary>
        /// <param name="name">Il nome del keystore</param>
        /// <param name="password">La password per sbloccarlo</param>
        [OperationContract]
        void LoadKeyStore(string name, string password);

        /// <summary>
        /// Crea un nuovo keystore con il nome e la password specificata
        /// </summary>
        /// <param name="name">Il nome del keystore</param>
        /// <param name="password">La password per sbloccarlo</param>
        [OperationContract]
        void GenerateKeyStore(string name, string password);

        /// <summary>
        /// Ritorna il keystore correntemente caricato in memoria
        /// </summary>
        /// <returns>Address del keystore caricato</returns>
        /// Attualmente ritorna solo l'address, più avanti sarebbe opportuno definire un oggetto Keystore 
        /// per ritornare più proprietà in formato JSON
        [OperationContract]
        string GetKeystore();

        /// <summary>
        /// Ritorna il conto del keystore caricato
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        double GetBalance();
    }
}
