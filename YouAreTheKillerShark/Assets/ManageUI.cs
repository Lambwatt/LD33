using UnityEngine;
using System.Collections;

public class ManageUI : MonoBehaviour {

	CanvasGroup group;

	// Use this for initialization
	void Start () {
		group = GetComponent<CanvasGroup>();

		ManageGame.onEndGame+=HideUI;
		ManageGame.onStartGame+=ShowUI;
	}

	void ShowUI(){
		group.alpha = 1;
		group.interactable = true;
		group.blocksRaycasts = true;
	}
	
	void HideUI(){
		group.alpha = 0;
		group.interactable = false;
		group.blocksRaycasts = false;
	}
}
