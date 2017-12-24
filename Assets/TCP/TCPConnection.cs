using UnityEngine;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Text;
using System;
using TCP;

namespace TCP
{
	namespace TCPConnection
	{
		public class TCPConnect : MonoBehaviour  {

			public string serverIP = "";
			public System.Int32 serverPort;

			TcpClient tcpClient;
			NetworkStream theStream;

			byte[] data; 
			string receiveMsg = "";

			bool ipconfiged = false;
			bool conReady = false;

			public Func<string,string> callBack;


			public TCPConnect(string ip, System.Int32 port, Func<string,string> callback) {//, CallBack callback) {
				serverIP = ip;
				serverPort = port;
				callBack = callback;
				data = new byte[1024];
			}

			public void ListenForData ()
			{
				readTCPInfo(); 
			}

			void readTCPInfo()
			{
				Debug.Log ("server ip: " + serverIP + "    server port: " + serverPort);

				if (serverIP != "" && serverPort != 0) {
					ipconfiged = true;
					setupTCP ();
				} 
			}

			public void setupTCP()
			{
				try
				{
					if(ipconfiged)
					{
						tcpClient = new TcpClient(serverIP, serverPort);
						tcpClient.ReceiveTimeout = 5000;
						tcpClient.SendTimeout = 5000;
						theStream = tcpClient.GetStream();

						Debug.Log("Successfully created TCP client and open the NetworkStream.");

						conReady = true;

						InvokeRepeating("receiveData", 10.0f, 0.01f);
					}
				}
				catch(Exception e)
				{
					Debug.Log("Unable to connect...");
					Debug.Log("Reason: " + e);
				}
			}


			public void receiveData()
			{
				if(!conReady)
				{
					Debug.Log("connection not ready...");
					return;
				}

				int numberOfBytesRead = 0;

				if(theStream.CanRead)
				{
					try
					{
						data =  new byte[1024];

						if(theStream.DataAvailable) {
							numberOfBytesRead = theStream.Read(data, 0, data.Length);
						
							receiveMsg = System.Text.Encoding.ASCII.GetString(data, 0, numberOfBytesRead);
							callBack (receiveMsg);
						}
					}
					catch(Exception e)
					{
						Debug.Log("Error in NetworkStream: " + e);
					}
				}

				receiveMsg = "";
			}

			public void maintainConnection()
			{
				if(!theStream.CanRead)
				{
					setupTCP();
				}
			}
			public void closeConnection()
			{
				if(!conReady) return;

				theStream.Close();
				conReady = false;
			}
		}
				
	}
}