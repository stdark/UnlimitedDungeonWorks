/*using System;
using System.Threading;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

public class BlockchainConnector : MonoBehaviour
{

    private const string host = "127.0.0.1";
    private const int port = 47016;
    static TcpClient client;
    NetworkStream stream;
    Thread th;
    // Use this for initialization
    void Start()
    {

        client = new TcpClient();
        client.Connect(host, port);
        stream = client.GetStream();
        Thread receiveThread = new Thread(new ThreadStart(ReceiveMessage));
        receiveThread.Start();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            MakeMoney();
        }
    }

    void ReceiveMessage()
    {
        while (true)
        {

            byte[] data = new byte[64]; // буфер для получаемых данных 
            StringBuilder builder = new StringBuilder();
            int bytes = 0;
            do
            {
                bytes = stream.Read(data, 0, data.Length);
                builder.Append(Encoding.ASCII.GetString(data, 0, bytes));

            }
            while (stream.DataAvailable);

            string message = builder.ToString();
            Debug.Log(message);


        }

    }

    void MakeMoney()
    {
        stream.Write(Encoding.ASCII.GetBytes("Hello"), 0, 5);
    }
    void Disconnect()
    {
        if (stream != null)
            stream.Close();//отключение потока
        if (client != null)
            client.Close();//отключение клиента 

    }
}*/