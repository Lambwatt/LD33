using UnityEngine;
using System.Collections;
using System.Timers;

public class GenerateEnemies : MonoBehaviour {

	// Use this for initialization
	private string[] spawnables = new string[2]{"fish","hazard"};
	//private Timer timer;
	private float spawnTime;// = (Random.value*1000.0f)+1000.0f;

	void Start () {
		resetTimer();
		//timer = new Timer(/*(Random.value*1000.0)+*/1000.0);
		//timer.Elapsed+=(object sender, System.Timers.ElapsedEventArgs e) => {Debug.Log ("hello?"); generate();};
	}
	
	// Update is called once per frame
	void Update () {

		spawnTime-=Time.deltaTime;

		//Debug.Log(spawnTime);
		if(spawnTime<0.0f){
			generate();
			resetTimer();
		}

	}

	public void resetTimer(){
		spawnTime = (Random.value)+1.0f;
	}

	public void generate(){
	
		int index = (int)Mathf.Floor (Random.value*2f);
		Instantiate(Resources.Load(spawnables[index]), new Vector3(-18.0f, -18.0f), Quaternion.identity);
	}

}
