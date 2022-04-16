using System.ComponentModel;
using System.Numerics;

namespace Liquify.Code.Models
{
    public class CoinLP : BaseStore
    {
        [DisplayName("Symbol")]
        public string Symbol { get; set; }

        [DisplayName("Chain")]
        public ChainEnum Chain { get; set; }

        [DisplayName("IsStable")]
        public bool IsStable { get; set; }

        [DisplayName("Name")]
        public string Name { get; set; }

        [DisplayName("LP Address")]
        public string Address { get; set; }

        [DisplayName("Coin 0 Address")]
        public string Coin0Address { get; set; }

        [DisplayName("Coin 0")]
        public string Coin0Symbol { get; set; }

        [DisplayName("Coin 1 Address")]
        public string Coin1Address { get; set; }

        [DisplayName("Coin 1")]
        public string Coin1Symbol { get; set; }

        [DisplayName("Whitelisted")]
        public bool isWhitelisted { get; set; }

        [DisplayName("Weight")]
        public ulong Weight { get; set; }
    }
}
