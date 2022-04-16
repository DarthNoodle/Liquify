using Liquify.Code.Enums;
using Liquify.Code.Models;
using Liquify.Code.Util.Dict2Json;
using Nethereum.Hex.HexTypes;
using System;
using System.Linq;
using System.Collections.Concurrent;
using System.Numerics;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Liquify.Code.Storage
{
    public abstract class BaseStorage<TObject> where TObject : BaseStore
    {
        [JsonConverter(typeof(DictionaryStringObjectJsonConverter))]
        public ConcurrentDictionary<string, TObject> Database { internal set; get; }
        public StoragePersistanceOption Persistance { private set; get; } = StoragePersistanceOption.MemoryOnly;

        internal uint MAX_BLOCK_AGE = 15 * 5; //assumed 15 blocks a min.

        public BaseStorage(StoragePersistanceOption persistanceOption = StoragePersistanceOption.MemoryOnly)
        {
            Persistance = persistanceOption;

            // 3 Estimated Concurrent Connections, 150 Objects Starting Capacity
            Database = new ConcurrentDictionary<string, TObject>(3,150);
        }//end of constructor


        public TObject TryGet(HexBigInteger currentBlockHeight, string address, ChainEnum chain)
        {
            
            Database.TryGetValue(GenerateDataBaseKey(address, chain), out TObject result);

            if(result == null) { return null; }
            if(currentBlockHeight.Value == 0 || result.BlockHeight.Value == 0){ return result; }

            //cache has expired, return null so it should go through the refresh process.
            if(currentBlockHeight.Value - result.BlockHeight.Value > MAX_BLOCK_AGE) { return null; }

            return result;
        }//public TObject? TryGet(string address, ChainEnum chain)


        public TObject TryGet(string address, ChainEnum chain)
        {

            Database.TryGetValue(GenerateDataBaseKey(address, chain), out TObject result);

            return result;
        }//public TObject? TryGet(string address, ChainEnum chain)

        public bool AddOrUpdate(string address, ChainEnum chain, TObject data)
        {

            if(Persistance == StoragePersistanceOption.ReadOnly) { return false; }

            string databaseKey = GenerateDataBaseKey(address, chain);

            if(Database.ContainsKey(databaseKey)) { return TryUpdate(databaseKey, data); }

            if(!Database.TryAdd(databaseKey, data)) { return false; }

            NotifyStateChanged();
            return true;
        }//public bool AddOrUpdate(string address, ChainEnum chain, TObject data)



        public bool TryUpdate(string databaseKey, TObject data)
        {
            if (Persistance == StoragePersistanceOption.ReadOnly) { return false; }
            if (!Database.TryAdd(databaseKey, data)) { return false; }

            NotifyStateChanged();
            return true;
        }//public bool TryUpdate(string databaseKey, TObject data)

        public HexBigInteger GetLastBlockNumber(List<TObject> data) => data.OrderByDescending(d => d.BlockHeight).FirstOrDefault().BlockHeight;//public HexBigInteger GetLastBlockNumber(TObject data)



        public bool TryRemove(string address, ChainEnum chain)
        {
            if(!Database.TryRemove(GenerateDataBaseKey(address, chain), out TObject obj)) { return false; }

            NotifyStateChanged();
            return true;
        }

        public void Clear()
        {
            Database.Clear();
            NotifyStateChanged();
        }//public void Clear()



        //chain on the end because that will increase search time (first few chars are all the same)
        public static string GenerateDataBaseKey(string address, ChainEnum chain) => $"{address}{chain}";

        //persist Data to source (e.g. Local Storage)

        public abstract Task<bool> SaveData();

        //load data from source (e.g. Local Storage)
        public abstract Task<bool> LoadData();



        //State Management
        //https://docs.microsoft.com/en-us/aspnet/core/blazor/state-management?view=aspnetcore-6.0&pivots=webassembly
        public event Action OnChange;
        private void NotifyStateChanged() => OnChange?.Invoke();
    }//end of class
}
