using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelsDialog : BaseDialog
{
    public Transform _TransformItem;
    public LevelItem _PrefabItem;
    public List<LevelItem> _Items;
    public void CreateItems(LevelConfig config)
    {
        LevelItem newItem = Instantiate<LevelItem>(this._PrefabItem, this._TransformItem);
        newItem.ParseData(config);
        _Items ??= new List<LevelItem>();
        _Items.Add(newItem);
    }
    public void ParseData(List<LevelConfig> levelConfigs)
    {
        for(int i = 0; i < levelConfigs.Count; i++)
        { 
            CreateItems(levelConfigs[i]);
        }
    }
}
