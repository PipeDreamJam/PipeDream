using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//The class to end all classes
/*
*It does the same thing 4 times, with one variable changed depending on whether or no
*/

[RequireComponent(typeof(GameObject))]
public class AudioObject : MonoBehaviour {
    //Do not use if using amplitude
    public int band;
    public float startScale, scaleMult;
    public bool useAmplitude;
    public float maxScale = 100f, minScale = 0f;

    public bool useBuffer, useMaterial;
    private Material mat;
    //Not used if not using amplitude
    public float r, g, b;

    public bool useX, useY, useZ;
    

	// Use this for initialization
	void Start () {
        if (useMaterial)
            mat = GetComponent<MeshRenderer>().materials[0];
	}
	
	// Update is called once per frame
	void Update () {
        float x = transform.localScale.x;
        float y = transform.localScale.y;
        float z = transform.localScale.z;

        if (useAmplitude)
        {
            if (useBuffer)
                DoStuff(AudioVisualizer.amplitudeBuffer);
            else
                DoStuff(AudioVisualizer.amplitude);
        }

        else
        {
            if (useBuffer)
                DoStuff(AudioVisualizer.audioBandBuffer[band]);
            else
                DoStuff(AudioVisualizer.audioBand[band]);
        }
	}

    //I don't know what to call this stuff
    void DoStuff(float inStuff)
    {
        float x = transform.localScale.x;
        float y = transform.localScale.y;
        float z = transform.localScale.z;

        if (useX)
            x = (inStuff * scaleMult) + startScale;
        if (useY)
            y = (inStuff * scaleMult) + startScale;
        if (useZ)
            z = (inStuff * scaleMult) + startScale;
        Vector3 temp = new Vector3(x, y, z);
        //if ((temp.x < maxScale && temp.y < maxScale && temp.z < maxScale) && (temp.x > minScale && temp.y > minScale && temp.z > minScale))
            transform.localScale = temp;
        if (useMaterial)
        {
            Color col = new Color(r * inStuff, g * inStuff, b * inStuff);
            mat.SetColor("_EmissionColor", col);
        }
    }
}
