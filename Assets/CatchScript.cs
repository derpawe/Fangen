using UnityEngine;
using System.Collections;

public class CatchScript : MonoBehaviour {


	float _timer;
	bool _timeout;
	public bool isHunter;
	int points = 0;
	public string huntingString1 = "";
	public string huntingString2 = "";
	float distance = 0;


	// Use this for initialization
	void Start () {
	//	print (gameObject.name);
	}
	
	void Update () {
		distance = Vector3.Distance(GameObject.Find("Bub").transform.position, GameObject.Find("Madel").transform.position);
		//print("Distance to other: " + distance);
		
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



		if (isHunter) {
			GUI.TextArea (new Rect (30, 10, 100, 25), huntingString1 + points);
			GUI.TextArea (new Rect (30, 30, 100, 25), distance.ToString());
		} else {
			GUI.TextArea (new Rect (800, 10, 100, 25), huntingString2 + points);
			GUI.TextArea (new Rect (800, 30, 100, 25), distance.ToString());
		}
	}

	

	void OnTriggerEnter(Collider collider){
		if(collider.name  == "Madel" && gameObject.name == "Bub"){
		//	print("Collision Madel und Bub ");
			if(isHunter) {
				//points = points + 10000;
				isHunter = false;
				huntingString1 = "Run!!! ";
				huntingString2 = "Catch!!! ";
				//_timeout = true;
			} else {
				isHunter = true;
				huntingString1 = "Catch!!! ";
				huntingString2 = "Run!!! ";
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
				huntingString2 = "Run!!! ";
				huntingString1 = "Catch!!! ";
				//_timeout = true;
			} else {
				isHunter = true;
				huntingString2 = "Catch!!! ";
				huntingString1 = "Run!!! ";
				//_timeout = true;
				//	print("DAMN " + collider.name);
				//points = points - 10000;
			} 

			transform.position = new Vector3 (-3.01f, 0f, -12.3f);
		}
	}
}
