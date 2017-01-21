using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightOnAudio : MonoBehaviour {
    public int band;
    public float minIntensity, maxIntensity;
    Light l;
	// Use this for initialization
	void Start () {
        l = GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {
        l.intensity = (AudioVisualizer.audioBandBuffer[band] * (maxIntensity - minIntensity)) + minIntensity;
	}
}
