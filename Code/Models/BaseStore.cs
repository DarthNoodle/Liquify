using Nethereum.Hex.HexTypes;
using System.Numerics;

namespace Liquify.Code.Models
{
    public abstract class BaseStore
    {
        public HexBigInteger BlockHeight { get; set; }
    }
}
