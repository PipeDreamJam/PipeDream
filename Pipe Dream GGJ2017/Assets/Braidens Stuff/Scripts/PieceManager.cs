using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Controls all pieces in a segment
public class PieceManager : MonoBehaviour {

    public List<GameObject> PieceList;
    public GameObject PiecePrefab;

    [Tooltip("Number of Pieces in the Segment")]
    public int numberOfPieces = 0;

    public Vector3 CircleCenter;
    public float Radius;
    private Vector3 sumPos;

	// Use this for initialization
	void Start () {
        CircleCenter = new Vector3(0, 0, 0);
        sumPos = CircleCenter + new Vector3(Radius, 0, 0);

        PieceList = new List<GameObject>();

        for (int i = 0; i < numberOfPieces; i++)
        {
            // 360 / numberOfPieces;
           PieceList.Add(Instantiate(PiecePrefab,sumPos,Quaternion.identity));

        }

        for (int i = 0; i < numberOfPieces; i++)
        {
            PieceList[i].transform.RotateAround(CircleCenter, Vector3.up, 360 / numberOfPieces * i);
        }

    }
	
	// Update is called once per frame
	void Update () {
        sumPos = CircleCenter + new Vector3(Radius,0,0);



    }

    void radialDistance(float radius)
    {

    }
}
