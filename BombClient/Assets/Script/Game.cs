using System.Collections;
using System.Collections.Generic;
using BombServer.Kernel;
using UnityEngine;

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
    public SystemEvent systemEvent;
    private Game()
    {
        systemEvent = new SystemEvent();
    }

}
