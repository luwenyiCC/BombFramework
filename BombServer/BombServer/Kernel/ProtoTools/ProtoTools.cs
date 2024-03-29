﻿
using System;
using System.IO;
using Google.Protobuf;

namespace BombServer.Kernel
{
    public class ProtoTools
    {
        public static byte[] ToBuffer<T>(T t) where T : IMessage
        {
            byte[] buffer = null;
            using (MemoryStream stream = new MemoryStream())
            {

                t.WriteTo(stream);
                buffer = stream.ToArray();
            }
            return buffer;
        }
        public static T ToProto<T>(byte[] buffer) where T : IMessage ,new()
        {
            T t = new T();
            t.MergeFrom(buffer);
            return t;
        }
        public static T ToProto<T>(byte[] buffer,int offset,int len) where T : IMessage, new()
        {
            T t = new T();
            t.MergeFrom(buffer,offset ,len);
            return t;
        }
    }
}
