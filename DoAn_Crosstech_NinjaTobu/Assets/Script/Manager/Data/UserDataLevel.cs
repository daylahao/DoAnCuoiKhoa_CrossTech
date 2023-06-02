using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class UserDataLevel
{
    public static UserDataLevel Instance => GameDataManager.Instance.data._LevelData;
    public int _CurrentLevelCompleted;
    public int _HighScore;
    public void NewUser()
    {

        _CurrentLevelCompleted = 5;
        _HighScore = 0;
    }
    public void OpenApp()
    {

    }
    public void UpdateCompleteLevel()
    {
        _CurrentLevelCompleted++;
    }
}
