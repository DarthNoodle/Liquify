namespace Liquify.Code.Models
{


    public class Coin: BaseStore
    {

        public string Symbol { get; set; }
        public ChainEnum Chain { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public bool IsWhitelisted { get; set; }
    }
}