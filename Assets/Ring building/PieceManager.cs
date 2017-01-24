using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rhythmify;

// Controls all pieces in a segment
public class PieceManager : _AbstractRhythmObject
{
    public List<GameObject> PieceList;

    public TextFileLoader obstacleinfo;
    


    public GameObject PiecePrefab;
    public GameObject Parent;
    public GameObject blank;
    public static LinkedList<GameObject> ring_list = new LinkedList<GameObject>();

    [Tooltip("Number of Pieces in the Segment")]
    public float numberOfPieces = 0;
    public int maxScale = 0;
    public int scaley = 0;
    public int scalez = 0;
    public float cubeSize = 0;
    public Vector3 CircleCenter;
    private float Radius;
    private Vector3 sumPos;
    private float sumRot;
    public static float offset = 0;

    public int ring_limit = 25, ring_count = 0;

    RaycastHit rayInfo;

    void Awake()
    {
        foreach (GameObject go in ring_list)
        {
            ring_list.RemoveFirst();
                Destroy(go);
        }
        ring_limit = 25;
        ring_count = 0;

        transform.position = new Vector3(0, -1, 52);
    }

    protected override void rhythmUpdate(int beat)
    //update is called once per BPM
    {
        Parent = Instantiate(blank, CircleCenter, transform.rotation);

        Radius = cubeSize * numberOfPieces / Mathf.PI / 2;
        CircleCenter = transform.position;
        sumPos = CircleCenter + new Vector3(Radius, 0, 0);

       
        PieceList = new List<GameObject>();

        for (int i = 0; i < numberOfPieces; i++)
        {
            sumRot = 360 / numberOfPieces;
            PieceList.Add(PieceManager.Instantiate(PiecePrefab, sumPos, Quaternion.identity));

        }

        for (int i = 0; i < numberOfPieces; i++)
        {
            PieceList[i].transform.RotateAround(CircleCenter, Vector3.up, sumRot * i + 1);

        }

        sumPos = CircleCenter + new Vector3(Radius, 0, 0);
        for (int i = 0; i < numberOfPieces; i++)
        {
            PieceList[i].transform.localScale = new Vector3((AudioVisualizer.samples[i] * maxScale), scaley, scalez);
        }

        for (int i = 0; i < numberOfPieces; i++)
        {
            PieceList[i].transform.SetParent(Parent.transform);

        }
        offset += 5;
        Parent.transform.Rotate(new Vector3(1, 0, 0), 90);
        Parent.transform.Rotate(new Vector3(0, 1, 0), offset);
        ++ring_count;
        AddRing();
        MoveRings();
        DelRing();



        RaycastHit hit;
        Ray ray = new Ray();
        ray.direction = new Vector3(Random.Range(-100, 100) * 0.01f, Random.Range(-100, 100) * 0.01f, 0);
        ray.origin = Parent.transform.position;
        if (Physics.Raycast(ray, out hit))
            {

            Debug.DrawRay(ray.origin, ray.direction, Color.red);
            obstacleinfo.convertTextValues(hit.point, -ray.direction, Parent.transform);
        }

    }

    public  LinkedList<GameObject> getParentList()
    {
        return ring_list;
    }
    
    protected virtual void asyncUpdate() { }
protected virtual void init() { }
protected bool onBeat()
{
    return true;
}

    public void AddRing()
    {
        ring_list.AddLast(Parent);
    }

    public void DelRing()
    {
        foreach (GameObject go in ring_list)
        {
            if (go.transform.position.z < -15)
            {
                //Debug.Log("Kill");
                ring_list.RemoveFirst();
                Destroy(go);
            }
            break;
        }
    }

    public void MoveRings()
    {
        float diff = 1f;
        foreach (GameObject go in ring_list)
        {
            Vector3 new_pos = new Vector3(0, 0, 0);
            new_pos = go.transform.position;
            new_pos.z -= diff;
            go.transform.position = new_pos;
        }
    }

    public void RotateRings(float amount)
    {
        foreach (GameObject go in ring_list)
        {
            go.transform.Rotate(0, amount, 0);
        }
    }
}
