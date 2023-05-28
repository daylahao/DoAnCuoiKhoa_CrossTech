using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform CharactorTransform;
    public Transform LimitTransform;
    public float SpeedCamUp;
    public float Offset;
    // Start is called before the first frame update
    void Start()
    {
        CharactorTransform = GameObject.Find("Player").transform;
        LimitTransform = GameObject.Find("Land Limit").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (LimitTransform.position.y > transform.position.y * 1.5)
        {
            AutoMoveUp_Camera();
            if(CharactorTransform)
            if (CharactorTransform.position.y > transform.position.y)
            {
                transform.position = new Vector3(transform.position.x, CharactorTransform.position.y + Offset, transform.position.z);
            }
        }
    }
    private void AutoMoveUp_Camera()
    {
        transform.position += new Vector3(0f, 1f, 0f) * SpeedCamUp * Time.deltaTime;
    }
}
