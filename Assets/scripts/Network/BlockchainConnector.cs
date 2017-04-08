/*using System;
using System.Threading;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

public class BlockchainConnector : MonoBehaviour {

    private const string host = "10.193.128.49";
    private const int port = 47016;
    static TcpClient client;
    NetworkStream stream;
    Thread th;
    // Use this for initialization
    void Start () {
       
            client = new TcpClient();
            client.Connect(host, port);
            stream = client.GetStream();

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.O)){
            MakeMoney();
        }
	}

    void MakeMoney()
    {
        stream.Write(Encoding.ASCII.GetBytes("Hello"), 0,5);
    }
}
*/