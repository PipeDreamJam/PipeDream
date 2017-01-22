using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this class will translate the data given from the song, into what will happen with the objects in game
public class DataToObjectTranslator : MonoBehaviour {

    [Tooltip("List of the different pieces that make up the segment")]
    public PieceManager inputPieces;

   public List<Transform> localPieces = new List<Transform>();
    
    

    [Range(0.1f,1)]
    public float VolumeLevel;


    //scale the input pieces Y axis  by the volume level
	// Use this for initialization
	void Start () {
        for (int i = 0; i < inputPieces.PieceList.Count; i++)
        {
            localPieces[i] = inputPieces.PieceList[i].GetComponent("Transform") as Transform;
        }
      

        // StartCoroutine(LateStart(.001f));
    }

    //IEnumerator LateStart(float waitTime)
    //{
    //    yield return new WaitForSeconds(waitTime);

    //    for (int i = 0; i < inputPieces.PieceList.Count; i++)
    //    {
            
           
    //    }
    //}
	
	// Update is called once per frame
	void Update () {
        VolumeScaler(VolumeLevel);
	}

    float prevVolume = 0;
    void VolumeScaler(float volume)
    {

        bool needToChange = false;
        if (prevVolume != volume) { needToChange = true; }

        if(needToChange == true)
        {
            for (int i = 0; i < inputPieces.PieceList.Count; i++)
            {
               inputPieces.PieceList[i].transform.localScale  = new Vector3(volume * 10, 1,1);
                //inputPieces.PieceList[i].GetComponent<Transform>().localScale = new Vector3(1, i * volume, 1);
                //Debug.Log("Local Scale: " + inputPieces.PieceList[i].transform.localScale);
                //Debug.Log(i);
            }

            needToChange = false;
        }

        prevVolume = volume;
    }
}
