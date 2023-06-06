using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog_Complete : BaseDialog
{
    public void Click_nextlevel()
    {
        ClickCloseDialog();
        GamePlayManager.Instance.IsShowDialogComplete = false;
        GameManager.Instance.NextLevel();
    }
}
