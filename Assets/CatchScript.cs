using UnityEngine;
using System.Collections;

public class CatchScript : MonoBehaviour {


	float _timer;
	bool _timeout;
	public bool isHunter = true;
	int points = 0;

	// Use this for initialization
	void Start () {
	
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
			GUI.TextArea (new Rect (10, 10,100, 25), "Catch!  " + points);
		else
			GUI.TextArea (new Rect (500, 10, 100, 25), "Run!  "+ points);
	}

	

	void OnTriggerEnter(Collider collider){
		if(collider.tag  == "Player"){
			print("Collision ");
			if(isHunter) {
				points = points + 10000;
				isHunter = false;
				//_timeout = true;
			} else {
				isHunter = true;
				//_timeout = true;
				print("DAMN " + collider.name);
			} 
			
		}
	}
}
