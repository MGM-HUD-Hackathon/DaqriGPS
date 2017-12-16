
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class TCPTestClient : MonoBehaviour {  	
	#region private members 	
	private TcpClient socketConnection; 	
	private Thread clientReceiveThread; 	
	#endregion  	
	private IEnumerator coroutine;

	// Use this for initialization 	
	void Start () {
		Debug.Log ("In the Connect method");
		ConnectToTcpServer();     
	}  	

	// Update is called once per frame
	void Update () {
	}  	

	/// <summary> 	
	/// Setup socket connection. 	
	/// </summary> 	
	private void ConnectToTcpServer () { 		
		print("Starting " + Time.time);
		coroutine = ListenForData(1.0f);
		StartCoroutine(coroutine);
	}  	
	/// <summary> 	
	/// Runs in background clientReceiveThread; Listens for incomming data. 	
	/// </summary>     
	private IEnumerator ListenForData(float waitTime) { 		
		while (true) {
			
			try { 			
				socketConnection = new TcpClient ("10.10.46.52", 4352);  			
				Byte[] bytes = new Byte[1024];             
				using (NetworkStream stream = socketConnection.GetStream ()) { 					
					int length = stream.Read (bytes, 0, bytes.Length);
						var incommingData = new byte[length]; 						
						Array.Copy (bytes, 0, incommingData, 0, length); 						
						string serverMessage = Encoding.ASCII.GetString (incommingData); 	

						Debug.Log(serverMessage);

						string[] srvrMsgs = serverMessage.Split (',');

						if (srvrMsgs [0] == "$GPGGA") {
							Debug.Log (serverMessage);

							double Lat = Convert.ToDouble (srvrMsgs [2]);
							double Long1 = Convert.ToDouble (srvrMsgs [4]);

							if (srvrMsgs [4] == "S") {
								Lat = Lat * -1;
							}

							if (srvrMsgs [4] == "W") {
								Long1 = Long1 * -1;
							}

							gameObject.GetComponent<TextMesh>().text = "Lat: " + Lat.ToString() + "\nLon: " + Long1.ToString();
					
					} 				
				} 	       
			} catch (SocketException socketException) {             
				Debug.Log ("Socket exception: " + socketException);         
			}  

			yield return new WaitForSeconds (waitTime);
			print ("Executed " + Time.time);
		}
	}

}