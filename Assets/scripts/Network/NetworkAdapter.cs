using System;
using System.Threading;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

public class NetworkAdapter : MonoBehaviour {
    private const string host = "172.20.10.5";
    private const int port = 8888;
    static TcpClient client;
    static NetworkStream stream;
    Thread th;
    MD5 md5;
    // Update is called once per frame
    private void Start()
    {
        client = new TcpClient();
        client.Connect(host, port);
        stream = client.GetStream();
        
    }
    void Update () {
        
        try
        {
            //подключение клиента
            // получаем поток
            //SendMess();
            

            // запускаем новый поток для получения данных

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    public void SendPos(float x, float y,byte n)
    {
        //0x07 id-host 0 x y n hash
        byte id = 1;

        byte[] head = { 0x07, id, 0, (byte)x, (byte)y };
        byte body = n;
        //byte[] hash = md5.ComputeHash(Encoding.Unicode.GetBytes(Encoding.Unicode.GetString(head) + body.ToString()));

        byte[] data = Encoding.Unicode.GetBytes(Encoding.Unicode.GetString(head) + body.ToString() );
        stream.Write(data, 0, data.Length);
        
        
    }
    /*public void SendPos()
    {
        //0x07 id-host 0 x y h
        string message = GameObject.FindGameObjectWithTag("Player").transform.position.x.ToString() + " " + (-GameObject.FindGameObjectWithTag("Player").transform.position.y).ToString();
        byte[] data = Encoding.Unicode.GetBytes(message);
        stream.Write(data, 0, data.Length);
        Debug.Log(message);
        
    }*/

}
