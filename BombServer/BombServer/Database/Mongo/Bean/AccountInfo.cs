using System;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;

namespace BombServer.Database
{
    public class AccountInfo: DataBean
    {
        public AccountInfo()
        {
        }
        [BsonId]
        public long aid;

        public string account;
        public string password;
    }
}
