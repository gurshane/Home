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
	private GameObject hand;
	private float totalRotation;
	private float deltaRotation;
	// Use this for initialization
	void Start () {

		hand = GameObject.FindGameObjectWithTag ("hand");
		cam = GetComponentInChildren<Camera> ();
		audSour = GetComponentInChildren<AudioSource> ();
		charCont = GameObject.FindGameObjectWithTag ("Player").GetComponent<CharacterController>();
		xDir = 0.0f;
		zDir = 0.0f;
		currentMove = Vector3.zero;
		inputValid = true;
		totalRotation = 0.0f;
		deltaRotation = 0.0f;

	}
	
	// Update is called once per frame
	void Update () {
	
		if (inputValid) {
			getInput ();
		}

	}

	void getInput() {

		//Get changes in x and z
		xDir = Input.GetAxis ("Horizontal");
		zDir = Input.GetAxis ("Vertical");

		//if the player is pushing on the left stick play walking sound
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

		//Get the change in rotation and then check if accepting this change will be inside/outside the allowed viewing angle by allowing only so much total change to happen from the rest position
		deltaRotation = Input.GetAxis ("RightVertical") * lookSpeed * Time.deltaTime;

		if (((deltaRotation + totalRotation) < maxAngle) && ((deltaRotation + totalRotation) > minAngle)) {
			totalRotation += deltaRotation;
			cam.transform.Rotate (new Vector3 (Input.GetAxis ("RightVertical") * lookSpeed * Time.deltaTime, 0.0f, 0.0f));

		}

	}

	bool getInputValid() {

		return this.inputValid;
	}

	void setInputValid(bool inState){
		this.inputValid = inState;
	}

}
