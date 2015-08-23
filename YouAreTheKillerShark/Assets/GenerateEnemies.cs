using UnityEngine;
using System.Collections;
using System.Timers;

public class GenerateEnemies : MonoBehaviour {
	
	private string[] spawnables = new string[5]{"fish","hazard","pulseFish","pulseHazard","bounceFish"};
	private float spawnTime;
	private bool on;

	void Start () {
		on = true;
		resetTimer();
//
//		ManageGame.onStartGame+=turnOn;
//		ManageGame.onEndGame+=turnOff;
	}
	
	// Update is called once per frame
	void Update () {

		if(!on) return;
		
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
		//Debug.Log (spawnables.Length);
		int index = (int)Mathf.Floor (Random.value*(float)spawnables.Length);
		Instantiate(Resources.Load(spawnables[index]), new Vector3(-16.5f, -16.5f), Quaternion.identity);
	}

	public void turnOn(){
		on = true;
	}

}
