using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class BaseControl : MonoBehaviour
{
    public Animator _animator;
    public const string ANIMATOR_IDLE = "Charactor_Idle";
    public const string ANIMATOR_JUMP = "Charactor_Jump";
    public Rigidbody2D Rb; // Đưa vào khi người chơi start
    public GameObject Arrow_;  // Đưa vào khi người chơi start
    public float DistanceScale;
    public float Doublejump = 2;
    public float MaxScale_Y = 20f;
    public float Fore_Def = 100f;
    public float Gravity_Def = 1f;
    public Vector2 Lastposition;
    public Vector2 Currentposition;
    private float Fore = 0f;
    private Vector3 FingerBegan = Vector3.zero;
    private Vector3 FingerCurrent = Vector3.zero;
    private Vector3 DistanceMove =Vector3.zero;
    public virtual void PlayerJump_Control(Vector3 VectorRotation)
    {
        Rb.gravityScale = Gravity_Def;
        Rb.velocity = Vector3.zero;
        //Rb.velocity = new Vector2(VectorRotation.x, VectorRotation.y)* Fore;
        Rb.AddForce(new Vector3(VectorRotation.x, VectorRotation.y, 0f) * Fore * Fore_Def) ;
        if (Arrow_.transform.rotation.z > 0 && this.transform.localScale.x>0)
        {
            Flip_x();
        }
        else if (Arrow_.transform.rotation.z < 0 && this.transform.localScale.x <0)
        {
            Flip_x();
        }
        Doublejump--;
        _animator.Play(ANIMATOR_JUMP);
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
                    Time.timeScale = 0.2f;
                    if(Rb.gravityScale>0.1f)
                    Rb.gravityScale -= 5f * Time.deltaTime;
                    FingerCurrent = Camera.main.ScreenToWorldPoint(Finger.position);
                    DistanceMove = FingerCurrent - FingerBegan;
                    RotationArrow();
                    if(Doublejump>0)
                        ScaleArrow();

                }
                if(Finger.phase == TouchPhase.Ended)
                {
                    Time.timeScale = 1f;
                    if (Fore>0.5f && Doublejump>0)
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
        Fore = Power;
        if (Fore < MaxScale_Y)
            Fore += Power* Time.deltaTime;
        else Fore = MaxScale_Y;
        Arrow_.transform.localScale = new Vector3(1f, Fore + 2f, 1f);
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
    public virtual void ClaimWall()
    {
        Rb.gravityScale = 0;
        Rb.velocity = Vector2.zero;
        Doublejump = 2;
        _animator.Play(ANIMATOR_IDLE);
    }
    public virtual void Fight_Enermy()
    {

    }
    public virtual void Player_Die()
    {
        Destroy(this.gameObject);
    }
    public virtual void Distance_Player()
    {
        Currentposition = this.transform.position;
        int _Distance = Mathf.RoundToInt((Currentposition.y - Lastposition.y)*10f);
        if (_Distance >0)
        {
            GamePlayManager.Instance.Score_player += _Distance;
            GameUIManager.Instance.Update_score();
            Lastposition = Currentposition;
        }
    }
    public virtual void Flip_x()
    {
        this.transform.localScale = new Vector3(-this.transform.localScale.x, this.transform.localScale.y, this.transform.localScale.z);

    }
}
