using UnityEngine;
using System.Collections;

public class Presents : Entities {
	Color colorWrapping;
	//Constructor
	public void Setpresents(float _x, float _y, float _xScale, float _yScale, float _speed, Color _col,Color _colorWrapping){
		name = "Present";
		xPos = _x;
		yPos = _y;
		xScale = _xScale;
		yScale = _yScale;
		speed = _speed;
		color = _col;
		colorWrapping = _colorWrapping;

		Vector3 newPos = new Vector3(xPos, yPos, -0.3f);//Create local variable and set to constructor value
		transform.position = newPos;//Cache position
		Vector3 newscale = new Vector3 (xScale, yScale, 0.5f);//Random.Range(0.40f, 0.50f), Random.Range(0.20f, 0.60f)
		transform.localScale = newscale;//Cache scale
		GetComponent<Renderer>().material.color = color;// Set color

		//Vertical Wrapping, this will serve as the wrapping for the present
		GameObject vert = GameObject.CreatePrimitive(PrimitiveType.Cube);
		vert.name = "W_Vert";
		Vector3 vert_scale = new Vector3(xScale*0.3f, yScale*1.0f, 0.1f);
		Vector3 vertPos = new Vector3(transform.position.x, transform.position.y, transform.position.z-0.25f);
		vert.transform.position = vertPos;
		vert.transform.localScale = vert_scale;
		vert.GetComponent<Renderer>().material.color = colorWrapping; // ColourWrapping is referancing a variable in the entity CretePresent method 
		vert.transform.parent = transform;//Parent vert gamebject to Present gameobject							  //that chooses a random colour from the 2nd row of the Colours Array

		//Horzizontal Wrapping
		GameObject Horz = GameObject.CreatePrimitive(PrimitiveType.Cube);
		vert.name = "W_Horz";
		Vector3 Horz_scale = new Vector3(xScale*1f, yScale*0.3f, 0.1f);
		Vector3 HorzPos = new Vector3(transform.position.x, transform.position.y, transform.position.z-0.25f);
		Horz.transform.position = HorzPos;//Cache
		Horz.transform.localScale = Horz_scale;//Cache
		Horz.GetComponent<Renderer>().material.color = colorWrapping; //assign colourwrapping
		Horz.transform.parent = transform;//Parent vert gamebject to Present gameobject
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
