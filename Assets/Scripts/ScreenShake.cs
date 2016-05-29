using UnityEngine;
using System.Collections;

public class ScreenShake : MonoBehaviour {
	Vector3 Pos;
	public float shakeAmount=0.1f, shakeTime=0.1f;
	public bool shakeMe=false;
	// Use this for initialization
	void Start () {
		shakeTime=1;
		Pos = transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(Input.GetKey(KeyCode.B)){
			shakeTime=0.1f;
			shakeMe=true;
			return;
		}
			if (shakeMe) {
				if(shakeTime >= 0){
				shakeTime -= Time.deltaTime;
				transform.position = Random.insideUnitCircle * shakeAmount;
				transform.position = transform.position + new Vector3 (Pos.x, Pos.y, Pos.z);
				}
			else
				shakeMe=false;
		} else
			transform.position = Pos;
	}		
}
