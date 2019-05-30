using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenLife : GameManager {

	private Vector3 currPos;
	private Vector3 dest;
	private Vector3 direction;
	private float speed = 2.0f;
	private float random;
	private bool right =false;
	private bool left = false;

	public Rigidbody2D Falling;
	private int col = 0;
	private int row = 1;

	private Player qBertScript;
	public GameObject qBerto;

	private bool isSpawning = true;
	private bool moving = true;
	public AudioClip[] clips;
	public SpriteRenderer hide;
	public AudioSource clown;
	// Use this for initialization
	void Start () {
		qBerto = GameObject.Find ("Qbert");
		qBertScript = qBerto.GetComponent<Player> ();

		InvokeRepeating ("andresFade", 0.0f, 2.0f);


	}

	// Update is called once per frame
	void Update () {
		//Invoke("movementMagic",2.0f);
		if(!purajAlive)
		{
			Destroy(this.gameObject);
		}
		if (gmMover) 
		{
			if (right) {

				movementMagic ();



			}
			if (left) {
				movementMagic ();
			}
			;

			if (row == 8) {
				Falling.gravityScale = 1;
			}
		

			if (this.col == qBertScript.col && this.row == qBertScript.row && Vector3.Distance(qBertScript.transform.position,transform.position)<10.01f) {
				//qBertScript.death ();
				gmMover = false;
				score+=100;
				clown.clip = clips [1];
				clown.Play ();
				hide.enabled = false;
				Destroy (this.gameObject,clown.clip.length);
			}
		}

	}
	void movementMagic()
	{
		//Debug.Log (Vector3.Distance (currPos, dest));

		if (Vector3.Distance(currPos,dest) <= 0.1f) 
		{
			this.transform.position = dest;
			right = false;
			left = false;
			moving = false;
			isSpawning = false;

			return;
		}
		currPos = this.transform.position;
		direction = dest - currPos;
		direction.Normalize ();
		direction = direction * speed * Time.deltaTime;
		this.transform.Translate (direction);


	}
	void andresFade()
	{
		if (isSpawning) 
		{
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
		if (!moving)
		{
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
			} else {
				clown.clip = clips [0];
				clown.Play ();
				currPos = this.transform.position;
				Vector3 sucksToBeMe = new Vector3 (-0.6f, -0.98f, 0.0f);
				dest = currPos + sucksToBeMe;

				left = true;
				right = false;
				row++;
				col--;
			}
		}
	}

}
