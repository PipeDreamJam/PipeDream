using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Create_Rings : MonoBehaviour {

    private int time_point, time_count;
    public int dist_point, dist_count;
    public int ring_limit, ring_count;
    private Vector3 last_pos, curr_pos;
    private static LinkedList<GameObject> tubes_list = new LinkedList<GameObject>();

    // Use this for initialization
    void Start () {
        time_point = 0;
        last_pos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {

        foreach (GameObject go in tubes_list)
        {
            Vector3 new_pos = go.transform.position;
            new_pos.z += 5;
            go.transform.position = new_pos;
            curr_pos = new_pos;
        }

        if((last_pos - curr_pos).magnitude > dist_point)
        {
            foreach (GameObject go_0 in tubes_list)
            {
                tubes_list.RemoveFirst();
                Destroy(go_0);
                break;
            }
            --ring_count;
        }

        if (ring_count < ring_limit)
        {
            Create_Ring();
            ++ring_count;
        }
        
    }

    // Update is called once per frame
    void Create_Ring()
    {
        GameObject go = (GameObject)Instantiate(Resources.Load("TubeSpawnPrefab"));
        Vector3 new_pos = last_pos;
        if(ring_count < (ring_limit-1))
            new_pos.z -= 70;
        go.transform.position = new_pos;
        last_pos = new_pos;
        tubes_list.AddLast(go);
    }
}
