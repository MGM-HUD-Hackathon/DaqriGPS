
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
	//Thread mainThread;
	// Use this for initialization 	
	void Start () {
		//mainThread = System.Threading.Thread.CurrentThread;

		Debug.Log ("In the Connect method");
		ConnectToTcpServer();     
	}  	
	// Update is called once per frame
	void Update () {      


		/*if (Input.GetKeyDown(KeyCode.Space)) {             
			SendMessage();         
		} */    
	}  	
	/// <summary> 	
	/// Setup socket connection. 	
	/// </summary> 	
	private void ConnectToTcpServer () { 		
		/*try {  			
			clientReceiveThread = new Thread (new ThreadStart(ListenForData)); 			
			clientReceiveThread.IsBackground = true; 			
			clientReceiveThread.Start();  		
		} 		
		catch (Exception e) { 			
			Debug.Log("On client connect exception " + e); 		
		} */


		print("Starting " + Time.time);

		// Start function WaitAndPrint as a coroutine.

		coroutine = ListenForData(1.0f);
		StartCoroutine(coroutine);

		//print("Before WaitAndPrint Finishes " + Time.time);



	}  	
	/// <summary> 	
	/// Runs in background clientReceiveThread; Listens for incomming data. 	
	/// </summary>     
	private IEnumerator ListenForData(float waitTime) { 		
		while (true) {
			
			try { 			
				socketConnection = new TcpClient ("10.10.46.52", 4352);  			
				Byte[] bytes = new Byte[1024];             
				//while (true) { 				
				// Get a stream object for reading 				
				using (NetworkStream stream = socketConnection.GetStream ()) { 					
					//int length; 					
					// Read incomming stream into byte arrary. 	
					int length = stream.Read (bytes, 0, bytes.Length);
					int i = 10;
					while (i>0) {
						i--;
						var incommingData = new byte[length]; 						
						Array.Copy (bytes, 0, incommingData, 0, length); 						
						// Convert byte array to string message. 						
						string serverMessage = Encoding.ASCII.GetString (incommingData); 	

						Debug.Log(serverMessage);

						string[] srvrMsgs = serverMessage.Split (',');

						//Debug.Log(srvrMsgs[0]);
						//Debug.Log(srvrMsgs[0]);

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

							//Debug.Log(Lat);

							gameObject.GetComponent<TextMesh>().text = "Lat: " + Lat.ToString() + "\nLon: " + Long1.ToString();

						}
						



							//GameObject.FindGameObjectsWithTag

							//gameObject 
							//GetComponent<Text>()
							//System.Threading.
							/*WSAApplication.InvokeOnAppThread(()=>
								{
								//Debug.Log(gameObject.name);

								}
							);//*/
							/*Text test = gameObject.GetComponent<Text>();

							test.text = " Testing!";*/




							//UnityMainThreadDispatcher.Instance().Enqueue(ThisWillBeExecutedOnTheMainThread());
							//ExecuteOnMain();

							/*DoOnMainThread.ExecuteOnMainThread.Enqueue(() => {  
								StartCoroutine("Test"); 
							});//*/
						




					} 				
				} 			
				//}         
			} catch (SocketException socketException) {             
				Debug.Log ("Socket exception: " + socketException);         
			}  

			yield return new WaitForSeconds (waitTime);
			print ("WaitAndPrint " + Time.time);
		}
	}  	
	/// <summary> 	
	/// Send message to server using socket connection. 	
	/// </summary> 	
	private void SendMessage() {         
		if (socketConnection == null) {             
			return;         
		}  		
		try { 			
			// Get a stream object for writing. 			
			NetworkStream stream = socketConnection.GetStream(); 			
			if (stream.CanWrite) {                 
				string clientMessage = "This is a message from one of your clients."; 				
				// Convert string message to byte array.                 
				byte[] clientMessageAsByteArray = Encoding.ASCII.GetBytes(clientMessage); 				
				// Write byte array to socketConnection stream.                 
				stream.Write(clientMessageAsByteArray, 0, clientMessageAsByteArray.Length);                 
				Debug.Log("Client sent his message - should be received by server");             
			}         
		} 		
		catch (SocketException socketException) {             
			Debug.Log("Socket exception: " + socketException);         
		}     
	} 

	public static void ExecuteOnMain() {
		//Debug.Log ();

	}


	/*public IEnumerator ThisWillBeExecutedOnTheMainThread() {
		Debug.Log ("This is executed from the main thread");
		yield return null;
	}*/
}