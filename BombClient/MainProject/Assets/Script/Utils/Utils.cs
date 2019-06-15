using System;

public class Utils
{
    /* decode 32 bits unsigned int (lsb) */
    public static int Decode32u(byte[] p, int offset, ref UInt32 c)
    {
        UInt32 result = 0;
        result |= (UInt32)p[0 + offset];
        result |= (UInt32)(p[1 + offset] << 8);
        result |= (UInt32)(p[2 + offset] << 16);
        result |= (UInt32)(p[3 + offset] << 24);
        c = result;
        return 4;
    }
    public static int Decode32(byte[] p, int offset, ref int c)
    {
        int result = 0;
        result |= (int)p[0 + offset];
        result |= (int)(p[1 + offset] << 8);
        result |= (int)(p[2 + offset] << 16);
        result |= (int)(p[3 + offset] << 24);
        c = result;
        return 4;
    }

    /* decode 32 bits unsigned int (lsb) */
    public static short Decode16(byte[] p, int offset, ref short c)
    {
        short result = 0;
        result |= (short)p[0 + offset];
        result |= (short)(p[1 + offset] << 8);
        c = result;
        return 2;
    }
    public static int Decode32u(byte[] p, uint offset, ref UInt32 c)
    {
        UInt32 result = 0;
        result |= (UInt32)p[0 + offset];
        result |= (UInt32)(p[1 + offset] << 8);
        result |= (UInt32)(p[2 + offset] << 16);
        result |= (UInt32)(p[3 + offset] << 24);
        c = result;
        return 4;
    }
    public static int Encode32u(byte[] p, int offset, UInt32 l)
    {
        p[0 + offset] = (byte)(l >> 0);
        p[1 + offset] = (byte)(l >> 8);
        p[2 + offset] = (byte)(l >> 16);
        p[3 + offset] = (byte)(l >> 24);
        return 4;
    }
    public static int Encode32(byte[] p, int offset, int l)
    {
        p[0 + offset] = (byte)(l >> 0);
        p[1 + offset] = (byte)(l >> 8);
        p[2 + offset] = (byte)(l >> 16);
        p[3 + offset] = (byte)(l >> 24);
        return 4;
    }
    public static int Encode16(byte[] p, int offset, Int16 l)
    {
        p[0 + offset] = (byte)(l >> 0);
        p[1 + offset] = (byte)(l >> 8);
        return 2;
    }
    /// <summary>
    /// 获取时间戳
    /// </summary>
    /// <returns></returns>
    public static long GetTimestamp()
    {
        return DateTime.Now.Ticks / 10000;
    }
    /// <summary>
    /// 获取时间戳
    /// </summary>
    /// <returns></returns>
    public static long GetDateTimeNowTicks()
    {
        return DateTime.Now.Ticks;
    }
    /// <summary>
    /// 获取时间对象
    /// </summary>
    /// <returns></returns>
    public static DateTime GetDateTime()
    {
        return DateTime.Now;
    }


   

}
