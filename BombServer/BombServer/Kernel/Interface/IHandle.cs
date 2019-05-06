using System;
using Google.Protobuf;

namespace BombServer.Kernel.Interface
{
    public interface IHandle
    {
        void Execute(byte[] _data);
    }
    public abstract class Handle<T> : IHandle where T : IMessage, new()
    {
        public T data;
        public void Init(byte[] _data)
        {

            data = ProtoTools.ToProto<T>(_data);
        }
        public abstract void Execute(byte[] _data);
    }
}
