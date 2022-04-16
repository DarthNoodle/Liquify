using Blazored.LocalStorage;
using Liquify.Code.Enums;
using Liquify.Code.Models;
using System.Collections.Concurrent;

namespace Liquify.Code.Storage
{

    public class DataStorage: IDataStorage
    {
        

        private ILocalStorageService localStorageService { get; set; }

        public CoinStorage CoinStore => _CoinStore;
        private CoinStorage _CoinStore { get; set; }

        public CoinLPStorage CoinLPStore => _CoinLPStore;
        private CoinLPStorage _CoinLPStore { get; set; }

        public DataStorage(ILocalStorageService localStorage)
        {
            localStorageService = localStorage;
            _CoinStore = new CoinStorage(localStorage, StoragePersistanceOption.Persist);
            _CoinLPStore =  new CoinLPStorage(localStorage, StoragePersistanceOption.Persist);
        }



    }//end of class



}