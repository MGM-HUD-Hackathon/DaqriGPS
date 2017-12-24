using System;
using UnityEngine;
using GPS;

namespace TCP
{
	namespace TPCMember
	{
		public class TCPMember : MonoBehaviour
		{
			public string ip = "";
			public int port = 4352;
			public string nmea = "$GPGGA";

			public GPS.Coordinates coords;

			public TCPMember ()
			{
			}
		}
	}
}

