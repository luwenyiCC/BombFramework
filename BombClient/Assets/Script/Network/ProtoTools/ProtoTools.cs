using System;
using System.IO;
using Google.Protobuf;

public class ProtoTools
{
    /// <summary>
    /// Tos the buffer.
    /// </summary>
    /// <returns>The buffer.</returns>
    /// <param name="t">T.</param>
    /// <typeparam name="T">The 1st type parameter.</typeparam>
    public byte[] ToBuffer<T>(T t) where T : IMessage
    {
        byte[] buffer = null;
         using(MemoryStream stream = new MemoryStream())
        {
            t.WriteTo(stream);
            buffer = stream.ToArray();
        } 
        return buffer;
    }
    //public T ToProto<T>(byte[] buffer) where T : IMessage<T>
    //{

    //    return T.Parser.ParseFrom(buffer);
    //}
}
