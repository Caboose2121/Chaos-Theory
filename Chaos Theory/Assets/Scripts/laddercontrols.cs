using UnityEngine;
using System.Collections;
public class laddercontrols : MonoBehaviour 
{
	public GameObject ladderExitCollider;
	public GameObject player;
	public bool canClimbLadder = false;
	public bool onLadder = false;

	void OnTriggerEnter (Collider other)
	{
		if (CompareTag ("Player"))
		{
			canClimbLadder = true;
		}
	}

	void OnTriggerStay ()
	{
		if (Input.GetKeyDown ("e") && (canClimbLadder = true))
			{
			onLadder = true;
			player.GetComponent<FirstPersonController> ().enabled = false;
			}

		if (Input.GetKey ("w") && (onLadder = true))
		{
			player.transform.Translate (0, 0.25f, 0);
		}

		if (Input.GetKey ("s") && (onLadder = true))
		{
			player.transform.Translate (0, -0.25f, 0);
		}
	}
}
