﻿using System.Net;
using Risen.Shared.Tcp;

namespace Risen.Client.Tcp
{
    public interface IClientConfiguration : IConfiguration
    {
        int MaxNumberOfConnections { get; }
        int MaxConnectOperations { get; }
        int NumberOfSaeaForRecSend { get; }
        int BufferSize { get; set; }
        bool ContinuallyRetryConnectIfSocketError { get; }
        int ReceivePrefixLength { get; set; }
        int NumberOfMessagesPerConnection { get; set; }
    }

    public class ClientConfiguration : IClientConfiguration
    {
        public ClientConfiguration()
        {
            Init();
        }

        public bool ContinuallyRetryConnectIfSocketError { get; private set; }
        public int NumberOfMessagesPerConnection { get; set; }
        public int MaxNumberOfConnections { get; private set; }
        public int Port { get; private set; }
        public int BufferSize { get; set; }
        public int MaxConnectOperations { get; set; }
        public int Backlog { get; private set; }
        public int OperationsToPreallocate { get; private set; }
        public int ExcessSaeaObjectsInPool { get; private set; }
        public int ReceivePrefixLength { get; set; }
        public int SendPrefixLength { get; private set; }
        public int MainTransmissionId { get; private set; }
        public int StartingId { get; private set; }
        public int NumberOfSaeaForRecSend { get; private set; }
        public IPEndPoint LocalEndPoint { get; set; }

        private void Init()
        {
            ContinuallyRetryConnectIfSocketError = true;
            MaxNumberOfConnections = 5;
            Port = 4444;
            BufferSize = 100;
            MaxConnectOperations = 5;
            Backlog = 10;
            OperationsToPreallocate = 2;
            ExcessSaeaObjectsInPool = 1;
            ReceivePrefixLength = 4;
            SendPrefixLength = 4;
            MainTransmissionId = 100;
            StartingId = 0;
            
            NumberOfSaeaForRecSend = MaxNumberOfConnections + ExcessSaeaObjectsInPool;
            LocalEndPoint = new IPEndPoint(IPAddress.Any, Port);
        }

        public int GetTotalBytesRequiredForInitialBufferConfiguration()
        {
            return BufferSize * NumberOfSaeaForRecSend * OperationsToPreallocate;
        }

        public int GetTotalBufferSize()
        {
            return BufferSize * OperationsToPreallocate;
        }
    }
}