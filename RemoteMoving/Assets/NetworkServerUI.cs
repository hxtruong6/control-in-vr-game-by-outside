using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.NetworkSystem;

public class NetworkServerUI : MonoBehaviour
{
    public int SERVER_PORT = 25000;
    public int MSG_TYPE = 888;

    public ObjectMovingInServer objectMovingInServer;

    private static string LocalIPAddress()
    {
        IPHostEntry host;
        string localIP = "0.0.0.0";
        host = Dns.GetHostEntry(Dns.GetHostName());
        foreach (IPAddress ip in host.AddressList)
        {
            if (ip.AddressFamily == AddressFamily.InterNetwork)
            {
                localIP = ip.ToString();
                break;
            }
        }

        return localIP;
    }

    void OnGUI()
    {
//        string ipAddress = NetworkManager.singleton.networkAddress;
        string ipAddress = LocalIPAddress();
        GUI.Box(new Rect(10, Screen.height - 50, 100, 50), ipAddress);
        GUI.Label(new Rect(20, Screen.height - 35, 100, 20), "Status: " + NetworkServer.active);
        GUI.Label(new Rect(20, Screen.height - 20, 100, 20), "Connected: " + NetworkServer.connections.Count);
    }

    // Start is called before the first frame update
    void Start()
    {
        NetworkServer.Listen(SERVER_PORT);

        NetworkServer.RegisterHandler((short) MSG_TYPE, ServerReceiveMessage);
    }

    private void ServerReceiveMessage(NetworkMessage netmsg)
    {
        StringMessage msg = new StringMessage();
        msg.value = netmsg.ReadMessage<StringMessage>().value;

        Debug.Log("Message in server: " + msg.value);
        string[] deltas = msg.value.Split('|');
        var vertical = Convert.ToSingle(deltas[0]);
        var horizontal = Convert.ToSingle(deltas[1]);
        objectMovingInServer.MovingUpdate(vertical, horizontal);
    }

    // Update is called once per frame
    void Update()
    {
    }
}