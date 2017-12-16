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
	private string ip   = "10.10.46.147";
	private int    port = 4352;
	private string nmea = "$GPGGA";
	//http://gpsworld.com/what-exactly-is-gps-nmea-data/


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
		coroutine = ListenForData(3.0f);
		StartCoroutine(coroutine);
	}  	
	/// <summary> 	
	/// Listen for Data
	/// </summary>     
	private IEnumerator ListenForData(float waitTime) { 	
		while (true) {
			try { 			
				socketConnection = new TcpClient (ip, port);  			
				Byte[] bytes = new Byte[1024]; 

				while (true) {
					using (NetworkStream stream = socketConnection.GetStream ()) { 					
						int length = stream.Read (bytes, 0, bytes.Length);
						var incommingData = new byte[length]; 						
						Array.Copy (bytes, 0, incommingData, 0, length); 						
						string serverMessage = Encoding.ASCII.GetString (incommingData); 	

						string[] srvrMsgs = serverMessage.Split (',');

						if (srvrMsgs [0] == nmea) {
							Debug.Log (serverMessage);

							double Lat = Convert.ToDouble (srvrMsgs [2]);
							double Lon = Convert.ToDouble (srvrMsgs [4]);

							if (srvrMsgs [4] == "S") {
								Lat = Lat * -1;
							}

							if (srvrMsgs [4] == "W") {
								Lon = Lon * -1;
							}

							//Debug.Log ("Ping 1");
							gameObject.GetComponent<TextMesh> ().text = "Lat: " + Lat.ToString () + "\nLon: " + Lon.ToString ();
							//Debug.Log ("Ping 2");
							break;
						
						} 	
					}
				} 	       
			} catch (SocketException socketException) {             
				Debug.Log ("Socket exception: " + socketException);         
			}  
			//Debug.Log ("Ping 4");
			yield return new WaitForSeconds (waitTime);
		}
	}
	

	/*private IEnumerator waitt(float waitTime) {
		print ("Started waiting " + Time.time);
		yield return new 
		print ("Finished Execution " + Time.time);
	}*/

}

