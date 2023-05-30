using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Game/LevelConfigs",fileName ="LevelConfigs")]
public class LevelConfigs : ScriptableObject
{
    #region SingleTon
    private static LevelConfigs _isntance;
    public static LevelConfigs Instance
    {
        get
        {
            if (_isntance == null)
            {
                _isntance = GameManager.Instance.GetResourceFile<LevelConfigs>("Configs/LevelConfigs");
             
            }
            return _isntance;
        }
    }
    #endregion
    public List<LevelConfig> _Level;
    public List<LevelConfig> GetConfig()
    {
        return _Level;
    }
} 
[System.Serializable]
public class LevelConfig
{
    public int _LevelID;
    public GameObject _PrefabLevel;
    public long _RewardWhenComplete;
}
