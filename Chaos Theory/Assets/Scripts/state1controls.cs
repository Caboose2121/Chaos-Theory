using UnityEngine;
using System.Collections;

public class state1controls : MonoBehaviour 
{
	public bool inCollider = false;
	public GameObject Player;


	void OnTriggerEnter (Collider other)
	{
		if (CompareTag ("Player")) 
		{
			inCollider = true;
		}
	}

	void OnTriggerStay (Collider other)
	{
		if (Input.GetKeyDown ("2") && (inCollider = true)) 
		{
			Player.transform.Translate(0, 50, 0, Space.World);
		}

		if (Input.GetKeyDown ("3") && (inCollider = true)) 
		{
			Player.transform.Translate(0, 100, 0, Space.World);
		}
			
	}


}
