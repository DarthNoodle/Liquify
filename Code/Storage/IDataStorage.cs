using System.Collections.Concurrent;

namespace Liquify.Code.Storage
{
    public interface IDataStorage
    {
        public CoinStorage CoinStore { get; }
        public CoinLPStorage CoinLPStore { get; }
    }
}
