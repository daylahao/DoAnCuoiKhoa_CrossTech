using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class BaseEnermy : MonoBehaviour
{
    public GameObject Player;
    public float time_flipX = 2f;
    public float time_;
    public Animator _animator;
    public bool CompleteMap=false;
    public virtual void PlayerKill(GameObject Object)
    {
        if(Object.tag =="Player")
            Destroy(this.gameObject);
    }
    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
    public virtual void Flip_X()
    {
        time_ += Time.deltaTime;
        if(time_>= time_flipX)
        {
            this.transform.localScale = new Vector3(-this.transform.localScale.x, this.transform.localScale.y, this.transform.localScale.z);
            time_ = 0;
        }
    }
}
