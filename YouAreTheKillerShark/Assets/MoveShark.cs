using UnityEngine;
using System.Collections;

public class MoveShark : MonoBehaviour {

	public int rotConstant;
	public float swimForce;
	public float gravity;
	private Rigidbody2D body;
	private Animator animator;
	private BoxCollider2D contact;

	//events
	public delegate void SwimAction();
	public static event SwimAction onSwim;

	public delegate void EatAction(float energy);
	public static event EatAction onEat;

	public delegate void HitAction(float energy);
	public static event HitAction onGetHit;
	
	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody2D>();
		animator = GetComponentInChildren<Animator>();
		contact = GetComponentInChildren<BoxCollider2D>();

		
		ManageGame.onEndGame+=die;
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
			onSwim();
		}

	}

	public void OnTriggerEnter2D(Collider2D other){

		if(other.gameObject.CompareTag("food")){
			onEat(other.gameObject.GetComponent<Values>().energy);
		}
//		if(other.gameObject.CompareTag("danger"))
//			Debug.Log ("ouch!");

		Destroy(other.gameObject);
	}

	public void OnCollisionEnter2D(Collision2D other){

		if(other.gameObject.CompareTag("danger"))
			onGetHit(other.gameObject.GetComponent<Values>().energy);
		
		Destroy(other.gameObject);
	}

	public void die(){
		//Debug.Log ("dead?");
		ManageGame.onEndGame-=die;
		Destroy(gameObject);
	}

}

