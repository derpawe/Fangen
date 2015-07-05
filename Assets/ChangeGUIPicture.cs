using UnityEngine;
using System.Collections;

public class ChangeGUIPicture : MonoBehaviour {

	public Texture texture;
	public Texture texture2;
	public string nextLevel;
	int counter = 0;
	// Use this for initialization

	

	void Start () {
		StartCoroutine(NextScreen());
	}
	
	
	public IEnumerator NextScreen()
	{

		if (counter == 1) {
			gameObject.GetComponent<GUITexture> ().texture = texture;
		} else if (counter == 2) {
			gameObject.GetComponent<GUITexture> ().texture = texture2;
		}
			else if (counter == 3){
			Application.LoadLevel (nextLevel); 

		}
		yield return new WaitForSeconds(5f);
		
		counter = counter + 1; 
		StartCoroutine(NextScreen());
		
		yield return 0;
		
	}


}
