using UnityEngine;
using System.Collections;

public class ManageGame : MonoBehaviour {

	public delegate void StartAction();
	public static event StartAction onStartGame;

	public delegate void EndAction();
	public static event EndAction onEndGame;

	private static bool gameInProgress = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}



	public static void startGame(){
		Debug.Log ("Game in progress?"+gameInProgress);
		if(!gameInProgress){
			gameInProgress = true;
			Instantiate(Resources.Load("sharkOuter"),new Vector3(0.0f, 0.0f), Quaternion.identity);
			onStartGame();
		}
	}
	
	public static void endGame(){
		gameInProgress = false;
		onEndGame();
		//Instantiate(Resources.Load("sharkOuter"),Vector3(0.0f, 0.0f), Quaternion.identity);
	}

}
