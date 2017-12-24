using TCP.TCPConnection;
using TCP.TPCMember;
using UnityEngine;
using Parse;

namespace TCP
{
	public class TCPSource : TCPMember {    
		
		public TCPSource() {
			ip = "192.168.1.137";
		}

		void Start () {
			TCPConnect tcpConn = gameObject.AddComponent(typeof(TCP.TCPConnection.TCPConnect)) as TCP.TCPConnection.TCPConnect;
			tcpConn.callBack = FoundData;
			tcpConn.serverIP = ip;
			tcpConn.serverPort = port;
			tcpConn.ListenForData ();
		}


		public string FoundData(string data) {
			Debug.Log ("Source Data: " + data);
			coords = Parse.ParseGpsData.ParseNmeaToLonLat (data, nmea);
			if (coords != null) {
				//Debug.Log("Source Coords");
			}
			return data;

		}

	}

}