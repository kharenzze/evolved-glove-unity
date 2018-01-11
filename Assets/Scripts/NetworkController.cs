using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

public class NetworkController : MonoBehaviour {

    // receiving Thread
    Thread receiveThread;

    // udpclient object
    UdpClient client;
    public HandController hController;

    // public
    // public string IP = "127.0.0.1"; default local
    public int port; // define > init

    // start from unity3d
    public void Start() {
        client = new UdpClient(port);
        byte[] datagram = Encoding.ASCII.GetBytes("HELLO");
        client.Send(datagram, datagram.Length, "192.168.0.64", 58878);
        init();
    }

    // init
    private void init() {
        receiveThread = new Thread(
            new ThreadStart(ReceiveData));
        receiveThread.IsBackground = true;
        receiveThread.Start();

    }

    // receive thread
    private void ReceiveData() {
        print(client);
        bool cont = true;
        while (cont) {
            try {
                IPEndPoint anyIP = new IPEndPoint(IPAddress.Any, 0);
                byte[] data = client.Receive(ref anyIP);
                HandState hs = HandState.handStateFromPacket(data);
                hController._hs = hs;
            } catch (Exception err) {
                print(err.ToString());
                cont = false;
            }
        }
    }

    private void OnDestroy() {
        receiveThread.Abort();
    }
}
