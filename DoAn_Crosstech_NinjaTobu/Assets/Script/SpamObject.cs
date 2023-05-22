using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpamObject : MonoBehaviour
{
    public GameObject Object;
    public Camera Cam;
    float DistanceBegin;
    float PosBegin;
    // Start is called before the first frame update
    void Start()
    {
        DistanceBegin = Mathf.Abs(transform.position.y - Cam.transform.position.y);
        PosBegin = transform.position.y;
        Instantiate(Object, new Vector3(-4.19f, transform.position.y, transform.position.z), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        float DistanceCurrent = Mathf.Abs(transform.position.y - PosBegin);
        if (DistanceCurrent >= DistanceBegin)
        {
            Instantiate(Object, new Vector3(-4.19f,transform.position.y,transform.position.z), Quaternion.identity);
            PosBegin = transform.position.y;
        }
        
    }
}
