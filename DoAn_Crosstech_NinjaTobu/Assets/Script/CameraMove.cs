using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform CharactorTransform;
    public Transform LimitTransform;
    public float SpeedCamUp;
    public bool IsPlayLevel = false;
    public float Offset;
    // Start is called before the first frame update
    private void Awake()
    {
    }
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        if (IsPlayLevel)
        {
            float height_Camera = Camera.main.orthographicSize;
            if (Mathf.Abs(transform.position.y + height_Camera) < LimitTransform.position.y + Offset)
            {
                AutoMoveUp_Camera();
                if (CharactorTransform)
                    if (CharactorTransform.position.y > transform.position.y)
                    {
                        transform.position = new Vector3(transform.position.x, CharactorTransform.position.y, transform.position.z);
                    }
            }
        }
    }
    public void FindObject()
    {
        LimitTransform = GameObject.Find("Land Limit").transform;
    }
    private void AutoMoveUp_Camera()
    {
        transform.position += new Vector3(0f, 1f, 0f) * SpeedCamUp * Time.deltaTime;
    }
}
