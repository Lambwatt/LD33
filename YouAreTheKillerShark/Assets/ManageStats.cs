using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ManageStats : MonoBehaviour {
	
	public float totalEnergy;
	public float lossToSwim;

	public float totalOxygen;
	public float oxygenLossPerFrame;

	private float currentEnergy;
	private GameObject energyBar;
	private float maxWidth;
	
	private float currentOxygen;
	private GameObject oxygenBar;

	// Use this for initialization
	void Start () {
		energyBar = GameObject.FindGameObjectWithTag("energy");
		oxygenBar = GameObject.FindGameObjectWithTag("oxygen");
		
		maxWidth = energyBar.transform.localScale.x;

		MoveShark.onSwim+=spendEnergy;
		MoveShark.onEat+=addEnergy;
		MoveShark.onGetHit+=deductEnergy;

		ManageGame.onStartGame+=resetStats;

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void spendEnergy(){
		currentEnergy-=lossToSwim;

		if(currentEnergy<=0.0f){
			currentEnergy = 0.0f;
			ManageGame.endGame();
		}

		energyBar.transform.localScale = new Vector3(maxWidth*(currentEnergy/totalEnergy), energyBar.transform.localScale.y);

	}

	private void deductEnergy(float energy){
		currentEnergy-=energy;
		
		if(currentEnergy<=0.0f){
			currentEnergy = 0.0f;
			ManageGame.endGame();
		}
		
		energyBar.transform.localScale = new Vector3(maxWidth*(currentEnergy/totalEnergy), energyBar.transform.localScale.y);
		
	}

	private void addEnergy(float energy){
		currentEnergy+=energy;

		if(currentEnergy>totalEnergy){
			//Debug.Log ("Energy = "+currentEnergy)
			currentEnergy = totalEnergy;
			//ManageGame.endGame();
		}

		energyBar.transform.localScale = new Vector3(maxWidth*(currentEnergy/totalEnergy), energyBar.transform.localScale.y);

	}

	private void resetStats(){
		currentEnergy = totalEnergy;
		currentOxygen = totalOxygen;
	}
}
