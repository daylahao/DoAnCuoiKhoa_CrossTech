using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayManager : MonoSingleton<GamePlayManager>
{
    public GameObject Id_Skin;
    public int Score_player;
    public GameObject Player;
    public SoundConfigs SoundFX;
    public bool IsShowDialogComplete=false;
    public void StartGame(Userdata GameData)
    {
        Score_player = 0;
        Player = Instantiate(Id_Skin, new Vector3(0, -4.1f, 0), Quaternion.identity);
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
        if (IsShowDialogComplete == false)
        {
            if (GameManager.Instance._CurrentPlayinglevel._LevelID < 5)
            {
                GameDataManager.Instance.CompleteLevel();
                GameManager.Instance.OnShowDialog<MenuHomeDialog>("Dialog/CompleteLevel_Dialog");
            }
            else
                GameManager.Instance.OnShowDialog<MenuHomeDialog>("Dialog/CompleteGame_Dialog");
            IsShowDialogComplete = true;
            SoundManager.Instance.PlayFx("Complete_Sound");
            SaveDataPlayer();
        }
    }
    public void SaveDataPlayer()
    {
        GameDataManager.Instance.savedata();
    }
    public void PlayerJump_Sound()
    {
        SoundManager.Instance.PlayFx("Jump_Sound");
    }
    public void PlayerEnterWall_Sound()
    {
        SoundManager.Instance.PlayFx("EnterWall_1");
    }
}

