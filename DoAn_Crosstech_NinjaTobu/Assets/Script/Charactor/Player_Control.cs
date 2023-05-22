using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Control : BaseControl
{
    // Start is called before the first frame update
    void Start()
    {
        Lastposition = Vector2.zero;
        Rb = GetComponent<Rigidbody2D>();
        Arrow_ = transform.GetChild(0).gameObject;
        Arrow_.transform.localScale = new Vector3(Arrow_.transform.localScale.x, 0f, Arrow_.transform.localScale.z);
    }
    // Update is called once per frame
    void Update()
    {
        GetTouch();
        Distance_Player();
    }
    public override void GetTouch()
    {
        base.GetTouch();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag =="Wall")
            ClaimWall();
        if (collision.gameObject.tag == "Finish")
            Player_Die();
    }
}