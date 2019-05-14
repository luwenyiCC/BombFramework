using System;
using MongoDB.Bson.Serialization.Attributes;

namespace BombServer.Database
{
    public class DataBean : IDatabaseBean
    {

        public DataBean()
        {
            typeName = this.GetType().Name; ;
        }
        [BsonIgnore]
        public string typeName;
        public string GetTypeName()
        {
            return typeName;
        }
    }
}
