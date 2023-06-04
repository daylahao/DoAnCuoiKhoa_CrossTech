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
    public const string ANIMATOR_DIE = "Creep_Die";
    public virtual void PlayerKill(GameObject Object)
    {
        if (Object.tag == "Player")
        {
            DestroyEnermy();
        }
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
    public void DestroyEnermy()
    {
        Destroy(this.gameObject);
    }
}
