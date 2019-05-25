using System;
using System.Collections.Generic;
using System.IO;
using Google.Protobuf;

public class ProtoTools
{

    public static byte[] ToBuffer<T>(T t,int cmd) where T : IMessage
    {
        byte[] data = null;
        using (MemoryStream stream = new MemoryStream())
        {

            t.WriteTo(stream);
            byte[] buffer = stream.ToArray();
            int offset = 0;
            int len = buffer.Length;
            data = new byte[len + 8];
            offset += Utils.Encode32(data, offset, len);
            offset += Utils.Encode32(data, offset, cmd);
            Array.Copy(buffer, 0, data, offset, len);
        }
        return data;
    }
    public static T ToProto<T>(byte[] buffer) where T : IMessage, new()
    {
        T t = new T();
        t.MergeFrom(buffer);
        return t;
    }
}
