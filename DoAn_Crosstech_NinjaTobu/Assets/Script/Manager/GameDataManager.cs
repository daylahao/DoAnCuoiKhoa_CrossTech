using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameDataManager : MonoSingleton<GameDataManager>
{
    private bool IsHaveData;
    public Userdata data;
    // Start is called before the first frame update
    void Start()
    {
        loaddata();
        GameUIManager.Instance.OnInit();
        SoundManager.Instance.OnInit(data.isOnFx,data.isOnMusic);
    }
    // Update is called once per frame
    void Update()
    {
    }
    public void loaddata()
    {
        try
        {
            if (PlayerPrefs.HasKey(data.user_name)){
                string jsonData = PlayerPrefs.GetString(data.user_name);
                if (!string.IsNullOrEmpty(jsonData)) {
                    data = JsonUtility.FromJson<Userdata>(jsonData);
                }
                else
                {
                    Debug.LogError("Can Not Parse User Data" + jsonData);
                    return;
                }
            }
            else
            {
                CreateUser();
                Debug.Log("Tao Data moi");
            }
        }
        catch(System.Exception e)
        {
            Debug.LogException(e);
        }

    }
    public void savedata()
    {
        SaveStateSound();
        data.high_score.Add(GamePlayManager.Instance.Score_player);
        string jsonData = JsonUtility.ToJson(data);
        Debug.Log(jsonData);
        PlayerPrefs.SetString(data.user_name, jsonData);
        PlayerPrefs.Save();
    }
    public void SaveStateSound()
    {
        data.isOnFx = SoundManager.Instance.isOnFx;
        data.isOnMusic = SoundManager.Instance.isOnMusic;
    }
    public void CreateUser()
    {
        data.NewUser();
    }
    public void StartGame()
    {

    }
    public void CompleteLevel()
    {
        if(GameManager.Instance._CurrentPlayinglevel._LevelID == data._LevelData._CurrentLevelCompleted)
            data._LevelData._CurrentLevelCompleted++;
    }
}
