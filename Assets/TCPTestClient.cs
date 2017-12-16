using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

using GeoUtility.GeoSystem; 

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

							double Lat = Convert.ToDouble (srvrMsgs [2])/100; //32.226984
							double Lon = Convert.ToDouble (srvrMsgs [4])/100; //86.186043

							//Debug.Log("Lat: " + Lat);
							//Debug.Log("Lon: " + Lon);


							double Lat_deg = Convert.ToDouble(Math.Floor(Lat)); //32
							double Lon_deg = Convert.ToDouble(Math.Floor(Lon)); //86


							//Debug.Log("Lat_deg: " + Lat_deg);
							//Debug.Log("Lon_deg: " + Lon_deg);

							double Lat_minute = (Lat - Lat_deg)*100/60; //(0.226984*100)/60 = (22.6984)/60 = 0.378306
							double Lon_minute = (Lon - Lon_deg)*100/60; //(0.186043*100)/60  = (18.6043)/60 = 0.310071


							//Debug.Log("Lat_minute: " + Lat_minute);
							//Debug.Log("Lon_minute: " + Lon_minute);

							double Lat_dec_deg = Lat_deg + Lat_minute;
							double Lon_dec_deg = Lon_deg + Lon_minute;

							//Debug.Log("Lat_dec_deg: " + Lat_dec_deg);
							//Debug.Log("Lon_dec_deg: " + Lon_dec_deg);

							if (srvrMsgs [3] == "S") {
								Lat_dec_deg = Lat_dec_deg * -1;
							}

							if (srvrMsgs [5] == "W") {
								Lon_dec_deg = Lon_dec_deg * -1;
							}




							/*Debug.Log("Lat: " + Lat.ToString());
							Debug.Log("Lon: " + Lon.ToString()); */


							Geographic geo = new Geographic(Lon_dec_deg, Lat_dec_deg);
							MGRS mgrs  = (MGRS)geo;
							double eastM = mgrs.East;
							double northM = mgrs.North;
							int zoneM = mgrs.Zone;
							string bandM = mgrs.Band;
							string gridM = mgrs.Grid;
							string MgrsString = zoneM.ToString() + bandM + " " + gridM + " " + eastM.ToString() + " " + northM.ToString();

							//Debug.Log ("Ping 1");
							gameObject.GetComponent<TextMesh> ().text =  MgrsString;
							//gameObject.GetComponent<TextMesh> ().text = "Lat: " + Lat.ToString () + "\nLon: " + Lon.ToString ();

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
