using UnityEngine;
using System.Collections;
//using System.Timers;

public class moveConstant : MonoBehaviour {

	public float swimForce;
//	public float minFishPause;
//	public float maxFishPause;
	public float minY;
	public float maxY;
	public float distFromCentre;
	public float deathPoint;
	private Vector2 direction;
	private float yDiff;
	private Rigidbody2D body;

	// Use this for initialization
	void Start () {

		ManageGame.onStartGame+=die;

		body = GetComponent<Rigidbody2D>();

		yDiff = Mathf.Abs(maxY-minY);

		int negative;
		if(Random.value<0.5f){
			negative = -1;
		}else{
			negative = 1;
		}
		
		float x = distFromCentre*(float)negative;
		float y = yDiff*Random.value + minY;
		
		transform.position = new Vector3(x, y);

		if(transform.position.x>0){
			body.velocity = new Vector2(-1.0f*swimForce, 0.0f);
			transform.RotateAround(transform.position, Vector3.down, 180.0f);
		}else
			body.velocity = new Vector2(1.0f*swimForce, 0.0f);

	}


	
	// Update is called once per frame
	void Update () {

		//transform.position+=new Vector3(direction.x, direction.y);
		//body.velocity = 
		if(Mathf.Abs(transform.position.x)>deathPoint)
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
