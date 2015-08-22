using UnityEngine;
using System.Collections;

public class MoveShark : MonoBehaviour {

	public int rotConstant;
	public float swimForce;
	private Rigidbody2D body;

	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

		//Debug.Log ("updated");

		if(Input.GetKey(KeyCode.A)){
			transform.RotateAround(transform.position, Vector3.forward, rotConstant*Time.deltaTime);
			//Debug.Log ("rotated left");
		}

		if(Input.GetKey(KeyCode.D)){
			transform.RotateAround(transform.position, Vector3.forward, -rotConstant*Time.deltaTime);
			//Debug.Log ("rotated right");
		}

		if(Input.GetKeyDown(KeyCode.Space)){
			body.AddRelativeForce(new Vector2(500.0f, 0.0f));
		}

	}
}
