using UnityEngine;
using System.Collections;

public class laddercontrols : MonoBehaviour 
{
	//put this on the collider for the ladder, not the model itself

	public bool inLadderCollider = false;
	public GameObject Player; 


	void OnTriggerEnter (Collider other) 
	{
		if (CompareTag ("Player")) 
		{
			inLadderCollider = true;
		}
	}
	


	void OnTriggerStay (Collider other)
	{
		if (Input.GetKeyDown ("E") && (inLadderCollider = true))
			{
			Player.transform.Translate (0, 1, 0, Space.World);
			}
	}
}
