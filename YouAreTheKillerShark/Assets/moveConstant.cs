using UnityEngine;
using System.Collections;
//using System.Timers;

public class moveConstant : MonoBehaviour {

	public float swimForce;
//	public float minFishPause;
//	public float maxFishPause;
	private Vector2 direction;
	//private Rigidbody2D body;
//	private Timer timer;


	// Use this for initialization
	void Start () {

		//Move all position selection to individual object.
		//Debug.Log("generated?");
		int negative;
		if(Random.value<0.5f){
			negative = -1;
		}else{
			negative = 1;
		}
		
		float x = 18.0f*(float)negative;
		float y = 9.0f*Random.value - 4.5f;//move this to the start of the object script 
		
		transform.position = new Vector3(x, y);

		if(transform.position.x>0)
			direction = new Vector2(-1.0f*swimForce, 0.0f);
		else
			direction = new Vector2(1.0f*swimForce, 0.0f);

	}
	
	// Update is called once per frame
	void Update () {

		transform.position+=new Vector3(direction.x, direction.y);
		if(Mathf.Abs(transform.position.x)>20.0f)
			Destroy(gameObject);
	}
}
