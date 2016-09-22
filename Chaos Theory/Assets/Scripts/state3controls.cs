using UnityEngine;
using System.Collections;

public class state3controls : MonoBehaviour 
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
		if (Input.GetKeyDown ("1") && (inCollider = true)) 
		{
			Player.transform.Translate(0, -100, 0, Space.World);
		}

		if (Input.GetKeyDown ("2") && (inCollider = true)) 
		{
			Player.transform.Translate(0, -50, 0, Space.World);
		}
	}
}