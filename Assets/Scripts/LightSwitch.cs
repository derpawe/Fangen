using System.Diagnostics;
using UnityEngine;
using System.Collections;

public class LightSwitch : MonoBehaviour
{

    public bool switchable = true;

    public AudioClip lightOnClip;
    public AudioClip lightOffClip;

    private Light light;

	// Use this for initialization
	void Start ()
	{
	    light = GetComponentInChildren<Light>();
	}

    void OnMouseDown()
    {
        SwitchLight();
    }

    private void SwitchLight()
    {
        if (switchable && light.enabled == true)
        {
            AudioSource.PlayClipAtPoint(lightOffClip, transform.position, 1f);
            light.enabled = false;
        }
        else if(switchable && light.enabled == false)
        {
            AudioSource.PlayClipAtPoint(lightOnClip, transform.position, 1f);
            light.enabled = true;
        }
    }
}
