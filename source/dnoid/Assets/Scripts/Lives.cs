using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lives : MonoBehaviour {
	public static bool livesRemaining = true;
	public static int numberLives;
	static Lives instance = null;
	public int BaseLives;
	void Start(){
		numberLives = BaseLives;
	}
	
	void Awake () {
		if (instance != null){
			Destroy(gameObject);
		}else{
			instance = this;
			GameObject.DontDestroyOnLoad(gameObject);
		}
	}
	
	public void Reset(){
		livesRemaining = true;
		numberLives = BaseLives;
	}
	
	void Update(){
		if(numberLives<=0){
			livesRemaining = false;
		}
	}
	
	
}