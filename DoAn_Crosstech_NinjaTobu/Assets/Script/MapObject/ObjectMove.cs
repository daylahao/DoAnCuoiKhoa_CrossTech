using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMove : MonoBehaviour
{
    public bool _Horital,_Vectical,_Rotation,_TriggerWall;
    private float Move_x = 1f, Move_y = 1f;
    public float Object_Speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_Horital)
        {
            transform.position += new Vector3(Move_x, 0f, 0f) * Object_Speed * Time.deltaTime;
        }
        if (_Vectical)
        {
            transform.position += new Vector3(0f, Move_y, 0f) * Object_Speed * Time.deltaTime;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            if (_Horital)
            {
                Move_x = -Move_x;
            }
            if (_Vectical)
            {
                Move_y = -Move_y;
            }
        }
    }
}
