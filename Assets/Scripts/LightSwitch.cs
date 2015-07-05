﻿using System.Diagnostics;
using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class LightSwitch : NetworkBehaviour
{

    public bool switchable = true;

    [SyncVar]
	public bool isOn = true;

	public bool localOn = true;

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

	void Update()
	{
		if (localOn != isOn) 
		{
			SwitchLight();
			localOn = isOn;
		}
		print(isOn);
	}

    private void SwitchLight()
    {
        if (switchable && isOn)
        {
            AudioSource.PlayClipAtPoint(lightOffClip, transform.position, 1f);
            light.range = 1;
            isOn = false;
			localOn = false;
        }
        else if(switchable && !isOn)
        {
            AudioSource.PlayClipAtPoint(lightOnClip, transform.position, 1f);
            light.range = 10;
            isOn = true;
			localOn = true;
        }
    }
}
