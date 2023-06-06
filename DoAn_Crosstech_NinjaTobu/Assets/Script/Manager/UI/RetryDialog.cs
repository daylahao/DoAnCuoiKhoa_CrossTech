using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetryDialog : MonoBehaviour
{
    public void Click_RetryGame()
    {
        GameManager.Instance.LoadSceneGame();
    }
    public void Click_GoHome()
    {
        GameManager.Instance.OnHomeScene();
    }
}
