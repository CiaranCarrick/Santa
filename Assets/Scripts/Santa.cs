using UnityEngine;
using System.Collections;

public class Santa : Entities {

	//Constructor
	public void SetupSanta(float _xpos, float _ypos, float _xScale, float _yScale, float _speed, Color _color){
		name = "Santa";
		xPos = _xpos;
		yPos = _ypos;
		xScale = _xScale;
		yScale = _yScale;
		speed = _speed;
		color = _color;
		
		Vector3 newpos = new Vector3 (xPos, yPos, -1.2f);
		transform.position = newpos;	     //Save change made to newpos
		Vector3 newscale = new Vector3 (xScale, yScale, 1);
		transform.localScale = newscale;	//Save change made to newscale
		GetComponent<Renderer>().material.color = color;

	}

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxis ("Horizontal") != 0)
			transform.Translate(Vector3.right * Input.GetAxis("Horizontal")* speed);
			Vector3 position = transform.position;
			position.x = Mathf.Clamp (position.x, -10, 10);
			transform.position = position; // WHEN YOU MAKE A CHANGE TO A VARIABLE YOU MUST SET IT AGAIN TO SAVE CHANGE e.g mathclamp change on position vector
	}

	void OnGUI(){
		GUI.Label(new Rect(5,5,100,50), "Score: "+score);
	}

}
