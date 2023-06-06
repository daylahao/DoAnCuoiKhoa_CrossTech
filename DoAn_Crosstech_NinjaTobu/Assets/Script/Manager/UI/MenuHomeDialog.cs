using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuHomeDialog : BaseDialog
{
    public GameObject _PreFabDialog;
    public override void ClickCloseDialog()
    {
        base.ClickCloseDialog();
        Destroy(this.gameObject);
    }
    public override void ClickBackHome()
    {
        ClickCloseDialog();
        GameManager.Instance.OnShowDialog<MenuHomeDialog>("Dialog/DialogBtn_Home_Container");
    }
    public void ShowDialog_Missions()
    {
        GameManager.Instance.OnShowDialog<MenuHomeDialog>("Dialog/Dialog_Missions");
    }
}

