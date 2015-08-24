using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	CanvasGroup group;
	// Use this for initialization
	void Start () {
		group = GetComponent<CanvasGroup>();

		ManageGame.onEndGame+=ShowMenu;
		ManageGame.onStartGame+=HideMenu;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space)){
			ManageGame.startGame();
		}
	}

	void ShowMenu(){
		group.alpha = 1;
		group.interactable = true;
		group.blocksRaycasts = true;
	}

	void HideMenu(){
		group.alpha = 0;
		group.interactable = false;
		group.blocksRaycasts = false;
	}
}
