using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurajScript : Spawner {

	private Vector3 currPos;
	private Vector3 dest;
	private Vector3 direction;
	private float speed = 2.0f;
	private float random;
	private bool right =false;
	private bool left = false;
	private int col = 0;
	private int row = 0;
	//In charge of sprites
	public Sprite superSnake;
	private SpriteRenderer snakeThem;
	public Rigidbody2D ridSnake;
	public Sprite SnakeUpLeft;
	public Sprite SnakeUpRight;
	public Sprite SnakeBotRight;
	public Sprite SnakeBotLeft;


	private Player qBertScript;
	private bool noSnake = true;
	private bool ballForm = true;
	private bool sMoving = false;
	private bool sChoice = true;
	private bool sChill = true;
	private bool isDead = true;

	public GameObject qBerto;
	public AudioClip[] clips;
	public AudioSource clown;

	private bool isSpawning = true;
	private bool moving = true;
	// Use this for initialization
	void Start () {
		qBerto = GameObject.Find ("Qbert");
		qBertScript = qBerto.GetComponent<Player> ();

		snakeThem = gameObject.GetComponent<SpriteRenderer> ();

		InvokeRepeating ("andresFade", 0.0f, 2.0f);
     
	}

	// Update is called once per frame
	void Update () {
		//Invoke("movementMagic",2.0f);
		if (this.col == qBertScript.col && this.row == qBertScript.row && Vector3.Distance(qBertScript.transform.position,transform.position)<10.01f ){
			sChoice = false;
			sMoving = true;
			qBertScript.deathByEnemy ();
		}
		if(!purajAlive){
			Destroy(this.gameObject);
			isPurajThere = false;
			isDead = false;
		}
		if (gmMover)
		{
			if (right) {
				movementMagic ();
			}
			if (left) {
				movementMagic ();
			}

			if (sChoice && sChill) {
				snakeMove ();
			}

			if (sMoving) {
				snakeMoveStuff ();
			}

			if ((row == 0 && col == 8 || row == 0 && col == 6 || row == 1 && col == 5 || row == 1 && col == 9 || row == 2 && col == 10 || row == 2 && col == 4 ||
			   row == 3 && col == 3 || row == 3 && col == 11 || row == 5 && col == 1 || row == 5 && col == 13 || row == 6 && col == 14 || row == 6 && col == 0 ||
			   row == 8 || row == 4 && col == 12 || row == 4 && col == 2) && isDead) {
			
				score+=500;
				isPurajThere = false;
				isDead = false;
				ridSnake.gravityScale = 1;
				purajAlive = false;
				return;

			}
		
		}
	}


	void movementMagic()
	{
		if (ballForm) {


			if (Vector3.Distance (currPos, dest) <= 0.1f) {
				this.transform.position = dest;
				right = false;
				left = false;
				moving = false;
				isSpawning = false;
				if (row == 7 && noSnake) 
				{
					noSnake = false;
					ballForm = false;
					snakeThem.sprite = superSnake;
				}
				return;
			}

			currPos = this.transform.position;
			direction = dest - currPos;
			direction.Normalize ();
			direction = direction * speed * Time.deltaTime;
			this.transform.Translate (direction);
		}


	}

	void andresFade()
	{
		if (ballForm) 
		{
			if (isSpawning) {
				isSpawning = false;
				random = Mathf.Floor (Random.Range (0, 2));

				if (random == 0) {

					currPos = this.transform.position;
					Vector3 sucksToBeMe = new Vector3 (0.6f, -5.6f, 0.0f);
					dest = currPos + sucksToBeMe;
					right = true;
					left = false;
					row = 2;
					col = 8;
				} else {
					currPos = this.transform.position;
					Vector3 sucksToBeMe = new Vector3 (-0.6f, -5.6f, 0.0f);
					dest = currPos + sucksToBeMe;

					left = true;
					right = false;
					row = 2;
					col = 6;
				}
			}
			if (!moving) {
				moving = true;
				random = Mathf.Floor (Random.Range (0, 2));

				if (random == 0) {
					clown.clip = clips [0];
					clown.Play ();
					currPos = this.transform.position;
					Vector3 sucksToBeMe = new Vector3 (0.6f, -0.98f, 0.0f);
					dest = currPos + sucksToBeMe;
					right = true;
					left = false;
					row++; 
					col++;
				} 
				else {
					clown.clip = clips [0];
					clown.Play ();
					currPos = this.transform.position;
					Vector3 sucksToBeMe = new Vector3 (-0.6f, -0.98f, 0.0f);
					dest = currPos + sucksToBeMe;
					row++; 
					col--;

					left = true;
					right = false;
				}
			}
		}
	}
	void snakeMove()
	{
		if (!ballForm)
		{
			sChill = false;
			if(this.row ==qBertScript.row &&this.col >qBertScript.col &&sChoice)
			{
				sChoice = false;
				random = Mathf.Floor (Random.Range (0, 2));
				if (random == 0) 
				{
					clown.clip = clips [1];
					clown.Play ();
					sMoving = true;
					currPos = this.transform.position;
					snakeThem.sprite = SnakeUpRight;
					Vector3 sucksToBeMe = new Vector3 (-0.6f, 0.98f, 0.0f);
					dest = currPos + sucksToBeMe;	
					col--;
					row--;		
				} 
				else 
				{
					clown.clip = clips [1];
					clown.Play ();
					sChoice = false;
					sMoving = true;

					currPos = this.transform.position;
					snakeThem.sprite = SnakeBotLeft;
					Vector3 sucksToBeMe = new Vector3 (-0.6f, -0.98f, 0.0f);
					dest = currPos + sucksToBeMe;	
					col--;
					row++;
				}
				
			}
			if (this.row == qBertScript.row && this.col < qBertScript.col &&sChoice)
			{
				sChoice = false;
				random = Mathf.Floor (Random.Range (0, 2));
				if (random == 0) 
				{
					sMoving = true;

					clown.clip = clips [1];
					clown.Play ();
					currPos = this.transform.position;
					Vector3 sucksToBeMe = new Vector3 (0.6f, 0.98f, 0.0f);
					snakeThem.sprite = SnakeUpRight;
					dest = currPos + sucksToBeMe;	
					col++;
					row--;
				} 
				else 
				{
					sChoice = false;
					sMoving = true;
					clown.clip = clips [1];
					clown.Play ();
					currPos = this.transform.position;
					Vector3 sucksToBeMe = new Vector3 (0.6f, -0.98f, 0.0f);
					snakeThem.sprite = SnakeBotRight;
					dest = currPos + sucksToBeMe;	
					col++;
					row++;
				}
			}
			if (this.col == qBertScript.col && this.row > qBertScript.row &&sChoice) 
			{
				sChoice = false;
				random = Mathf.Floor (Random.Range (0, 2));
				if (random == 0) 
				{
					clown.clip = clips [1];
					clown.Play ();
					sMoving = true;
					currPos = this.transform.position;
					Vector3 sucksToBeMe = new Vector3 (-0.6f, 0.98f, 0.0f);
					snakeThem.sprite = SnakeUpLeft;
					dest = currPos + sucksToBeMe;	
					col--;
					row--;
				} 
				else 
				{
					clown.clip = clips [1];
					clown.Play ();
					sChoice = false;
					sMoving = true;

					currPos = this.transform.position;
					Vector3 sucksToBeMe = new Vector3 (0.6f, 0.98f, 0.0f);
					snakeThem.sprite = SnakeUpRight;
					dest = currPos + sucksToBeMe;	
					col++;
					row--;
				}
			}
			if (this.col == qBertScript.col && this.row < qBertScript.row &&sChoice) 
			{
				sChoice = false;
				random = Mathf.Floor (Random.Range (0, 2));
				if (random == 0) 
				{
					clown.clip = clips [1];
					clown.Play ();
					sMoving = true;

					currPos = this.transform.position;
					Vector3 sucksToBeMe = new Vector3 (-0.6f, -0.98f, 0.0f);
					snakeThem.sprite = SnakeBotLeft;
					dest = currPos + sucksToBeMe;	
					col--;
					row++;
				} 
				else 
				{
					clown.clip = clips [1];
					clown.Play ();
					sChoice = false;
					sMoving = true;

					currPos = this.transform.position;
					Vector3 sucksToBeMe = new Vector3 (0.6f, -0.98f, 0.0f);
					snakeThem.sprite = SnakeBotRight;
					dest = currPos + sucksToBeMe;	
					col++;
					row++;
				}
			}
			//up left
			if (this.col > qBertScript.col && this.row > qBertScript.row &&sChoice) 
			{
				clown.clip = clips [1];
				clown.Play ();
				sChoice = false;
				sMoving = true;
				currPos = this.transform.position;
				Vector3 sucksToBeMe = new Vector3 (-0.6f, 0.98f, 0.0f);
				snakeThem.sprite = SnakeUpLeft;
				dest = currPos + sucksToBeMe;	
				col--;
				row--;

			}
			//down left
			if (this.col > qBertScript.col && this.row < qBertScript.row &&sChoice) 
			{
				clown.clip = clips [1];
				clown.Play ();
				sChoice = false;
				sMoving = true;

				currPos = this.transform.position;
				Vector3 sucksToBeMe = new Vector3 (-0.6f, -0.98f, 0.0f);
				snakeThem.sprite= SnakeBotLeft;
				dest = currPos + sucksToBeMe;	
				col--;
				row++;
			}
			//up right
			if (this.col < qBertScript.col && this.row > qBertScript.row &&sChoice) 
			{
				clown.clip = clips [1];
				clown.Play ();
				sChoice = false;
				sMoving = true;

				currPos = this.transform.position;
				Vector3 sucksToBeMe = new Vector3 (0.6f, 0.98f, 0.0f);
				snakeThem.sprite = SnakeUpRight;
				dest = currPos + sucksToBeMe;	
				col++;
				row--;
			}
			//down right
			if (this.col < qBertScript.col && this.row < qBertScript.row &&sChoice) 
			{
				clown.clip = clips [1];
				clown.Play ();
				sChoice = false;
				sMoving = true;

				currPos = this.transform.position;
				Vector3 sucksToBeMe = new Vector3 (0.6f, -0.98f, 0.0f);
				snakeThem.sprite = SnakeBotRight;
				dest = currPos + sucksToBeMe;	
				col++;
				row++;
			}
		/*	if (this.col == qBertScript.col && this.row == qBertScript.row && Vector3.Distance(qBertScript.transform.position,transform.position)<10.01f&& sChoice)
			{
				sChoice = false;
				sMoving = true;
				qBertScript.deathByEnemy ();
			}*/
		}
	}
	void snakeMoveStuff()
	{
		if (!ballForm) {
			if (Vector3.Distance (currPos, dest) <= 0.1f) {
				sMoving = false;
				this.transform.position = dest;
				sChoice = true;
				Invoke ("chillingKilling", 1.0f);
			}
			currPos = this.transform.position;
			direction = dest - currPos;
			direction.Normalize ();
			direction = direction * speed * Time.deltaTime;
			this.transform.Translate (direction);
	
		}
	}
	void chillingKilling()
	{
		sChill = true;
	}

}
