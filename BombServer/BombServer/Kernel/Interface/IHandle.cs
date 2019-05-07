using System;
using Google.Protobuf;

namespace BombServer.Kernel
{
    public interface IHandle
    {
        void Execute(byte[] _data);
        void Execute(object obj);
    }
    public abstract class NetHandle<T> : IHandle where T : IMessage, new()
    {
        public T data;
        public void Init(byte[] _data)
        {

            data = ProtoTools.ToProto<T>(_data);
        }
        public abstract void Execute(byte[] _data);

        public void Execute(object obj)
        {
            throw new NotImplementedException();
        }
    }
    public abstract class EventHandle : IHandle
    {
        public void Execute(byte[] _data)
        {
            throw new NotImplementedException();
        }

        public abstract void Execute(object obj);
    }
}
