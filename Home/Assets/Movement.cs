using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	public float movementSpeed;
	public float lookSpeed;
	public float maxAngle;
	public float minAngle;

	private CharacterController charCont;
	private AudioSource audSour;
	private Vector3 currentMove;
	private float xDir;
	private float zDir;
	private bool inputValid;
	private Camera cam;

	// Use this for initialization
	void Start () {

		cam = GetComponentInChildren<Camera> ();
		audSour = GetComponentInChildren<AudioSource> ();
		charCont = GameObject.FindGameObjectWithTag ("Player").GetComponent<CharacterController>();
		xDir = 0.0f;
		zDir = 0.0f;
		currentMove = Vector3.zero;
		inputValid = true;

	}
	
	// Update is called once per frame
	void Update () {
	
		if (inputValid) {
			getInput ();
		}

	}

	void getInput() {


		xDir = Input.GetAxis ("Horizontal");
		zDir = Input.GetAxis ("Vertical");

		if (xDir == 0.0f && zDir == 0.0f) {
			audSour.enabled = false;
		} else {
			audSour.enabled = true;
		}

		//move
		currentMove = new Vector3(Input.GetAxis ("Horizontal"), 0.0f, Input.GetAxis ("Vertical"));
		currentMove = transform.TransformDirection (currentMove);
		currentMove *= movementSpeed * Time.deltaTime;
		charCont.SimpleMove (currentMove);

		//rotate
		transform.Rotate (new Vector3 (0.0f, Input.GetAxis ("RightHorizontal")*lookSpeed*Time.deltaTime, 0.0f));
		cam.transform.Rotate (new Vector3 (Input.GetAxis ("RightVertical") * lookSpeed * Time.deltaTime, 0.0f, 0.0f));

		Debug.Log (cam.transform.localRotation);
	}

	bool getInputValid() {

		return this.inputValid;
	}

	void setInputValid(bool inState){
		this.inputValid = inState;
	}
	
}
