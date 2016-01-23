using UnityEngine;
using System.Collections.Generic;

public class Chimneys : Entities {
	//Constructor
	public void Setchimneys(float _xpos, float _ypos, float _xscale, float _yscale, float _spd, Color _roofcolour){
		name = "Chimneys";
		xPos = _xpos;
		yPos = _ypos;
		xScale = _xscale;
		yScale = _yscale;
		speed = _spd;
		color = _roofcolour;

		Vector3 newpos = new Vector3 (xPos, yPos, 0);
		transform.position = newpos;
		Vector3 newscale = new Vector3 (xScale, yScale, 1);
		transform.localScale = newscale;
		int c = Random.Range(0,2);//Create a random value from 0,2
		Color col = Colours[c,0];//col choose a random number in the Colours 2D array
		GetComponent<Renderer>().material.color = col;

		//BONUS CHIMNEY
		if (GetComponent<Renderer>().material.color==Colours[1,0])//Colours[0,0] = Color.blue
		{
			newscale = new Vector3 (xScale/2, yScale, 1);
			this.transform.localScale = newscale;
			gameObject.name="BonusChimney";
		}

		//ROOFTOP child of chimney gameobject
		GameObject roof= GameObject.CreatePrimitive (PrimitiveType.Cube);
		Vector3 roofp = transform.position;
		roofp.y -= 1f;
		if (GetComponent<Renderer> ().material.color == Colours [0, 0]) {//If //Colours[1,0] = Color.red
			roofp.x -= Random.Range (-1, 2);//Spawn -1 left, 0 middle, 1 right of rooftop
		}                                                                                                        
		roof.transform.position =roofp;
		roof.transform.parent = transform;//Parents transform direction to chimneys
		roof.GetComponent<Renderer>().material.color = color;

		Vector3 roofscale = new Vector3(4f,1.9f,1f);
		roof.transform.localScale = roofscale;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(new Vector3(-speed, 0, 0));

		if (transform.position.x < -ScreenWidth-xScale ) 
		{
			chimneys.Remove(gameObject);
			Destroy(gameObject);
		}	                  
	}
}
