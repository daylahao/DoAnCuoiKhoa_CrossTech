using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseControl : MonoBehaviour
{
    public Rigidbody2D Rb; // Đưa vào khi người chơi start
    public GameObject Arrow_;  // Đưa vào khi người chơi start
    public float DistanceScale;
    public float MaxScale_Y = 10f;
    public float Speed_Scale= 20f;
    public float Fore_Def = 100f;
    public float Gravity_Def = 1f;
    private float Fore = 0f;
    public bool EnterWall = false;
    private Vector3 FingerBegan = Vector3.zero;
    private Vector3 FingerCurrent = Vector3.zero;
    private Vector3 DistanceMove =Vector3.zero;

    public virtual void PlayerJump_Control(Vector3 VectorRotation)
    {
        EnterWall = false;
       Rb.velocity = new Vector2(VectorRotation.x, VectorRotation.y)* Fore;
       // Rb.AddForce(new Vector3(VectorRotation.x, VectorRotation.y,0f)*Fore * Fore_Def);
    }
    public virtual void GetTouch()
    {
        if (Input.touchCount > 0)
        {
            for(int i = 0; i < Input.touchCount; i++)
            {
                Touch Finger = Input.GetTouch(i);
                if(Finger.phase == TouchPhase.Began)
                {
                    DistanceScale = 0f;
                    FingerBegan = Camera.main.ScreenToWorldPoint(Finger.position);
                }
                if (Finger.phase == TouchPhase.Moved)
                {
                    FingerCurrent = Camera.main.ScreenToWorldPoint(Finger.position);
                    DistanceMove = FingerCurrent - FingerBegan;
                    RotationArrow();
                    ScaleArrow();

                }
                if(Finger.phase == TouchPhase.Ended)
                {
                    if(Fore>0.5f)
                    PlayerJump_Control(DistanceMove);
                    CancelArrow();
                }
            }
        }
    }
    private void ScaleArrow()
    {
        float Power = Mathf.Sqrt(Mathf.Pow(DistanceMove.x, 2) + Mathf.Pow(DistanceMove.y, 2));
        float Addfore_Power = Power - DistanceScale;
        DistanceScale = Power;
        if (Arrow_.transform.localScale.y > MaxScale_Y)
        {
            Arrow_.transform.localScale = new Vector3(Arrow_.transform.localScale.x,MaxScale_Y, Arrow_.transform.localScale.z);
        }
        else
        {
            Arrow_.transform.localScale += new Vector3(0f, Addfore_Power, 0f) * Speed_Scale * Time.deltaTime;
        }
        Fore = Fore >= 10f ?10f:Arrow_.transform.localScale.y;
    }
    private void RotationArrow()
    {
        float RotZ = Mathf.Atan2(DistanceMove.x, DistanceMove.y) * Mathf.Rad2Deg;
        Arrow_.transform.rotation = Quaternion.Euler(0, 0, -RotZ);
    }
    private void CancelArrow()
    {
        Arrow_.transform.localScale = new Vector3(Arrow_.transform.localScale.x,0f, Arrow_.transform.localScale.z);
        Arrow_.transform.rotation = Quaternion.Euler(0, 0, 0);
    }
    public virtual void ClimbWall()
    {
        if (EnterWall)
        {
            Rb.gravityScale = 0f;
            Rb.velocity = Vector2.zero;
        }
        else
        {
            Rb.gravityScale = Gravity_Def;
        }
    }
    public virtual void Fight_Enermy()
    {

    }
}
