using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelItem : MonoBehaviour
{
    public TextMeshProUGUI _tmplevel;
    public int _levelID;
    public LevelConfig _Config;
    public void ParseData(LevelConfig config)
    {
        this._Config = config;
        _levelID = config._LevelID;
        _tmplevel.SetText($"{config._LevelID}");
    }
}
