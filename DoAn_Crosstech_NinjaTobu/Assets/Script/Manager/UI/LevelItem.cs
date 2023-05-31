using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelItem : MonoBehaviour
{
    public GameObject _PrefabIscomple;
    public TextMeshProUGUI _tmplevel;
    public int _levelID;
    public LevelConfig _Config;
    public System.Action<LevelConfig> OnClickChoseRoom;
    public void ParseData(LevelConfig config,bool IsComplete, System.Action<LevelConfig> cb)
    {
        this._Config = config;
        _levelID = config._LevelID;
        _tmplevel.SetText($"{config._LevelID}");
        OnClickChoseRoom = cb;
        _PrefabIscomple.SetActive(false);
    }
    public void OnClickChooseLevel()
    {
        OnClickChoseRoom?.Invoke(this._Config);
    }
}
