using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayManager :MonoSingleton<GamePlayManager>
{
    public GameObject Id_Skin;
    public int Score_player;
    public GameObject Player;
    public void StartGame(Userdata GameData)
    {
        Score_player = 0;
        Player =Instantiate(Id_Skin, new Vector3(0, -1f, 0), Quaternion.identity);
        Player.GetComponent<Player_Control>().IsPlayGame = true;
        Camera.main.GetComponent<CameraMove>().CharactorTransform = Player.transform;
        Camera.main.GetComponent<CameraMove>().IsPlayLevel = true;
    }
    public void PlayerDeath()
    {
        //  EnermyManager.Instance.PauseGane();
        Camera.main.GetComponent<CameraMove>().IsPlayLevel = false;
        GameManager.Instance.OnShowDialog<MenuHomeDialog>("Dialog/DialogBackhome_Container");
    }
    public void PlayerCompleteLevel()
    {
        if(GameManager.Instance._CurrentPlayinglevel._LevelID<5)
            GameDataManager.Instance.CompleteLevel();
        SaveDataPlayer();
        GameManager.Instance.OnShowDialog<MenuHomeDialog>("Dialog/CompleteLevel_Dialog");
    }
    public void SaveDataPlayer()
    {
        GameDataManager.Instance.savedata();
    }

}
