using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserDataLevel : MonoBehaviour
{
    public static UserDataLevel Instance => GameDataManager.Instance.data._LevelData;
    public int _CurrentLevelCompleted;
    public int _HighScore;
    public void NewUser()
    {
        _CurrentLevelCompleted = 0;
        _HighScore = 0;
    }
    public void OpenApp()
    {

    }
}
