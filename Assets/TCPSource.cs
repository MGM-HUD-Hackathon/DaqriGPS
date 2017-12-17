using System;

using System.Collections;

using System.Collections.Generic;

using System.Net.Sockets;

using System.Text;

using System.Threading;

using UnityEngine;

using UnityEngine.UI;

//using GeoUtility.GeoSystem; 

namespace TCPStatic

{

	public static class Source

	{

		public static double lon {get;set;}

		public static double lat {get;set;}

		public static double alt {get;set;}

		public static NetworkStream stream1;
		public static NetworkStream stream2;

	}

}

public class TCPSource : MonoBehaviour {    

	#region private members     

	private TcpClient socketConnection;     

	private Thread clientReceiveThread;     

	#endregion      

	private IEnumerator coroutine;

	private string ip   = "10.10.46.139";

	private int    port = 4352;

	private string nmea = "$GPGGA";

	static double Lat_dec_deg;

	static double Lon_dec_deg;

	//http://gpsworld.com/what-exactly-is-gps-nmea-data/

	// Use this for initialization  

	void Start () {

		Debug.Log ("In the TCPTestClient Connect method");

		ConnectToTcpServer(); 

	}   

	public double getSourceLon() {

		return Lon_dec_deg;

	}

	public double getSourceLat() {

		return Lat_dec_deg;

	}

	// Update is called once per frame

	void Update () {

	}   

	/// <summary>     

	/// Setup socket connection.    

	/// </summary>    

	private void ConnectToTcpServer () {        

		print("Starting " + Time.time);

		//coroutine = ListenForData(3.0f);

		//StartCoroutine(coroutine);

		//InvokeRepeating("ListenForData", 1.0f, 1.0f);
		ListenForData();

	}   

	/// <summary>     

	/// Listen for Data

	/// </summary>     

	public void ListenForData() {   

		//while (true) {

		try {           


				InvokeRepeating("getData", 1.0f, 1.0f);
			//}
			//getData();




		} catch (SocketException socketException) {             

			Debug.Log ("Socket exception: " + socketException);         

		}  
	}

	public void getData() {
		
		/*socketConnection = new TcpClient (ip, port); 
		using (TCPStatic.Source.stream2 = socketConnection.GetStream ()) {  
	//while (true) {
		Debug.Log("Testing");


		Debug.Log ("Testing1");
		Byte[] bytes = new Byte[1024]; 

		Debug.Log("Testing2");
		int length = TCPStatic.Source.stream2.Read (bytes, 0, bytes.Length);

		Debug.Log ("Testing3");


		var incommingData = new byte[length];                       

		Array.Copy (bytes, 0, incommingData, 0, length);                        

		string serverMessage = Encoding.ASCII.GetString (incommingData);    

		string[] srvrMsgs = serverMessage.Split (',');

			if (srvrMsgs [0] == nmea) {

				Debug.Log (serverMessage);

				double Lat = Convert.ToDouble (srvrMsgs [2]) / 100; //32.226984

				double Lon = Convert.ToDouble (srvrMsgs [4]) / 100; //86.186043

				double Alt = Convert.ToDouble (srvrMsgs [9]);

				//Debug.Log("Lat: " + Lat);

				//Debug.Log("Lon: " + Lon);

				double Lat_deg = Convert.ToDouble (Math.Floor (Lat)); //32

				double Lon_deg = Convert.ToDouble (Math.Floor (Lon)); //86

				//Debug.Log("Lat_deg: " + Lat_deg);

				//Debug.Log("Lon_deg: " + Lon_deg);

				double Lat_minute = (Lat - Lat_deg) * 100 / 60; //(0.226984*100)/60 = (22.6984)/60 = 0.378306

				double Lon_minute = (Lon - Lon_deg) * 100 / 60; //(0.186043*100)/60  = (18.6043)/60 = 0.310071

				//Debug.Log("Lat_minute: " + Lat_minute);

				//Debug.Log("Lon_minute: " + Lon_minute);

				Lat_dec_deg = Lat_deg + Lat_minute;

				Lon_dec_deg = Lon_deg + Lon_minute;

				//Debug.Log("Lat_dec_deg: " + Lat_dec_deg);

				//Debug.Log("Lon_dec_deg: " + Lon_dec_deg);

				if (srvrMsgs [3] == "S") {

					Lat_dec_deg = Lat_dec_deg * -1;

				}

				if (srvrMsgs [5] == "W") {

					Lon_dec_deg = Lon_dec_deg * -1;

				}


				//Debug.Log ("Ping 1");

				//.GetComponent<TextMesh> ().text =  MgrsString;

				Debug.Log ("1Lat: " + Lat.ToString () + "\nLon: " + Lon.ToString () + "\n" + Alt.ToString ("0.0") + "MSL");

				//gameObject.GetComponent<TextMesh> ().text = "Lat: " + Lat.ToString () + "\nLon: " + Lon.ToString () + "\n" + Alt.ToString ("0.0") + "MSL";

				Debug.Log ("Testing4");

				TCPStatic.Source.lon = Lon;

				TCPStatic.Source.lat = Lat;

				TCPStatic.Source.alt = Alt;
			}
		}*/
	}

}

