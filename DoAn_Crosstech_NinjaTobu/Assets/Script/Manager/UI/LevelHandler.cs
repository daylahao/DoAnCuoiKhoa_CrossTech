using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelHandler : MonoBehaviour
{
    public LevelsDialog _Dialog;
    public LevelConfigs _Configs;
    public UserDataLevel _Datas;
    public void InitHandler()
    {
        _Dialog = null;
        _Configs = LevelConfigs.Instance;
        _Datas = UserDataLevel.Instance;
    }
    public void ShowDialog()
    {
        _Dialog = GameManager.Instance.OnShowDialog<LevelsDialog>("DialogLevelItem_Container");
        _Dialog.ParseData(_Configs._Level);  
    }
}
