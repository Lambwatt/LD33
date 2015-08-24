using UnityEngine;
using System.Collections;

public class FadeoutAndDie : MonoBehaviour {

	float initialY;
	// Use this for initialization
	void Start () {
		initialY = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(transform.position.x, transform.position.y+0.04f);
		if(transform.position.y-initialY>1){
			Destroy(gameObject);
		}
	}
}
