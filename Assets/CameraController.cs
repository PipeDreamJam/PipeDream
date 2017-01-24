using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{


    public Vector3 offset;

    void Start()
    {

    }

    void Update()
    {
        transform.position -= offset * Time.deltaTime;
    }
}