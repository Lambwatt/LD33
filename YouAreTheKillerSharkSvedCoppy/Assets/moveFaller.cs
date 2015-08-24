using UnityEngine;
using System.Collections;

public class moveFaller : MonoBehaviour {
	

	
	// Use this for initialization
	void Start () {
		ManageGame.onStartGame+=die;


	}
	
	// Update is called once per frame
	void Update () {

		if(Mathf.Abs(transform.position.x)>17.6f || transform.position.y<-5)
			die();
	}
	

	public void die(){
		//ManageGame.onStartGame-=die;
		Destroy(gameObject);
	}
	
	public void OnDestroy(){
		ManageGame.onStartGame-=die;
	}
}
