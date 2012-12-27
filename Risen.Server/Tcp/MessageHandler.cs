﻿using System;
using System.Net.Sockets;
using Risen.Server.Msmq;
using Risen.Server.Tcp.Tokens;

namespace Risen.Server.Tcp
{
    public interface IMessageHandler
    {
        bool HandleMessage(SocketAsyncEventArgs receiveSendEventArgs, DataHoldingUserToken dataHoldingUserToken, int remainingBytesToProcess);
    }

    public class MessageHandler : IMessageHandler
    {
        private readonly ILogger _logger;

        public MessageHandler(ILogger logger)
        {
            _logger = logger;
        }

        public bool HandleMessage(SocketAsyncEventArgs receiveSendEventArgs, DataHoldingUserToken dataHoldingUserToken, int remainingBytesToProcess)
        {
            var incomingTcpMessageIsReady = false;

            // Create the array where we'll store the complete message, if it has not been created on a previous receive op.
            if (dataHoldingUserToken.ReceivedMessageBytesDoneCount == 0)
            {
                _logger.QueueMessage(LogCategory.TcpServer, LogSeverity.Debug,
                                     string.Format("MessageHandler: Creating Receive Array on Id: {0}", dataHoldingUserToken.TokenId));

                dataHoldingUserToken.DataHolder.DataMessageReceived = new Byte[dataHoldingUserToken.LengthOfCurrentIncomingMessage];
            }

            // Remember there is a dataHoldingUserToken.receivedPrefixBytesDoneCount
            // variable, which allowed us to handle the prefix even when it
            // requires multiple receive ops. In the same way, we have a
            // dataHoldingUserToken.ReceivedMessageBytesDoneCount variable, which
            // helps us handle message data, whether it requires one receive operation or many.
            if (remainingBytesToProcess + dataHoldingUserToken.ReceivedMessageBytesDoneCount == dataHoldingUserToken.LengthOfCurrentIncomingMessage)
            {
                // If we are inside this if-statement, then we got
                // the end of the message. In other words,
                // the total number of bytes we received for this message matched the
                // message length value that we got from the prefix.

                // Write/append the bytes received to the byte array in the
                // DataHolder object that we are using to store our data.
                Buffer.BlockCopy(receiveSendEventArgs.Buffer,
                                 dataHoldingUserToken.ReceiveMessageOffset,
                                 dataHoldingUserToken.DataHolder.DataMessageReceived,
                                 dataHoldingUserToken.ReceivedMessageBytesDoneCount,
                                 remainingBytesToProcess);

                incomingTcpMessageIsReady = true;
            }
            else
            {
                // If we are inside this else-statement, then that means that we need another receive op. We still haven't got the whole message,
                // even though we have examined all the data that was received. Not a problem. In SocketListener.ProcessReceive we will just call
                // StartReceive to do another receive op to receive more data.
                Buffer.BlockCopy(receiveSendEventArgs.Buffer,
                                 dataHoldingUserToken.ReceiveMessageOffset,
                                 dataHoldingUserToken.DataHolder.DataMessageReceived,
                                 dataHoldingUserToken.ReceivedMessageBytesDoneCount,
                                 remainingBytesToProcess);

                dataHoldingUserToken.ReceiveMessageOffset = dataHoldingUserToken.ReceiveMessageOffset - dataHoldingUserToken.RecPrefixBytesDoneThisOperation;
                dataHoldingUserToken.ReceivedMessageBytesDoneCount += remainingBytesToProcess;
            }

            return incomingTcpMessageIsReady;
        }
    }
}