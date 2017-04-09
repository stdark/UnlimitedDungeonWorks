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
    NetworkStream stream;
    Thread th;
    MD5 md5;
    string[] parsed;
    string xCoord;
    string yCoord;
    public bool isInBattle = false;
    public bool near = false;

    public MobGenerator mobGen;
    // Update is called once per frame
    private void Start()
    {
            client = new TcpClient();
            client.Connect(host, port);
            stream = client.GetStream();
            Thread receiveThread = new Thread(new ThreadStart(ReceiveMessage));
            receiveThread.Start();
        
    }
    void Update () {
        
        if (mobGen.generateMob)
        {
            mobGen.MobGenerate(xCoord, yCoord);
        }
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

        byte[] head = { 0x07, id, 0, byte.Parse(x.ToString()) , byte.Parse((-y).ToString()) };
        byte[] body = { byte.Parse(n.ToString()) };
        
        
        //byte[] hash = md5.ComputeHash(Encoding.Unicode.GetBytes(Encoding.Unicode.GetString(head) + body.ToString()));
        string temp = "";
        stream.Write(Encoding.ASCII.GetBytes(Encoding.ASCII.GetString(head) + Encoding.ASCII.GetString(body)), 0, Encoding.ASCII.GetBytes(Encoding.ASCII.GetString(head) + Encoding.ASCII.GetString(body)).Length);
        foreach(byte b in Encoding.ASCII.GetString(Encoding.ASCII.GetBytes(Encoding.ASCII.GetString(head) + Encoding.ASCII.GetString(body))))
        {
            temp += b.ToString() + " ";
        }
        Debug.Log(temp);
        
    }
    /*public void SendPos()
    {
        //0x07 id-host 0 x y h
        string message = GameObject.FindGameObjectWithTag("Player").transform.position.x.ToString() + " " + (-GameObject.FindGameObjectWithTag("Player").transform.position.y).ToString();
        byte[] data = Encoding.Unicode.GetBytes(message);
        stream.Write(data, 0, data.Length);
        Debug.Log(message);
        
    }*/

    // получение сообщений
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
                Debug.Log(message);//вывод сообщения

            parsed = message.Split(' ');
            if (isInBattle)
            {
                parsed = null;
            }
            if (parsed[3] == "1")
            {
                xCoord = parsed[5];
                yCoord = parsed[6];
                mobGen.generateMob = true;
                
                    if (parsed[4] == "1")
                    {
                        BattleStart();
                    }
               
                
            }
            
           


            Debug.Log("Подключение прервано!"); //соединение было прервано
               
              // Disconnect();

        }
    }


    void BattleStart() {
        isInBattle = true;
        
        
        
    }
    public void SendAttack(float x, float y)
    {
        byte id = 1;

        byte[] head = { 0x07, id, 1, byte.Parse(x.ToString()), byte.Parse((-y).ToString()) };
        byte[] body = { byte.Parse(mobGen.FindMobX("Troll").ToString()), byte.Parse((-mobGen.FindMobY("Troll")).ToString()), 1 };


        //byte[] hash = md5.ComputeHash(Encoding.Unicode.GetBytes(Encoding.Unicode.GetString(head) + body.ToString()));
        string temp = "";
        stream.Write(Encoding.ASCII.GetBytes(Encoding.ASCII.GetString(head) + Encoding.ASCII.GetString(body)), 0, Encoding.ASCII.GetBytes(Encoding.ASCII.GetString(head) + Encoding.ASCII.GetString(body)).Length);
        foreach (byte b in Encoding.ASCII.GetString(Encoding.ASCII.GetBytes(Encoding.ASCII.GetString(head) + Encoding.ASCII.GetString(body))))
        {
            temp += b.ToString() + " ";
        }
        Debug.Log(temp);
    }



    void Disconnect()
    {
        if (stream != null)
            stream.Close();//отключение потока
        if (client != null)
            client.Close();//отключение клиента
        
    }

}
