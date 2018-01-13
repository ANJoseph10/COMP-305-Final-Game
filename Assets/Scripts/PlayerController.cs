using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	//GAME
	[Header("Game")] 
	public GameObject GameManagerObject;
	public GameManagerScript gameManager;



	//PUBLIC
	public int energy;
	public int health;

	public GameObject shieldObject;
	private shieldscript shield;

	//PRIVATE
	// Ship
	private bool canMove = true;
	private bool canShoot = true;
	public int energyMax = 1000;
	public int healthMax = 100;

	private bool isInvincible = false;
	private int defaultDamageBoost = 75;
	private int damageBoost;
	// Movement
	// Shield
	private bool usingShield = false;
	// Shooting
	private int shootingCost = 100;
	private GameObject folder; //object to parent dynamic bullets created by player

	//COMPONENTS
	private Rigidbody2D rb;
	private SpriteRenderer sr;

	//OTHER
	public GameObject bulletPlayerTest;

	//DESIGN
	[Header("Design Vars")]
	public float speed = 2;
    public string getSceneName()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        return sceneName;
    }

	void OnTriggerEnter2D(Collider2D coll){
		if (isInvincible) return;

        

        if (coll.tag == "bulletEnemy"){
			Destroy(coll.gameObject, 0.1f);
            if(getSceneName() == "boss")
            {
                health -= 60;
            }
            else
            {
                health -= 10;
            }
			if (health <= 0)
				Die();

			isInvincible = true;
			damageBoost = defaultDamageBoost;
			gameManager.combo = 1;
			gameManager.UpdateUI();
		}
	}

	void Start () {
		rb = this.GetComponent<Rigidbody2D>();
		sr = this.GetComponent<SpriteRenderer>();
		shield = shieldObject.GetComponent<shieldscript>();
		folder = GameObject.Find("DynamicBullets");
		gameManager = GameManagerObject.GetComponent<GameManagerScript>();
		
		
		energy = energyMax;
		health = healthMax;


		shield.player = this.transform.GetComponent<PlayerController>();
	}
	
	void Update () {
		if (canMove){

			//     MOVEMENT

			if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)){
				if (rb.position.x < -4.9f)
				rb.position += new Vector2(speed, 0);
				//rb.velocity = new Vector2(speed*10,rb.velocity.y);
			} else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)){
				if (rb.position.x > -10f)
				rb.position -= new Vector2(speed, 0);
			}


			//    SHOOTING

			if (Input.GetKeyDown(KeyCode.J) && energy >= shootingCost){ 
				Shoot();
                
                if (getSceneName() == "boss")
                {
                    energy -= 400;
                }
                else
                {
                    energy -= shootingCost;
                }
				print(energy/10); //FIXME: make percentage based.
			}


			//     SHIELD

			if (energy > 0 && Input.GetKey(KeyCode.K) ){
				usingShield = true;
				shieldObject.SetActive(true); //FIXME: temporal, get rid of this.
				shield.active = true;
				energy -= 3;
				
			} else {
				shield.active = false;
			}

			//      DAMAGE BOOST

			if (damageBoost <= 0){
				isInvincible = false;
			} else {
				damageBoost -= 1;
			}

			if (isInvincible)
				sr.color = new Color(1, 1, 1, 0.5f);
			else 
				sr.color = new Color(1, 1, 1, 1);

		}
        if (getSceneName() == "boss")
        {
            if (energy < energyMax)
            {
                energy += 10;
            }
        }
        else
        {
            if (energy < energyMax)
            {
                energy += 2;
            }
        }
        

	}

	void Shoot(){
		GameObject myBullet = Instantiate(bulletPlayerTest, this.transform.position, Quaternion.identity);
		myBullet.GetComponent<Rigidbody2D>().gravityScale = -1;
		myBullet.GetComponent<Rigidbody2D>().velocity += new Vector2(0, 10);
		myBullet.transform.parent = folder.transform;
		
	}

	void Die(){
		print("you are dead");
		canMove = false;
		sr.color = new Color(1,1,1,0);
		shield.active = false;
        SceneManager.LoadScene(2);
	}
}
