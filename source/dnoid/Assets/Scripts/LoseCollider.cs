using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {

	private LevelManager levelManager;
	private Brick brick;
	private Lives lives;
	
	void Start(){
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		brick = GameObject.FindObjectOfType<Brick>();
		lives = GameObject.FindObjectOfType<Lives>();
	}
	
	void OnTriggerEnter2D(Collider2D trigger){
		Lives.numberLives--;
		levelManager.LifeLost();
	}
}
