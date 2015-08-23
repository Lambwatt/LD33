using UnityEngine;
using System.Collections;

public class moveConstantFromStart : MonoBehaviour {


	private Vector2 direction;
	private float yDiff;
	private Rigidbody2D body;

	// Use this for initialization
	void Awake () {

		ManageGame.onStartGame+=die;
		
		body = GetComponent<Rigidbody2D>();

	}

	public void setVelocity(Vector2 vel){
		Debug.Log(vel);
		Debug.Log(body);
		body.velocity = vel;
	}
	
	// Update is called once per frame
	void Update () {
		if(Mathf.Abs(transform.position.x)>17.6f)
			Destroy(gameObject);
	}

	public void die(){
		//ManageGame.onStartGame-=die;
		Destroy(gameObject);
	}
	
	public void OnDestroy(){
		ManageGame.onStartGame-=die;
	}
}
