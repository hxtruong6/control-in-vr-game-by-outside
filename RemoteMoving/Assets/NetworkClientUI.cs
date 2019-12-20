using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.NetworkSystem;
using UnityEngine.UI;

public class NetworkClientUI : MonoBehaviour
{
    public string SERVER_HOST = "192.168.1.9";
    public int SERVER_PORT = 25000;
    public static int MSG_TYPE = 888;

    public VariableJoystick variableJoystick;
    public Button ConnectButton;
    public Text InfoText;

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

    private static NetworkClient client;

    void OnGUI()
    {
        string ipAddress = LocalIPAddress();
//        GUI.Box(new Rect(10, Screen.height - 50, 250, 200), ipAddress);
//        GUI.Label(new Rect(20, Screen.height - 30, 250, 170), "Status: " + client.isConnected);
        InfoText.text = "ServerIP: " + SERVER_HOST +
                        "\nCurrent: " + ipAddress +
                        "\nStatus: " + client.isConnected;

        if (!client.isConnected)
        {
            ConnectButton.gameObject.SetActive(true);
        }
        else
        {
            ConnectButton.gameObject.SetActive(false);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        client = new NetworkClient();
        ConnectButton.onClick.AddListener(Connect);
    }

    void Connect()
    {
        client.Connect(SERVER_HOST, SERVER_PORT);
    }

    // Update is called once per frame
    void Update()
    {
    }

    static public void SendJoystickInfo(float hDelta, float vDelta, bool jump)
    {
        if (client.isConnected)
        {
            StringMessage msg = new StringMessage();
            msg.value = hDelta + "|" + vDelta + "|" + jump;
            client.Send((short) MSG_TYPE, msg);
        }
    }
}