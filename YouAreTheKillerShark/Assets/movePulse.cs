using UnityEngine;
using System.Collections;

public class movePulse : MonoBehaviour {

	public float swimForce;
	public float minPause;
	public float maxPause;
	public float minY;
	public float maxY;
	private Vector2 direction;
	private float yDiff;
	private float pulseTime;
	private float timeDiff;
	private Rigidbody2D body;
	
	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody2D>();

		yDiff = Mathf.Abs(maxY-minY);
		timeDiff = Mathf.Abs(maxPause-minPause);
		
		int negative;
		if(Random.value<0.5f){
			negative = -1;
		}else{
			negative = 1;
		}
		
		float x = 18.0f*(float)negative;
		float y = yDiff*Random.value + minY;
		
		transform.position = new Vector3(x, y);
		Debug.Log (transform.position);
		
		if(transform.position.x>0){
			direction = new Vector2(-1.0f*swimForce, 0.0f);
			transform.RotateAround(transform.position, Vector3.forward, 180.0f);
			Debug.Log ("now = "+transform.position);
		}
		else{
			direction = new Vector2(1.0f*swimForce, 0.0f);
		}

		
	}
	
	// Update is called once per frame
	void Update () {

		pulseTime-=Time.deltaTime;

		if(pulseTime<0.0f){
			body.AddRelativeForce(new Vector2(swimForce, 0.0f));
			resetTimer();
		}
		
		//transform.position+=new Vector3(direction.x, direction.y);

		Debug.Log ("position = "+Mathf.Abs(transform.position.x));
		if(Mathf.Abs(transform.position.x)>20.0f)
			Destroy(gameObject);
	}

	public void resetTimer(){
		pulseTime = timeDiff*Random.value + minPause;
	}
}
