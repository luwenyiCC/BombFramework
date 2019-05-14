using System;
using System.Collections.Generic;
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
            //    account = "2222",
            //    password = "1111"
            //};
            Stopwatch sw = new Stopwatch();

            sw.Start();
            //AccountInfo accountInfo = await FindAsync<AccountInfo>((a) =>  a.account == "2222");
            //accountInfo.password = "123";
            await DeleteOneAsync<AccountInfo>((a)=> a.account == "222" );
            sw.Stop();
            Debug.Log(sw.ElapsedTicks);

        }
        Dictionary<Type, object > collectionMap = new Dictionary<Type, object>();
        public IMongoCollection<T> GetCollection<T>() where T : DataBean
        {
            IMongoCollection<T> collection;

            foreach (var item in collectionMap)
            {
                if (item .Key  == typeof(T) )
                {
                    collection = item.Value as IMongoCollection<T>;//TODO 待优化 强制转换开销较大
                    return collection;
                }
            }
            collection = database.GetCollection<T>(typeof(T).Name);
            collectionMap[typeof (T)] = collection ;
            return collection;
        }
        public async Task<bool > InsertOneAsync<T>(T t) where  T : DataBean 
        {
            try
            {
                await GetCollection<T>().InsertOneAsync(t);
                return true;
            }
            catch (Exception ex)
            {
                Debug.Log(ex);
                return false ;

            }
        }
        public async Task<long> CountDocumentsAsync<T>(System.Linq.Expressions.Expression<Func<T, bool>> expression) where T : DataBean
        {

            try
            {
                long count = await GetCollection<T>().CountDocumentsAsync<T>(expression);
                return count;

            }
            catch (Exception ex)
            {
                Debug.Log(ex);
                return -1;
            }
        }
        public async Task<T> FindAsync<T>(System.Linq.Expressions.Expression<Func <T,bool>> expression) where T : DataBean
        {
            try
            {
                IAsyncCursor<T> cursor = await GetCollection<T>().FindAsync<T>(expression);
                return cursor.FirstOrDefault();

            }
            catch (Exception ex)
            {
                Debug.Log(ex);
                return null;
            }
        }
        public async Task<long> ReplaceOneAsync<T>(System.Linq.Expressions.Expression<Func<T, bool>> expression, T t) where T : DataBean
        {
            try
            {
                ReplaceOneResult result = await GetCollection<T>().ReplaceOneAsync<T>(expression,t);
                return result.ModifiedCount ;

            }
            catch (Exception ex)
            {
                Debug.Log(ex);
                return -1;
            }
        }
        public async Task<long> DeleteOneAsync<T>(System.Linq.Expressions.Expression<Func<T, bool>> expression) where T : DataBean
        {
            try
            {
                DeleteResult result = await GetCollection<T>().DeleteOneAsync<T>(expression);
                return result.DeletedCount ;

            }
            catch (Exception ex)
            {
                Debug.Log(ex);
                return -1;
            }
        }
    }
}
