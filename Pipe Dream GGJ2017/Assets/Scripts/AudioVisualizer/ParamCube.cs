using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParamCube : MonoBehaviour {
    public int band;
    public float startScale, scaleMult, maxScale;
    public bool useBuffer, useAudioBands;
    Material mat;
    public float r, g, b;

    // Use this for initialization
    void Start () {
        if (useAudioBands)
            mat = GetComponent<MeshRenderer>().materials[0];
	}
	
	// Update is called once per frame
	void Update () {

        //All magic
        if(useAudioBands)
        {
            if (useBuffer)
            {
                transform.localScale = new Vector3(transform.localScale.x, (AudioVisualizer.audioBandBuffer[band] * scaleMult) + startScale, transform.localScale.z);
                Color col = new Color(r * AudioVisualizer.audioBandBuffer[band], g * AudioVisualizer.audioBandBuffer[band], b * AudioVisualizer.audioBandBuffer[band]);
                mat.SetColor("_EmissionColor", col);
            }
            if (!useBuffer)
            {
                transform.localScale = new Vector3(transform.localScale.x, (AudioVisualizer.audioBand[band] * scaleMult) + startScale, transform.localScale.z);
                Color col = new Color(r * AudioVisualizer.audioBand[band], g * AudioVisualizer.audioBand[band], b * AudioVisualizer.audioBand[band]);
                mat.SetColor("_EmissionColor", col);
            }
            return;
        }

        if (useBuffer)
        {
            transform.localScale = new Vector3(transform.localScale.x, (AudioVisualizer.bandBuffer[band] * scaleMult) + startScale, transform.localScale.z);
        }
        if(!useBuffer)
        {
            transform.localScale = new Vector3(transform.localScale.x, (AudioVisualizer.freqBand[band] * scaleMult) + startScale, transform.localScale.z);
        }

        
    }
}
