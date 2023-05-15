using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Control : BaseControl
{
    // Start is called before the first frame update
    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
        Arrow_ = transform.GetChild(0).gameObject;
       Arrow_.transform.localScale = new Vector3(Arrow_.transform.localScale.x ,0f, Arrow_.transform.localScale.z);
    }
    // Update is called once per frame
    void Update()
    {
        ClimbWall();
        GetTouch();
    }
    public override void GetTouch()
    {
        base.GetTouch();
    }
    public override void ClimbWall()
    {
        base.ClimbWall();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        EnterWall = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnterWall = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        EnterWall = false;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Rb.velocity == Vector2.zero)
        {
            EnterWall = true;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if(Rb.velocity == Vector2.zero)
        {
            EnterWall = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        EnterWall = false;
    }
}
