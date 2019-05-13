using System;
using System.Diagnostics;
using System.Threading.Tasks;
using BombServer.Kernel;
using MongoDB.Driver;

namespace BombServer.Database
{
    public class MongoDBTools
    {
        IMongoDatabase database;
        public MongoDBTools()
        {
        }
        public void Connect()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            database = client.GetDatabase("Bomb");
            //await database.CreateCollectionAsync("AccountInfo");
            //IMongoCollection<AccountInfo> collectionAI = database.GetCollection<AccountInfo>("AccountInfo");
            //AccountInfo accountInfo = new AccountInfo();
            //accountInfo.account = "123";
            //accountInfo.password = "123";
            //await collectionAI.InsertOneAsync(accountInfo);

        }
        public async void Test()
        {
            //AccountInfo accountInfo = new AccountInfo
            //{
            //    aid = IdGenerater.GenerateId() ,
            //    account = "222",
            //    password = "222"
            //};
            //Stopwatch sw = new Stopwatch();
            //sw.Start();

            //sw.Stop();
            //await  InsertOneAsync(accountInfo);
            AccountInfo accountInfo2 = await FindAsync<AccountInfo>();
            Debug.Log(accountInfo2);
        }
        public async Task<bool > InsertOneAsync<T>(T t) where  T : DataBean 
        {
            IMongoCollection<T> collectionAI = database.GetCollection<T>(t.GetTypeName());
            try
            {
                await collectionAI.InsertOneAsync(t);
                return true;
            }
            catch (Exception ex)
            {
                Debug.Log(ex);
                return false ;

            }
        }
        public async Task<T> FindAsync<T>() where T : DataBean
        {
            IMongoCollection<T> collectionAI = database.GetCollection<T>(typeof(T).Name);
            try
            {
                IAsyncCursor<T> cursor = await collectionAI.FindAsync<T>((s) => true);
                return cursor.FirstOrDefault();

            }
            catch (Exception ex)
            {
                Debug.Log(ex);
                return null;
            }
        }
    }
}
