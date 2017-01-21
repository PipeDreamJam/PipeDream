using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleOnAmplitude : MonoBehaviour {
    public float startScale, maxScale;
    public bool useBuffer;
    Material mat;
    public float r, g, b;

	// Use this for initialization
	void Start () {
        mat = GetComponent<MeshRenderer>().materials[0];
	}
	
	// Update is called once per frame
	void Update () {
		if(useBuffer)
        {
            transform.localScale = new Vector3((AudioVisualizer.amplitude * maxScale)+startScale, (AudioVisualizer.amplitude * maxScale) + startScale, (AudioVisualizer.amplitude * maxScale) + startScale);
            Color col = new Color(r * AudioVisualizer.amplitude, g * AudioVisualizer.amplitude, b * AudioVisualizer.amplitude);
            mat.SetColor("_EmissionColor", col);
        }
        else
        {
            transform.localScale = new Vector3((AudioVisualizer.amplitudeBuffer * maxScale) + startScale, (AudioVisualizer.amplitudeBuffer * maxScale) + startScale, (AudioVisualizer.amplitudeBuffer * maxScale) + startScale);
            Color col = new Color(r * AudioVisualizer.amplitudeBuffer, g * AudioVisualizer.amplitudeBuffer, b * AudioVisualizer.amplitudeBuffer);
            mat.SetColor("_EmissionColor", col);
        }
	}
}
