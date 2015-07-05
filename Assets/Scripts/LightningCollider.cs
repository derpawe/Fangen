using UnityEngine;
using System.Collections;

public class LightningCollider : MonoBehaviour
{

    public float minTime = 6f;
    public float threshold = 0.9f;

    public AudioClip flashClip;

    private Light lightning;
    private  float lastTime = 0f;

	// Use this for initialization
	void Start ()
	{
	    lightning = GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {
	    if ((Time.time - lastTime) > minTime)
	    {
	        if (Random.value > threshold)
	        {
	            StartCoroutine(Flash());

	            lastTime = Time.time;
	        }
	    }
	}

    private IEnumerator Flash()
    {
        lightning.enabled = true;
        AudioSource.PlayClipAtPoint(flashClip, transform.position, 1f);
        yield return new WaitForSeconds(0.5f);
        lightning.enabled = false;
    }
}
