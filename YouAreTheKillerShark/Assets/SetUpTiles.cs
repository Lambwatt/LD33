using UnityEngine;
using System.Collections;

public class SetUpTiles : MonoBehaviour {

	// Use this for initialization
	void Start () {
		float step = 3.2f;
		float vStep = - 3.2f;
		int numTiles = 11;
		int numVerticalTiles = 4;
		float initialX = -15.5f;
		float initialY = 3.5f-3.2f;

		for(int i = 0; i<numTiles; i++){
			Instantiate(Resources.Load("tile_ground"), new Vector3(initialX+((float)i*step), -7.25f), Quaternion.identity);
		}

		for(int i = 0; i<numTiles; i++){
			Instantiate(Resources.Load("tile_water_top"), new Vector3(initialX+((float)i*step), 3.5f), Quaternion.identity);
		}

		for(int i = 0; i<numTiles; i++){
			for(int j = 0; j<numVerticalTiles; j++){
				Instantiate(Resources.Load("tile_water"), new Vector3(initialX+((float)i*step), initialY+(vStep*(float)j)), Quaternion.identity);
			}
		}
	}
	

}
