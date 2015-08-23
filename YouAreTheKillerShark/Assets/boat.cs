using UnityEngine;
using System.Collections;

public class boat : MonoBehaviour {

	public float oddsAgainst;
	public float lead;
//	public float shotSpeed;
	private Rigidbody2D body;
	//private int signOfVelocity;
	
	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		

			
		float chance = Random.value*oddsAgainst;
		if(chance<1){
//			Debug.Log ("Fire");
//			Debug.Log ("projectile x = "+transform.position.x+(lead*transform.localScale.x));
			/*GameObject projectile = */Instantiate(Resources.Load ("fallingHarpoon"), new Vector3(transform.position.x, transform.position.y-lead), Quaternion.identity);// as GameObject;
			//projectile.GetComponent<moveConstantFromStart>().setVelocity(new Vector2(shotSpeed*(body.velocity.x/Mathf.Abs(body.velocity.x)), 0.0f));
		}

	}
}
