using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionDialog : BaseDialog
{
    public MissionHandler _handler;
    private void Start()
    {
        _handler.OnInit();
        _handler.GetMissions();
    }
    public override void ClickBackHome()
    {
        ClickCloseDialog();
        GameManager.Instance.OnShowDialog<MenuHomeDialog>("Dialog/DialogBtn_Home_Container");
    }
}
