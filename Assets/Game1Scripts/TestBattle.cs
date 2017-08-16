using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestBattle : MonoBehaviour {

	public Image enemyHealthBar;
	public float damage = 0.2f;
	public GameObject playerMonster;
	public GameObject enemyMonster;

	bool endTurn = false;

	void Start(){
		endTurn = false;
		playerMonster = GameObject.Find("PlayerMonster");
		enemyMonster = GameObject.Find("EnemyMonster");
		StartCoroutine("SimulateBattle");
	}

	void Update(){
		if(Input.GetKeyDown(KeyCode.Space)){
			endTurn = true;
		}
	}

	IEnumerator SimulateBattle(){
		Debug.Log("Battle Start");
		int turnCount = 0;
		while(enabled){
			turnCount++;
			Debug.Log("Round " + turnCount);
			yield return StartCoroutine("PlayerTurn");
		}
	}
	IEnumerator PlayerTurn(){
		endTurn = false;
		while(!endTurn){
			yield return new WaitForEndOfFrame();
		}
		Debug.Log("Player Did a Thing");
		yield return StartCoroutine("EnemyTurn");
	}
	

	IEnumerator EnemyTurn(){
		endTurn = false;
		while(!endTurn){
			yield return new WaitForEndOfFrame();
		}
		Debug.Log("Enemy Did a Thing");
		yield return new WaitForEndOfFrame();
	}
}
