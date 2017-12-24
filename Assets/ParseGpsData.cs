using System;
using GPS;
using UnityEngine;

namespace Parse
{
	public class ParseGpsData
	{
		public ParseGpsData ()
		{
		}
		//http://gpsworld.com/what-exactly-is-gps-nmea-data/

		static public GPS.Coordinates ParseNmeaToLonLat(string nmeaData, string nmeaType) {

			GPS.Coordinates coords = new GPS.Coordinates ();

			string[] srvrMsgs = nmeaData.Split (',');

			if (srvrMsgs [0] == nmeaType) {

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

				coords.lat = Lat_deg + Lat_minute;//32.378306
				coords.lon = Lon_deg + Lon_minute;//86.310071

				//Debug.Log("Lat_dec_deg: " + Lat_dec_deg);
				//Debug.Log("Lon_dec_deg: " + Lon_dec_deg);

				if (srvrMsgs [3] == "S") {
					coords.lat = coords.lat * -1;
				}

				if (srvrMsgs [5] == "W") {
					coords.lon = coords.lon * -1;
				}

				coords.alt = Alt;
				
				//Debug.Log ("Lat: " + Lat.ToString () + "\nLon: " + Lon.ToString () + "\n" + Alt.ToString ("0.0") + "MSL");
		
				//gameObject.GetComponent<TextMesh> ().text = "Lat: " + Lat.ToString () + "\nLon: " + Lon.ToString () + "\n" + Alt.ToString ("0.0") + "MSL";

				return coords;
			}

			return null;
		}
	}
}


