using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using StarterAssets;

public class ChataigneReceiver : MonoBehaviour
{
    private UdpClient udpClient;
    private Thread receiveThread;
    private bool doLeft, doRight, doFront, doStop, doJump;
    private StarterAssetsInputs _input;

    // I get back the default command available on the starter asset input. I initialize the port and i listen the incoming message (make with AI)
    void Awake()
    {
        _input = GetComponent<StarterAssetsInputs>();
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
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, 0); //(2 lines make with AI)
            byte[] data = udpClient.Receive(ref endPoint);
            string message = ParseOSCAddress(data);
            if (message == "/left")  doLeft  = true;
            if (message == "/right") doRight = true;
            if (message == "/front") doFront = true;
            if (message == "/stop")  doStop  = true;
            if (message == "/jump")  doJump  = true;
        }
    }
    

    private float jumpMoveTimer = 0f;

    // Update is called once per frame
    // I create a vector for the movement. When a boolean is true there is a movement for the corresponding 
    void Update()
    {
        Vector2 move = Vector2.zero;

        if (doLeft)  move.y =  1f;
        if (doRight) move.y = -1f;
        if (doFront) move.x =  1f;

        // I add a moving forward for the jump. it's based on a timer and the jump turn off
        if (doJump)  
        { 
            _input.JumpInput(true);
            jumpMoveTimer = 0.1f; 
            doJump = false;
        }

        // the character keep moving faster during the jump then the timer is over
        if (jumpMoveTimer > 0)
        {
            move.x = 3f;
            jumpMoveTimer -= Time.deltaTime;
        }

        _input.MoveInput(move);

        // After the move is done all the boolean turn off (to wait for the next message because the message is only true for one frame)
        doLeft = doRight = doFront = doStop = false;
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