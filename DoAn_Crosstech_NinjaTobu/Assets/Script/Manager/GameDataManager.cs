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
            }
        }
        catch(System.Exception e)
        {
            Debug.LogException(e);
        }

    }
    public void savedata()
    {
        data.high_score.Add(GamePlayManager.Instance.Score_player);
        string jsonData = JsonUtility.ToJson(data);
        Debug.Log(jsonData);
        PlayerPrefs.SetString(data.user_name, jsonData);
        PlayerPrefs.Save();
    }
    public void CreateUser()
    {
        Userdata.Instance.NewUser();
    }
    public void StartGame()
    {

    }
}
