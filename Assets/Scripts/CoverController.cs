using UnityEngine;
using UnityEngine.SceneManagement;
using System.Net;
using System.Net.Sockets;
using System.Threading;

public class CoverController : MonoBehaviour
{
    private UdpClient udpClient;
    private Thread receiveThread;
    private bool doJump;

    // I get back the default command available on the starter asset input. I initialize the port and i listen the incoming message (make with AI)
    void Awake()
    {
        udpClient = new UdpClient(9010);
        receiveThread = new Thread(ReceiveLoop);
        receiveThread.IsBackground = true;
        receiveThread.Start();
    }

    //infinite loop waiting for message and when the message it's true the corresponding boolean is true 
    void ReceiveLoop()
    {
        while (true)
        {
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, 0);
            byte[] data = udpClient.Receive(ref endPoint);
            string message = ParseOSCAddress(data);
            if (message == "/jump") doJump = true;
        }
    }

    // Update is called once per frame if doJump is true the next scene is loaded
    void Update()
    {
        if (doJump)
        {
            doJump = false;
            SceneManager.LoadScene("Intro");
        }
    }

    //Translation of messages received as bytes (make with AI)
    string ParseOSCAddress(byte[] data)
    {
        int i = 0;
        while (i < data.Length && data[i] != 0) i++;
        return System.Text.Encoding.ASCII.GetString(data, 0, i);
    }

    void OnDestroy()
    {
        receiveThread?.Abort();
        udpClient?.Close();
    }
}