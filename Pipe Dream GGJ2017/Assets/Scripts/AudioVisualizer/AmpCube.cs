using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmpCube : MonoBehaviour {
    public float startScale, scaleMult;
    public bool useBuffer;
    Material mat;
    // Use this for initialization
    void Start () {
        mat = GetComponent<MeshRenderer>().materials[0];
    }
	
	// Update is called once per frame
	void Update () {
        if (useBuffer)
        {
            transform.localScale = new Vector3(transform.localScale.x, (AudioVisualizer.amplitudeBuffer * scaleMult) + startScale, transform.localScale.z);
            Color col = new Color(AudioVisualizer.amplitudeBuffer, AudioVisualizer.amplitudeBuffer, AudioVisualizer.amplitudeBuffer);
            mat.SetColor("_EmissionColor", col);
        }
        if (!useBuffer)
        {
            transform.localScale = new Vector3(transform.localScale.x, (AudioVisualizer.amplitude * scaleMult) + startScale, transform.localScale.z);
            Color col = new Color(AudioVisualizer.amplitude, AudioVisualizer.amplitude, AudioVisualizer.amplitude);
            mat.SetColor("_EmissionColor", col);
        }
    }
}
