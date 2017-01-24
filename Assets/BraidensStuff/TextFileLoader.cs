using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


//this class is in charge of loading the map layout from the text file
public class TextFileLoader : MonoBehaviour {

    // Use this for initialization
    public int BPM_ChartNumber;
    //Text file row and colum sizes
    public int[] RowAndColumSize = new int[2];
    public PieceManager pieceInput;

    public static LinkedList<GameObject> parentList; //takes in the list from the piece mananger to get the transforms

    //Object ID's ob0 = void, ob1 = rock, ob2 = n/a, ob3 = n/a, ob4  = n/a
    public int ObstacleType0, ObstacleType1, ObstacleType2, ObstacleType3, ObstacleType4;
    

    TextAsset textFile = new TextAsset();
    private string storage = "";

    List<string[]> finalStorage;

    public List<GameObject> ReadyToPushObjects = new List<GameObject>();
    public Vector3[,] TransformPositions;

    //the obstacle types that will be used for instantiating
    public GameObject[] TypePrefabs = new GameObject[5];

    

    void Start() {

        for (int i = 0; i < TypePrefabs.Length; i++)
        {
            Debug.Log("Obstacle types: " + TypePrefabs[i].gameObject.name);
        }
        
 
        parentList = pieceInput.GetComponent<PieceManager>().getParentList();
        TransformPositions = new Vector3[RowAndColumSize[0], RowAndColumSize[1]];


        //TextAsset textFile = Resources.Load("Pipedreamchartproto") as TextAsset;
        TextAsset textFile = Resources.Load("finalText") as TextAsset;
        string[] rowStorage;
        rowStorage = storage.Split('*');
        finalStorage = new List<string[]>();
        //ID tags (2 int id) that will decide what each object will be 



        for (int i = 0; i < rowStorage.Length; i++)
        {
            string[] colStorage = rowStorage[i].Split(',');
            finalStorage.Add(colStorage);
        }

        //Now that we have filled the storage, we will check and convert from string to int to obstacle type
        
    }

    // Update is called once per frame

    


	void Update () {

  

        //no real use for this yet, since this is pretty much the pre-baked map obstacle loader;
    }

    //This will convert the array of strings we have into the correct prefabs to instance
   public  void convertTextValues(Vector3 point, Vector3 orientation, Transform parentTrans)
    {
        Quaternion q = new Quaternion();
        q.Set(orientation.x, orientation.y, orientation.z, 1);


        //rng to select prefab type
        int r = (int)Random.Range(0, 2);


        ReadyToPushObjects.Add(Instantiate(TypePrefabs[r], point, q, parentTrans));

        //orientation of obstacle should be -1 so it faces the opposite direction

        //1-d array of int verson
        //int[,] TempIntArray = new int[RowAndColumSize[0],RowAndColumSize[1]];

        //for (int i = 0; i < finalStorage.Count; i++)
        //{
        //    for (int j = 0; j < finalStorage[i].Length; j++)
        //    {
        //        TempIntArray[i,j] = System.Convert.ToInt32(finalStorage[i][j]);
        //    }
        //}




        //this 2d for loop will cross check the ints we have in our array with the given values that we 
        //Had recieved as the object ID's
        //for (int i = 0; i < RowAndColumSize[0]; i++)
        //{
        //    for (int j = 0; j < RowAndColumSize[1]; j++)
        //    {
        //        //ObsType1...
        //        if (10 <= TempIntArray[i, j] && TempIntArray[i, j] < 20)
        //        {
        //            //should go 0-9
        //            for (int k = 0; k < 10; k++)
        //            {
        //                if (TempIntArray[i, j] == 10)
        //                {
        //                    //invisible piece
        //                    ReadyToPushObjects.Add(Instantiate(TypePrefabs[1], TransformPositions[i, j] = point, q, parentTrans));

        //                }
        //                // second value changes the amp / height of the object instance
        //                if (TempIntArray[i, j] == (10 + k))
        //                {
        //                    ReadyToPushObjects.Add(Instantiate(TypePrefabs[1], TransformPositions[i, j] = point, q, parentTrans));
        //                }
        //            }
        //            //inst obj 1
        //        }
        //        else if (20 <= TempIntArray[i, j] && TempIntArray[i, j] < 30)
        //        {
        //            for (int k = 0; k < 10; k++)
        //            {


        //                // second value changes the amp / height of the object instance
        //                if (TempIntArray[i, j] == (20 + k))
        //                {
        //                    ReadyToPushObjects.Add(Instantiate(TypePrefabs[2], TransformPositions[i, j] = point, q, parentTrans));
        //                }
        //            }
        //        }
        //        else if (30 <= TempIntArray[i, j] && TempIntArray[i, j] < 40)
        //        {
        //            //inst obj 3
        //            for (int k = 0; k < 10; k++)
        //            {


        //                // second value changes the amp / height of the object instance
        //                if (TempIntArray[i, j] == (30 + k))
        //                {
        //                    ReadyToPushObjects.Add(Instantiate(TypePrefabs[3], TransformPositions[i, j] = point, q, parentTrans));
        //                }
        //            }
        //        }
        //        else if (40 <= TempIntArray[i, j] && TempIntArray[i, j] < 50)
        //        {
        //            //inst obj 4
        //            for (int k = 0; k < 10; k++)
        //            {


        //                // second value changes the amp / height of the object instance
        //                if (TempIntArray[i, j] == (40 + k))
        //                {
        //                    ReadyToPushObjects.Add(Instantiate(TypePrefabs[4], TransformPositions[i, j] = point, q, parentTrans));
        //                }
        //            }
        //        }



        //    }
        //}

    }

}
