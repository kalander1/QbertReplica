using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalFlashIsBetter : MonoBehaviour {


	private Vector3 currPos;
	private Vector3 dest;
	private Vector3 direction;
	private float speed = 2.0f;
	private bool touching = false;
	private Player qBertScript;
	public GameObject qBerto;
	private SpriteRenderer okIvan;


	// Use this for initialization
	void Start () {
		qBerto = GameObject.Find ("Qbert");
		qBertScript = qBerto.GetComponent<Player> ();

		okIvan = gameObject.GetComponent<SpriteRenderer> ();
	}

	// Update is called once per frame
	void Update () {
		if (touching) {
			snakeMoveStuff ();
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.name == "Qbert"&&this.gameObject.name == "DiscoDisk1") 
		{
			touching = true;
			currPos = this.transform.position;
			Vector3 sucksToBeMe = new Vector3 (-3.0f, 4.0f, 0.0f);
			dest = currPos + sucksToBeMe;

			qBertScript.onLeftDisc ();
		}

	}
	void snakeMoveStuff()
	{

		if (Vector3.Distance (currPos, dest) <= 0.1f) {
			this.transform.position = dest;
			touching = false;
			okIvan.enabled = false;

		}
		currPos = this.transform.position;
		direction = dest - currPos;
		direction.Normalize ();
		direction = direction * speed * Time.deltaTime;
		this.transform.Translate (direction);

	}
}
