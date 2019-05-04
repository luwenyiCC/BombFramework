
using System;
using BombServer.Kernel;

namespace BombServer
{
    public class Game : Entity
    {
        static Game game;
        public static Game Instance
        {
            get
            {
                
                return game ?? (game = new Game());
            }
        }
        private Game()
        {

        }


    }
}