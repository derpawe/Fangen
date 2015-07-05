using System.Diagnostics;
using UnityEngine;
using System.Collections;

public class LightSwitch : MonoBehaviour
{

    public bool switchable = true;
    public bool isOn = true;

    public AudioClip lightOnClip;
    public AudioClip lightOffClip;

    private Light light;

	// Use this for initialization
	void Start ()
	{
	    light = GetComponentInChildren<Light>();

	    if (isOn)
	    {
	        light.range = 10;
	    }
	    else
	    {
	        light.range = 1;
	    }
	}

    void OnMouseDown()
    {
        SwitchLight();
    }

    private void SwitchLight()
    {
        if (switchable && isOn)
        {
            AudioSource.PlayClipAtPoint(lightOffClip, transform.position, 1f);
            light.range = 1;
            isOn = false;
        }
        else if(switchable && !isOn)
        {
            AudioSource.PlayClipAtPoint(lightOnClip, transform.position, 1f);
            light.range = 10;
            isOn = true;
        }
    }
}
