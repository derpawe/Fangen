using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class PlayerCollide : NetworkBehaviour {
	
	float _timer;
	bool _timeout;
	[SyncVar]
	int points;

	[SyncVar]
	bool _hunter;

	Color red;
	Color blue;
	bool isFirstplayer;
	NetworkIdentity nIdent;
	MeshRenderer gameObjectRenderer;
	// Use this for initialization
	void Start () {
		points = 0;
		_timer = 2;
		_timeout = false;
		nIdent = GetComponent<NetworkIdentity> ();
		_hunter = (nIdent.netId.Value <= 2);
		isFirstplayer = _hunter;
		red = new Color(255,0,0,1);
		blue = new Color(0,0,255,1);
		
		gameObjectRenderer = this.gameObject.GetComponent<MeshRenderer>();
		
		Material newMaterial = new Material(Shader.Find("Diffuse"));
		if (_hunter)
			newMaterial.color = red;
		else
			newMaterial.color = blue;
		gameObjectRenderer.material = newMaterial ;
	}
	

	void OnGUI(){
		if (isFirstplayer)
			GUI.TextArea (new Rect (10, 10,100, 25), "Erster:" + points);
		else
			GUI.TextArea (new Rect (10, 35, 100, 25), "Zweiter:" + points);
	}

	// Update is called once per frame
	void Update () {
		if (_timeout) {
			_timer -= Time.deltaTime;
			if (_timer <= 0){
				_timer = 2;
				_timeout = false;
			}
		}
		if(_hunter)
			points++;
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