using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnermy : MonoBehaviour
{
    public GameObject Player;
    public virtual void PlayerKill(GameObject Object)
    {
        if(Object.tag =="Player")
            Destroy(this.gameObject);
    }
    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
