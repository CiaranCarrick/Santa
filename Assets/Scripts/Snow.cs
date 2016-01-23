using UnityEngine;
using System.Collections;

public class Snow : Entities {

	float horzSpeed;

	//Constructor
	public void Setsnow(float _xpos, float _ypos, float _xScale, float _yScale, float _speed, float _horzSpeed){
		name = "Snow";
		xPos = _xpos;
		yPos = _ypos;
		xScale = _xScale;
		yScale = _yScale;
		speed = _speed;
		horzSpeed = _horzSpeed;

		xPos = Random.Range (-ScreenWidth, ScreenWidth);
		yPos = Random.Range(6f, 8f);
		transform.position = new Vector3(xPos, yPos,-0.1f);
		Vector3 newscale = new Vector3 (Random.Range(0.1f, 0.2f), Random.Range(0.1f, 0.2f), 0.1f);
		transform.localScale = newscale;
		speed = Random.Range(-0.05f, -0.15f);
		}//end constructor
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.right * -1 * horzSpeed);
		transform.Translate(new Vector3(0, speed, 0));

		if(transform.position.y < ScreenBottom){
			Vector3 posV = transform.position;
			posV.y = screenTop + Random.Range(1f,2f);
			transform.position = posV;
		}
		if(transform.position.x < screenLeft){
			Vector3 posH = transform.position;
			posH.x = screenRight + Random.Range(1f,2f);
			transform.position = posH;
		}
	}
}//end class
