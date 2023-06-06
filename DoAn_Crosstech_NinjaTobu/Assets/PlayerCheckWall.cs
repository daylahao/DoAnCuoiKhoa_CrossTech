using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheckWall : MonoBehaviour
{
    public GameObject PlayerBody;
    public bool Iswallup;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Iswallup == false) {
            PlayerBody.GetComponent<Player_Control>().IsClamb = true;
        }
        else
        {
            PlayerBody.GetComponent<Player_Control>().IsClambUp = true;
        }
    }
}
