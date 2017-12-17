using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using TCPStatic;

public class TCPTarget : MonoBehaviour {  	
	#region private members 	
	private TcpClient socketConnection; 	
	private Thread clientReceiveThread; 	
	#endregion  	
	private IEnumerator coroutine;
	private string ip   = "10.10.46.155";
	private int    port = 4352;
	private string nmea = "$GPGGA";
	//http://gpsworld.com/what-exactly-is-gps-nmea-data/\



	// Use this for initialization 	
	void Start () {
		Debug.Log ("In the TPSTarget Connect method");
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

		ListenForData ();

		//InvokeRepeating("ListenForData", 1.0f, 1.0f);
	}  	
	/// <summary> 	
	/// Listen for Data
	/// </summary>     
	public void ListenForData() { 	
		try { 			
			
			  InvokeRepeating("getData", 1.5f, 1.0f);
			//}
			//getData();
		} catch (SocketException socketException) {             
			Debug.Log ("Socket exception: " + socketException);         
		}
	}

	private void getData() {
		Byte[] bytes = new Byte[1024]; 

	socketConnection = new TcpClient (ip, port); 
	using (TCPStatic.Source.stream1 = socketConnection.GetStream ()) { 

						
		int length = TCPStatic.Source.stream1.Read (bytes, 0, bytes.Length);
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


				/*Geographic geo = new Geographic(Lon_dec_deg, Lat_dec_deg);
				MGRS mgrs  = (MGRS)geo;
				double eastM = mgrs.East;
				double northM = mgrs.North;
				int zoneM = mgrs.Zone;
				string bandM = mgrs.Band;
				string gridM = mgrs.Grid;
				string MgrsString = zoneM.ToString() + bandM + " " + gridM + " " + eastM.ToString() + " " + northM.ToString();
				*/
				Debug.Log ("2Lat: " + Lat.ToString () + "\nLon: " + Lon.ToString () + "\n" + Alt.ToString ("0.0") + "MSL");



				double sourceLon = TCPStatic.Source.lon;
				double sourceLat = TCPStatic.Source.lat;
				double sourceAlt = TCPStatic.Source.alt;



				Debug.Log ("3Lat: " + sourceLat.ToString () + "\nLon: " + sourceLon.ToString () + "\n" + sourceAlt.ToString ("0.0") + "MSL");

				double b = 0;

				if (sourceLon != 0 && sourceLat != 0) {
					b = bearing (sourceLon, sourceLat, Lon, Lat);
				}

				gameObject.GetComponent<TextMesh> ().text = "Bearing: " + b.ToString ("0");
			}

		} 	 

	}

	private double bearing(double lon1, double lat1, double lon2, double lat2) {
		double x = Math.Cos(ConvertToRadians (lat2)) * Math.Sin (ConvertToRadians (lon2) - ConvertToRadians (lon1));
		double y = Math.Cos(ConvertToRadians (lat1)) * Math.Sin (ConvertToRadians (lat2)) - Math.Sin (ConvertToRadians (lat1))* Math.Cos(ConvertToRadians (lat2))* Math.Cos(ConvertToRadians (lon2) - ConvertToRadians (lon1) );
		double bearing = RadianToDegree(Math.Atan2 (x, y));

		//To make bearing 360 degrees, add: IF bearing < 0 then bearing = 360 - bearing. That converts -179 to 181, -90 to 270, etc.
		if (bearing < 0) {
			bearing = 360 - bearing;
		}


		return bearing;
	}

	private double distance(double lon1, double lat1, double lon2, double lat2) {

		double a = Math.Pow((Math.Sin (Math.Abs (lat2 - lat1)) * Math.PI / 180 / 2), 2) + Math.Cos (lat1 * Math.PI / 180) * Math.Sin (Math.Abs (lon2 - lon1) * Math.PI / 180 / 2);
		double b = 2 * Math.Atan2 (Math.Sqrt (1 - a), Math.Sqrt (a));
		return b * 6371000;
	}


	/*private IEnumerator waitt(float waitTime) {
		print ("Started waiting " + Time.time);
		yield return new 
		print ("Finished Execution " + Time.time);
	}*/


	public double ConvertToRadians(double angle)
	{
		return (Math.PI / 180) * angle;
	}

	private double RadianToDegree(double angle)
	{
		return angle * (180.0 / Math.PI);
	}

	


}
