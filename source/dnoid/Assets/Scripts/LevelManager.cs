using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
	private Brick brick;
	private Ball ball;
	private Lives lives;
	
	void Start(){
		brick = GameObject.FindObjectOfType<Brick>();
		ball = GameObject.FindObjectOfType<Ball>();
		lives = GameObject.FindObjectOfType<Lives>();
	}

	public void LoadLevel(string name){
		Debug.Log("Level load requested for: " + name);
		Application.LoadLevel(name);
		Brick.breakableCount = 0;
	}
	
	public void QuitRequest(){
		Debug.Log("Quit requested.");
		Application.Quit();
	}
	
	public void LoadNextLevel(){
		Application.LoadLevel(Application.loadedLevel + 1);
		Brick.breakableCount = 0;
	}
	
	public void BrickDestroyed(){
		if (Brick.breakableCount <= 0){
			LoadNextLevel();
		}
	}
	
	public void LifeLost(){
		if (Lives.livesRemaining){
			ball.resetBallLifeLost();
		} else {
			LoadLevel("Lose");
			lives.Reset();
		}
	}

}
