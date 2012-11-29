﻿using Risen.Server.Tcp.Tokens;
using StructureMap;

namespace Risen.Server.Tcp.Factories
{
    public interface IAcceptOperationUserTokenFactory
    {
        IAcceptOperationUserToken GenerateAcceptOperationUserToken(int tokenId);
    }

    public class AcceptOperationUserTokenFactory : IAcceptOperationUserTokenFactory
    {
        public IAcceptOperationUserToken GenerateAcceptOperationUserToken(int tokenId)
        {
            var token = ObjectFactory.GetInstance<IAcceptOperationUserToken>();
            token.TokenId = tokenId;

            return token;
        }
    }
}