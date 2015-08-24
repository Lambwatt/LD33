using UnityEngine;
using System.Collections;

public class moveBounce : MonoBehaviour {

	public float swimForce;
	public float minPause;
	public float maxPause;
	public float minY;
	public float maxY;
	public float highGravity;
	public float lowGravity;
	public float distFromCentre;
	public float deathPoint;
	private Vector2 direction;
	private float yDiff;
	private float pulseTime;
	private float timeDiff;
	private Rigidbody2D body;
	
	// Use this for initialization
	void Start () {
		ManageGame.onStartGame+=die;
		
		body = GetComponent<Rigidbody2D>();
		body.gravityScale = lowGravity;
		
		yDiff = Mathf.Abs(maxY-minY);
		timeDiff = Mathf.Abs(maxPause-minPause);
		
		int negative;
		if(Random.value<0.5f){
			negative = -1;
		}else{
			negative = 1;
		}
		
		float x = distFromCentre*(float)negative;
		float y = yDiff*Random.value + minY;
		
		transform.position = new Vector3(x, y);
		//		Debug.Log (transform.position);
		
		if(transform.position.x>0){
			//direction = new Vector2(-1.0f*swimForce, 0.0f);
			transform.RotateAround(transform.position, Vector3.down, 180.0f);
			//Debug.Log ("now = "+transform.position);
		}
		//else{
	//		direction = new Vector2(1.0f*swimForce, 0.0f);
	//	}
		
		
	}
	
	// Update is called once per frame
	void Update () {

		if(transform.position.y>4.5){
			body.gravityScale = highGravity;
		}else{
			body.gravityScale = lowGravity;
		}
		
		pulseTime-=Time.deltaTime;
		
		if(pulseTime<0.0f){
			body.AddRelativeForce(new Vector2(swimForce, swimForce));
			resetTimer();
		}
		
		//transform.position+=new Vector3(direction.x, direction.y);
		
		//Debug.Log ("position = "+Mathf.Abs(transform.position.x));
		if(Mathf.Abs(transform.position.x)>deathPoint)
			die();
	}
	
	public void resetTimer(){
		pulseTime = timeDiff*Random.value + minPause;
	}
	
	public void die(){
		//ManageGame.onStartGame-=die;
		Destroy(gameObject);
	}
	
	public void OnDestroy(){
		ManageGame.onStartGame-=die;
	}
}

