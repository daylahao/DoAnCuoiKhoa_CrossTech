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
        _Dialog = GameManager.Instance.OnShowDialog<LevelsDialog>("Dialog/DialogLevelItem_Container");
        _Dialog.ParseData(_Configs._Level, _Datas._CurrentLevelCompleted, this);
    }
    public void OnChooseRoom(LevelConfig Config)
    {
        GameManager.Instance.OnJonGame(Config);
    }
    public LevelConfig GetLevel(int Level_Id)
    {
        return _Configs.GetConfigID(Level_Id-1);   
    }
}
