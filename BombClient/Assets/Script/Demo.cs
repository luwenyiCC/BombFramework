using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BombFramework;
using System.IO;
using Google.Protobuf;

public class Demo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //TcpSession tcpSession = new TcpSession();
        //tcpSession.Connect();
        Game game = new Game();
        game.ID = 1001;
        byte[] bytes;
        using (MemoryStream stream = new MemoryStream())
        {

            //var cos = new CodedOutputStream(stream);
            // Save the person to a stream
            game.WriteTo(stream);

            

            bytes = stream.ToArray();
        }
        Game game2 = Game.Parser.ParseFrom(bytes);
        Debug.Log(game2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
