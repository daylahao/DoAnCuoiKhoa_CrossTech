using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogConainter : BaseDialog
{
    public GameObject _PreFabDialog;
    public override void ClickCloseDialog()
    {
        base.ClickCloseDialog();
        Destroy(this.gameObject);
    }
    public void BackDialog()
    {
        ClickCloseDialog();
        GameManager.Instance.OnShowDialog<DialogConainter>("Dialog/DialogBtn_Home_Container");
    }
}
