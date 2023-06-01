using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog_Retry : MonoBehaviour
{
    public void Click_RetryGame()
    {

    }
    public void Click_GoHome()
    {
        GameManager.Instance.OnHomeScene();
    }
}
