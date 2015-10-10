using UnityEngine;
using System.Collections;

public class DoorBehaviour : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void open() {
		Debug.Log ("dfdsfds");
		transform.Rotate (new Vector3 (0.0f, 23.0f, 0.0f));
	}
}
