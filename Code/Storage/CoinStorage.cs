using Blazored.LocalStorage;
using Liquify.Code.Enums;
using Liquify.Code.Models;
using System;
using System.Collections.Concurrent;
using System.Text.Json;
using System.Threading.Tasks;

namespace Liquify.Code.Storage
{
    public class CoinStorage : BaseStorage<Coin>, IDisposable
    {
        public const string LOCAL_STORAGE_KEY = "Liquify_CoinStore";
        private bool disposedValue;

        ILocalStorageService localStorageService { get; set; }
        public CoinStorage(ILocalStorageService localStore, StoragePersistanceOption persistanceOption = StoragePersistanceOption.MemoryOnly) : base(persistanceOption)
        {
            localStorageService = localStore;
            this.OnChange += CoinStorage_OnChange;

            this.MAX_BLOCK_AGE = 0;

            //i feel dirty..
            //todo: clean me up
            Task.Run(async () => await LoadData());
            
        }

        private void CoinStorage_OnChange()
        {

            switch (this.Persistance)
            {
                case StoragePersistanceOption.ReadOnly: return;
                case StoragePersistanceOption.MemoryOnly:
                    break;
                case StoragePersistanceOption.Persist:
                    _ = SaveData();
                    break;
                default: return;
            }//end of switch


        }//private void CoinStorage_OnChange()

        public override async Task<bool> LoadData()
        {
            if (!await localStorageService.ContainKeyAsync(LOCAL_STORAGE_KEY)) { return false; }

            string jsonData = await localStorageService.GetItemAsStringAsync(LOCAL_STORAGE_KEY);

            Database = JsonSerializer.Deserialize<ConcurrentDictionary<string, Coin>>(jsonData);

            return true;
        }//public override async Task<bool> LoadData()

        public override async Task<bool> SaveData()
        {
            await localStorageService.SetItemAsStringAsync(LOCAL_STORAGE_KEY, JsonSerializer.Serialize(Database));

            return true;
        }//public override async Task<bool> SaveData()

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                    this.OnChange -= CoinStorage_OnChange;
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }//protected virtual void Dispose(bool disposing)

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~CoinStorage()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }//public class CoinStorage: BaseStorage<Coin>
}
