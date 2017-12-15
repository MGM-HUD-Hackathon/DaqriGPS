using System.Threading;
using UnityEngine;
using System;
using System.Collections.Generic;

public class DoOnMainThread : MonoBehaviour {

	public readonly static Queue<Action> ExecuteOnMainThread = new Queue<Action>();

	public void Update()
	{
		// dispatch stuff on main thread
		while (ExecuteOnMainThread.Count > 0)
		{
			ExecuteOnMainThread.Dequeue().Invoke();
		}
	}
}

