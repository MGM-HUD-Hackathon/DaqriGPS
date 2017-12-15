using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace AssemblyCSharp
{
	public class GetGPSoverTCP
	{

		/*public GetGPSoverTCP () {
		}*/

		//UnicodeEncoding encod = new UnicodeEncoding();
		NetworkStream stm;
		byte[] pos;
		TcpClient tcp;
		byte[] kek;

		// Use this for initialization
		void Start() {
			Connect();
		}
		void Connect()
		{
			try{
				tcp = new TcpClient("127.0.0.1",445);
				tcp.Connect("127.0.0.1",445);
			}
			catch{
				//println("Caught error");
				//Connect ();

			}
		}


			// Update is called once per frame
			/*void Update()
			{
				stm = tcp.GetStream ();
				pos = encod.GetBytes(Convert.ToString(transform.position.x) + " " + Convert.ToString(transform.position.y) + " " + Convert.ToString(transform.position.z));
				stm.Write(pos,0,pos.Length);
				//stm.Read(kek,0,kek.Lenght);
				print(System.Text.Encoding.Unicode.ToString(kek));

			}*/
		}
		/*public GetGPSoverTCP ()
		{
			UnicodeEncoding encod = new UnicodeEncoding();
			TcpListener Listener = new TcpListener(IPAddress.Any, 445);
			TcpClient client;

			void StartAndAccept() {
				while (true) {
					Listener.Start();
					Listener.AcceptTcpClient();
					client = Listener.AcceptTcpClient();
					Stream(client);
					Thread.Sleep(0);
				}

			}

			static void Main(string[] args)
			{
				Program t = new Program();
				t.StartAndAccept();

			}
			public static void Stream(object client)
			{
				Program t = new Program();
				TcpClient client2 = (TcpClient)client;
				byte[] res = new byte[64];
				NetworkStream stream = client2.GetStream();
				stream.Read(res,0,res.Length);
				Console.WriteLine(System.Text.Encoding.Unicode.GetString(res));
				byte[] z = new byte[16]
					//stream.Write(z,0,z.Length);



					Thread.Sleep(0);
			}
		}*/
}

