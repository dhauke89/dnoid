using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	private Paddle paddle;
	private bool hasStarted = false;
	private Vector3 paddleToBallVector;
	
	void Start(){
		paddle = GameObject.FindObjectOfType<Paddle>();
		paddleToBallVector = this.transform.position - paddle.transform.position;
	}
	

	
	void Update(){
		if (!hasStarted){
			//Lock the ball relative to the paddle.
			this.transform.position = paddle.transform.position + paddleToBallVector;
			//Wait for a mouse click to launch.
			if (Input.GetMouseButtonDown(0)){
				Debug.Log ("Mouse clicked, launching ball!");
				hasStarted = true;
				this.rigidbody2D.velocity = new Vector2(2f,10f);
			}
		}else{
			resetBall();
		}
	}
	
	public void resetBall(){
		if(hasStarted){
			if(Input.GetKeyDown(KeyCode.R)){
				this.transform.position = paddle.transform.position + paddleToBallVector;
				hasStarted = false;
			}
		}
	}
	
	public void resetBallLifeLost(){
		if(hasStarted){
			this.transform.position = paddle.transform.position + paddleToBallVector;
			hasStarted = false;
		}
	}
	
	void OnCollisionEnter2D(Collision2D collision){
		Vector2 tweak = new Vector2(Random.Range(0f, 0.2f), Random.Range(0f, 0.2f));
		if(hasStarted){
			audio.Play();
			this.rigidbody2D.velocity += tweak;
		}
	}
}
