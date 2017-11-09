using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {
	
	
	public static int breakableCount = 0;
	public AudioClip crack;
	public Sprite[] hitSprites;
	public GameObject smoke;
	private Color color;
	
	private LevelManager levelManager;
	private int timesHit;
	private bool isBreakable;
	// Use this for initialization
	void Start () {
		isBreakable = (this.tag == "Breakable");
		if (isBreakable){
			breakableCount++;
		}
		timesHit = 0;
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		color = this.GetComponent<SpriteRenderer>().color;
	}
	
	// Update is called once per frame
	void Update(){

	}
	
	void OnCollisionEnter2D(Collision2D collision){
		AudioSource.PlayClipAtPoint(crack, transform.position, 0.5f);
		if(isBreakable){
			HandleHits();
		}
	}
	
	void HandleHits(){
		timesHit++;
		int maxHits = hitSprites.Length + 1;
		if(timesHit >= maxHits){
			breakableCount--;
			levelManager.BrickDestroyed();
			SmokePuff();
			Destroy(gameObject);
		}else{
			LoadSprites();
		}
	}
	
	private void SmokePuff(){
		Vector3 smokePos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0);
		GameObject smokePuff = Instantiate(smoke, smokePos, Quaternion.identity) as GameObject;
		smoke.particleSystem.renderer.sortingLayerName = "smokeLayer";
		smoke.particleSystem.startColor = color;
		Destroy(smokePuff, 2f);
	}
	
	void LoadSprites(){
		int spriteIndex = timesHit - 1;
		if(hitSprites[spriteIndex]){
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		}else{
			Debug.LogError("Brick sprite missing!");
		}
	}
}
