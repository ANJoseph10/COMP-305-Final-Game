using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAIComponent : SimpleEnemy {

	private int healthMax = 100;
	public int health;

	public GameObject[] possibleDrops;
	public GameObject dropsArray;

	public GameObject playerObject;
	private PlayerController player;

	public GameObject squad;

	private Rigidbody2D rb;

	public float speed = 0.2f;

	public Vector2 target;
	public GameObject proyectile;

	public GameObject toDrop;
	
	void OnTriggerEnter2D(Collider2D coll){
		if (coll.tag == "bullet"){
			DestroyEnemy(coll);
			
		}
	}

	void Start () {	
		health = healthMax;
		rb = GetComponent<Rigidbody2D>();
		target = GenerateTargetPosition();
		int ran = Random.Range(0,3);
		possibleDrops = dropsArray.GetComponent<DropArray>().drops;

		player = GameObject.Find("Player").GetComponent<PlayerController>();

		if (ran == 1){
			this.GetComponent<SpriteRenderer>().flipX = true;
		} else {
			this.GetComponent<SpriteRenderer>().flipX = false;
		}

		toDrop = RandomizeDrop();
		
	}
	
	void Update () {
		if (target == null){
			target = GenerateTargetPosition();
		} else {
			if (Vector2.Distance(this.transform.position, target) > 1 ){
				if (target.x > transform.position.x)
					rb.velocity = new Vector2(speed, rb.velocity.y);
				if (target.x < transform.position.x)
					rb.velocity = new Vector2(-speed, rb.velocity.y);

				if (target.y > transform.position.y)
					rb.velocity = new Vector2(rb.velocity.x, speed);
				if (target.y < transform.position.y)
					rb.velocity = new Vector2(rb.velocity.x, -speed);
			} else {
				target = GenerateTargetPosition();
				Shoot();
			}

		}

	}

	Vector2 GenerateTargetPosition(float x = -9.5f, float y = 10f){
		return new Vector2(Random.Range(-9.5f,-4.5f), Random.Range(10, 5));
	}

	void Shoot(){
		GameObject myObj = Instantiate(proyectile,this.transform.position, Quaternion.identity);
		myObj.transform.parent = GameObject.Find("DynamicBullets").transform; //TODO: use less costly method
	}

	public void Move(){

	}

	void DestroyEnemy(Collider2D coll){
		Destroy(this.gameObject, 0.01f);
		Destroy(coll.gameObject, 0.01f);

		player.gameManager.AddScore(100*player.gameManager.combo);
		player.gameManager.UpdateUI();
		player.gameManager.combo++;

		DropItem(15);
	}

	void DropItem(int chance){
		int ran = Random.Range(1,99);
		if (chance >= ran){
			Instantiate(toDrop, transform.position, Quaternion.identity);
		}
	}

	GameObject RandomizeDrop(){
		GameObject drop;
		int rand = Random.Range(0,possibleDrops.Length);

		drop = possibleDrops[rand];

		return drop;
	}
}
