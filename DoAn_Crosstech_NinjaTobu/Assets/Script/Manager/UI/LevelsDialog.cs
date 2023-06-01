using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelsDialog : BaseDialog
{
    public Transform _TransformItem;
    private LevelItem _PrefabItem;
    public LevelItem _PrefabItemComplete;
    public LevelItem _PrefabItemLock;
    public List<LevelItem> _Items;
    public LevelHandler _handler;
    public void CreateItems(LevelConfig config, bool IsComplete)
    {
        _PrefabItem = IsComplete ? _PrefabItemComplete : _PrefabItemLock;
        LevelItem newItem = Instantiate<LevelItem>(this._PrefabItem,this._TransformItem);
        newItem.Dialog_Parent = this.GetComponent<DialogConainter>();
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
