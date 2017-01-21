using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisSpawner : MonoBehaviour {
    public GameObject sampleCube;
    public int channels;
    GameObject[] cubes = new GameObject[512];
    public float maxScale;

	// Use this for initialization
	void Start () {
		for(int i = 0; i < 512; i+=(int)(512/channels))
        {
            GameObject cubeInst = (GameObject)Instantiate (sampleCube);
            cubeInst.transform.position = this.transform.position;
            cubeInst.transform.parent = this.transform;
            cubeInst.name = "Sample Cube" + i;
            float offset = (360f / channels);
            this.transform.eulerAngles = new Vector3(0, -(512/360) * i, 0);
            //this.transform.position += new Vector3(0,0,1);
            cubeInst.transform.position = Vector3.forward * 100;
            cubes[i] = cubeInst;
        }
	}
	//(offset)
	// Update is called once per frame
	void Update () {
		for(int i = 0; i < 512; i++)
        {
            if(cubes[i] != null){
                cubes[i].transform.localScale = new Vector3(1, (AudioVisualizer.samples[i] * maxScale) + 2, 1);
            }
        }
	}
}
