using UnityEngine;
using System.Collections;

public class CatchScript : MonoBehaviour {


	float _timer;
	bool _timeout;
	public bool isHunter;
	int points = 0;
	public string huntingString = "";


	// Use this for initialization
	void Start () {
	//	print (gameObject.name);
	}
	
	void Update () {
		if (_timeout) {
			_timer -= Time.deltaTime;
			if (_timer <= 0){
				_timer = 2;
				_timeout = false;
			}
		}
		if(!isHunter)
			points++;
	
	}


	void OnGUI(){
		if (isHunter)
			GUI.TextArea (new Rect (30, 10,100, 25), huntingString + points);
		else
			GUI.TextArea (new Rect (700, 10, 100, 25), huntingString + points);
	}

	

	void OnTriggerEnter(Collider collider){
		if(collider.name  == "Madel" && gameObject.name == "Bub"){
		//	print("Collision Madel und Bub ");
			if(isHunter) {
				//points = points + 10000;
				isHunter = false;
				huntingString = "Run!!! ";
				//_timeout = true;
			} else {
				isHunter = true;
				//_timeout = true;
			//	print("DAMN " + collider.name);
				//points = points - 10000;
			} 

			transform.position = new Vector3 (-6.11f, 0f, -9.2f);
		}
		else if(collider.name  == "Bub" && gameObject.name == "Madel"){
		//	print("Collision Madel und Bub ");
			if(isHunter) {
				//points = points + 10000;
				isHunter = false;
				huntingString = "Catch!!! ";
				//_timeout = true;
			} else {
				isHunter = true;
				//_timeout = true;
			//	print("DAMN " + collider.name);
				//points = points - 10000;
			} 

			transform.position = new Vector3 (-3.01f, 0f, -12.3f);
		}
	}
}
