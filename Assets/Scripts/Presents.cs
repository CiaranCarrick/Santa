using UnityEngine;
using System.Collections;

public class Presents : Entities {

	//Constructor
	public void Setpresents(float _x, float _y, float _xScale, float _yScale, float _speed, Color _col){
		name = "Present";
		xPos = _x;
		yPos = _y;
		xScale = _xScale;
		yScale = _yScale;
		speed = _speed;
		color = _col;
		Vector3 newPos = new Vector3(xPos, yPos, 0f);//Create local variable and set to constructor value
		transform.position = newPos;//Cache position
		Vector3 newscale = new Vector3 (Random.Range(0.40f, 0.50f), Random.Range(0.20f, 0.60f), 1.1f);
		transform.localScale = newscale;//Cache scale
		GetComponent<Renderer>().material.color = color;// Set color
		//Color newcolour = new Color(Random.Range(0.01f, 1f), Random.Range(0.01f, 1f),Random.Range(0.01f, 1f), 255);
		//GetComponent<Renderer>().material.color = newcolour;
	}

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.down * speed);//Shoot presents Downwards

		//Destroy when < than ScreenBottom
		if (transform.position.y < ScreenBottom) {
				Destroy (gameObject);
		}

		//Collisons

		for (int i = 0; i < Entities.chimneys.Count; i++) {
			GameObject target = Entities.chimneys[i].gameObject;//creates local instance of the target in the loop
			float distance = (transform.position - target.transform.position).magnitude;//creates a float which stores position between 2 variables
			if (distance <= 0.5f)
			{
				CreateParticles(gameObject.transform.position);
				Destroy (target.gameObject);
				Destroy (gameObject);
			    chimneys.Remove(target.gameObject);
				score+=10;
				//Debug.Log(target+" Destroyed");
				if (target.GetComponent<Renderer>().material.color==Colours[2,0]) // If the spawned chimney is Color.blue, extra points
				{
					score+=100;
				}
			}
		}
 	}
}
