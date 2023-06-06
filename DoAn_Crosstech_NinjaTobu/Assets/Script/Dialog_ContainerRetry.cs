using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog_ContainerRetry : BaseDialog
{
    public void Click_RetryLevel()
    {
        ClickCloseDialog();
        GameManager.Instance.LoadSceneGame();
    }
}
