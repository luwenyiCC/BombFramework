using System;
using Google.Protobuf;

namespace BombServer.Kernel
{
    public interface IHandle
    {
        void Execute(byte[] _data,int offset,int len,long id);
        void Execute(object obj);
    }
    public abstract class NetHandle<T> : IHandle where T : IMessage, new()
    {
        public T data;
        public void Init(byte[] _data, int offset, int len)
        {

            data = ProtoTools.ToProto<T>(_data,offset ,len);
        }
        public abstract void Execute(byte[] _data,int offset,int len,long id);

        public void Execute(object obj)
        {
            throw new NotImplementedException();
        }
    }
    public abstract class EventHandle : IHandle
    {
        public void Execute(byte[] _data, int offset, int len,long id)
        {
            throw new NotImplementedException();
        }

        public abstract void Execute(object obj);
    }
}
