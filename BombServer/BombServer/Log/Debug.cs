﻿using System;
namespace BombServer
{
    public class Debug
    {
        public Debug()
        {
        }
        public static void Log(string msg)
        {
            Console.WriteLine(msg);
        }
        public static void Log(object msg)
        {
            Console.WriteLine(msg);
        }
    }
}
