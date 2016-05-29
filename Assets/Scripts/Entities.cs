using UnityEngine;
using System.Collections.Generic;

public class Entities : MonoBehaviour {
	//Inheritance
	protected static Color[,] Colours = new Color[5,2];// 2D Array, only availible in this or inherited classes

	public static List<GameObject> chimneys = new List<GameObject>();//List to store chimneys
	public float xPos;//Variables used across all child classes of Entities
	public float yPos;//
	public float xScale;//
	public float yScale;//
	public float speed;//
	public Color color;//
	public int ScreenBottom=-4;
	public int ScreenWidth=11;
	public static float screenLeft = -12f;//Variables for snow
	public static float screenRight = 10f;//
	public static float screenTop = 6f;//
	public static float screenBottom = -4f;//


	
	public static GameObject santa;// static santa makes santa the only santa in the whole program and accessible to the whole program
	public static int score=0;

	// Use this for initialization

	void Start () {
		Colours[0,0] = Color.red;//Store our colours in a 2D array, 2nd can be used for unique present wrapping!
		Colours[0,1] = Color.cyan;
		
		Colours[1,0] = Color.blue;//
		Colours[1,1] = Color.white;
		
		Colours[2,0] = Color.green;//
		Colours[2,1] = Color.white;
		
		Colours[3,0] = Color.cyan;//
		Colours[3,1] = Color.white;
		
		Colours[4,0] = Color.yellow;//
		Colours[4,1] = Color.magenta;

		score = 0; //Set score to 0 from start
		CreateSanta ();
		CreateSnow ();
		InvokeRepeating("CreateChimneys", 0.8f, 1.5f);// Repeatedly calls CreateChimneys function

	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space)){ // If space is press
			if (santa) { //Only while santa is not null
				CreatePresents (); //Call CreatePresents Method
			}
		}
	}
	//Create Santa GameObject
	void CreateSanta(){
		santa = GameObject.CreatePrimitive (PrimitiveType.Cube);//Create object
		santa.AddComponent<Santa>();//Add script to object
		Santa ss = santa.GetComponent<Santa>(); //Create instance of type Santa and assign it the class Santa from santa Gameobject
		ss.SetupSanta(0f, 4f, 1.0f, 1.0f, 0.2f, Color.red);//Constructor variables
	}

	void CreateChimneys(){
		GameObject chimney= GameObject.CreatePrimitive (PrimitiveType.Cube);
		chimney.AddComponent<Chimneys> ();
		Chimneys chim = chimney.GetComponent<Chimneys>();
		Color roofColor = new Color (0.8F, 0, 0);
		chim.Setchimneys (15f, -2f, 1f, 2f, 0.1f,roofColor); 
		chimneys.Add(chimney);// Adds Gameobject chimney to list
	}

	void CreateSnow(){
		GameObject empty = new GameObject ();//Clean up hierachy
		empty.name="Snow";
		for (int i = 0; i<=20; i++) {
			GameObject snow = GameObject.CreatePrimitive (PrimitiveType.Sphere);
			snow.AddComponent<Snow> ();
			Snow snowflakes = snow.GetComponent<Snow> ();
			snowflakes.Setsnow (Random.Range(screenLeft, screenRight), Random.Range(screenBottom, screenTop), Random.Range(0.05f,0.1f), Random.Range(0.05f,0.1f), 0f, 0.1f);
			snow.transform.parent = empty.transform;
		}
	}

	void CreatePresents(){
		GameObject presents = GameObject.CreatePrimitive (PrimitiveType.Cube);// Gameobjects are cubes
		presents.AddComponent<Presents> ();//Add the Presents script to each gameobject
		Presents toys = presents.GetComponent<Presents>();//Create instance of Presents called toys
		float scale = Random.Range(0.5f, 0.75f);
		float _x = santa.transform.position.x;//Set starting position to Santa gameobject position
		float _y = santa.transform.position.y;//
		int c = Random.Range(0,5);//Create a random value from 0,5
		toys.Setpresents(_x, _y,scale, scale, 0.15f, Colours[c,0], Colours[c,1]);//List of parameters, Colours[c,0] referances the 1st row,Colours[c,1] the 2nd row of colours
		//So for e.g if c=2 we get a blue present [3,0] with white wrapping [3,1] if c=0 we get a red present [0,0] with cyan wrapping [0,1]
	}

	public void CreateParticles(Vector3 pos){
		for(int i = 0; i < 30; i++){
			GameObject part = GameObject.CreatePrimitive(PrimitiveType.Cube);
			part.AddComponent<Particle>();
			Particle party = part.GetComponent<Particle>();
			if(party != null){
				Vector3 dir = new Vector3(Random.Range(-1f,1f), Random.Range(-1f,1f), 0);
				int c = Random.Range(0,5);
				Color col = Colours[c,0];
				party.SetupParticle(pos.x, pos.y, Random.Range(0.05f,0.1f), Random.Range(0.05f,0.1f), Random.Range(0.05f,0.1f), dir, col, 3f);
			}
		}
	}

}
