using UnityEngine;
using System.Collections;

public class Particle : Entities {

	Vector3 dir; //Vector variable to hold direction

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(dir*speed);
	}
	
	void die(){
		Destroy(gameObject);
	}

	//Constructor
	public void SetupParticle(float _x, float _y, float _xScale, float _yScale, float _speed, Vector3 _dir, Color _color, float _lifespan) {
		name = "Particle";
		xPos = _x;
		yPos = _y;
		xScale = _xScale;
		yScale = _yScale;
		speed = _speed;
		dir = _dir;
		color = _color;		
		
		Vector3 newPos = new Vector3(xPos, yPos,0);
		transform.position = newPos;
		Vector3 newScale = new Vector3(xScale, yScale, 0.1f);
		transform.localScale = newScale;
		
		GetComponent<Renderer>().material.color = color;
		
		Invoke("die", _lifespan);// Once _lifespan time elaspes invoke die method to destroy particles
	}
}