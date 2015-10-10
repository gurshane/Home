using UnityEngine;
using System.Collections;

public class HandActions : MonoBehaviour {


	void OnCollisionEnter(Collision other) {

		Debug.Log ("dfsdfds");
		switch (other.gameObject.tag) {

		case "door":
			Debug.Log("butts");
				other.gameObject.GetComponent<DoorBehaviour>().open();
				break;

		default:
				break;

		}

	}






}
