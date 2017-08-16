using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBattleTwo : MonoBehaviour {

	List<GameObject> battleList = new List<GameObject>();
	int activeCharacter = 0;

	void Start(){
		GameObject[] playerObjects;
		GameObject[] enemyObjects;
		playerObjects = GameObject.FindGameObjectsWithTag("Player");
		enemyObjects = GameObject.FindGameObjectsWithTag("Enemy");

		battleList.AddRange(playerObjects);
		battleList.AddRange(enemyObjects);

		battleList.Sort(SpeedSort);
		SetTurnActive(true);
		//Debug.Log("Hello world: " + battleList[0] + battleList[1] + battleList[2]);
		//PrintBattleList();
	}

	void Update(){
		NextTurn();
	}

	int SpeedSort(GameObject one, GameObject two){
		if(one.GetComponent<Character>().characterSheet.characterClass.speed > two.GetComponent<Character>().characterSheet.characterClass.speed)
			return -1;
		return 1;
	}

	void PrintBattleList(){
		for(int i = 0; i < battleList.Count; i++){
			Debug.Log(battleList[i]);
		}
	}

	void NextTurn(){
		if(battleList[activeCharacter].GetComponent<Character>().characterSheet.characterClass.turnActive){
			Debug.Log(battleList[activeCharacter] + "\'s turn");
			if(Input.GetKeyDown(KeyCode.Space)){
				battleList[activeCharacter].GetComponent<Character>().characterSheet.characterClass.turnActive = false;
				activeCharacter++;
				if(activeCharacter >= battleList.Count){
					SetTurnActive(true);
					activeCharacter = 0;
				}
			}
		}
	}

	void SetTurnActive(bool activeState){
		for(int i = 0; i < battleList.Count; i++){
			battleList[i].GetComponent<Character>().characterSheet.characterClass.turnActive = activeState;
		}
	}

}
