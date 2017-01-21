using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

//this class is in charge of loading the map layout from the text file
public class TextFileLoader : MonoBehaviour {

    // Use this for initialization
    public int BPM_ChartNumber;

    TextAsset textFile = new TextAsset();
    private string storage = "";
    void Start() {
        TextAsset thing = Resources.Load("Pipedreamchartproto") as TextAsset;
 
        string[] localStorage;
        storage = thing.ToString();
        localStorage = storage.Split('*');
        List<string[]> finalStorage = new List<string[]>();

        for (int i = 0; i < localStorage.Length; i++)
        {
            string[] tempSplitLoc = localStorage[i].Split(',');
            finalStorage.Add(tempSplitLoc);
        }

    }
	
	// Update is called once per frame
	void Update () {
       
        
    }
}
