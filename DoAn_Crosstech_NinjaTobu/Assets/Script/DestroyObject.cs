using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    private void OnBecameInvisible()
    {
        Destroy(this.gameObject.transform.parent.parent.gameObject);
    }
}
