using UnityEngine;
using System.Collections;

public class MoveShark : MonoBehaviour {

	public int rotConstant;
	public float swimForce;
	public float gravity;
	private Rigidbody2D body;
	private Animator animator;

	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody2D>();
		animator = GetComponentInChildren<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

		//Debug.Log ("updated");
		if(transform.position.y>4.5){
			body.gravityScale = gravity;
		}else{
			body.gravityScale = 0;
		}

		if(Input.GetKey(KeyCode.A)){
			transform.RotateAround(transform.position, Vector3.forward, rotConstant*Time.deltaTime);
			//Debug.Log ("rotated left");
		}

		if(Input.GetKey(KeyCode.D)){
			transform.RotateAround(transform.position, Vector3.forward, -rotConstant*Time.deltaTime);
			//Debug.Log ("rotated right");
		}

		if(Input.GetKeyDown(KeyCode.Space)){
			body.AddRelativeForce(new Vector2(swimForce, 0.0f));
			animator.SetTrigger("swim");
		}

	}
}
