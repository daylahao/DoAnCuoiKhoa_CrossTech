using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelsDialog : BaseDialog
{
    public Transform _TransformItem;
    public LevelItem _PrefabItem;
    public List<LevelItem> _Items;
    public LevelHandler _handler;
    public void CreateItems(LevelConfig config, bool IsComplete)
    {
        LevelItem newItem = Instantiate<LevelItem>(this._PrefabItem,this._TransformItem);
        newItem.ParseData(config,IsComplete,OnChooseLevel);
        _Items ??= new List<LevelItem>();
        _Items.Add(newItem);
    }
    public void ParseData(List<LevelConfig> levelConfigs,int CompleteLevel,LevelHandler _Handler)
    {
        Debug.Log(CompleteLevel.ToString());
        _handler = _Handler;
        for (int i = 0; i < levelConfigs.Count; i++)
        { 
            CreateItems(levelConfigs[i], levelConfigs[i]._LevelID<= CompleteLevel);
        }
    }
    public void OnChooseLevel(LevelConfig config)
    {
        _handler?.OnChooseRoom(config);
    }
}
