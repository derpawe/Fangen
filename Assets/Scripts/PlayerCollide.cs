using UnityEngine;
using System.Collections;

public class PlayerCollide : MonoBehaviour {

	float _timer;
	bool _timeout;
	bool _hunter;
	Color red;
	Color blue;
	MeshRenderer gameObjectRenderer;
	// Use this for initialization
	void Start () {
		_timer = 2;
		_timeout = false;
		_hunter = Network.isServer;
		red = new Color(255,0,0,1);
		blue = new Color(0,0,255,1);

		gameObjectRenderer = this.gameObject.GetComponent<MeshRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		if (_timeout) {
			_timer -= Time.deltaTime;
			if (_timer <= 0)
				_timeout = false;
		}

	}

	void OnCollisionEnter(Collision col) {
		print ("not if");
		if(col.gameObject.tag == "Player"){
			print("Collision");
			if(_hunter && !_timeout) {
				_hunter = false;
				_timeout = true;
				print ("isHunter");

				Material newMaterial = new Material(Shader.Find("Diffuse"));
				
				newMaterial.color = blue;
				gameObjectRenderer.material = newMaterial ;
			} else if (!_hunter && !_timeout) {
				_hunter = true;
				_timeout = true;
				print("isHunted");

				Material newMaterial = new Material(Shader.Find("Diffuse"));
				
				newMaterial.color = red;
				gameObjectRenderer.material = newMaterial ;
			} 

		}
	}
}
