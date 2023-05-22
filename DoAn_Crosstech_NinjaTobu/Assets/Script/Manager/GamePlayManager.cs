using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayManager :MonoSingleton<GamePlayManager>
{
    public GameObject Id_Skin;
    public int Score_player;
    public void StartGame(Userdata GameData)
    {
        Score_player = 0;
        Instantiate(Id_Skin, new Vector3(0, 0, 0), Quaternion.identity);
    //    Instantiate(Id_Skin, new Vector3(0, 0, 0), Quaternion.identity);
    }
    public void PlayerDeath()
    {
      //  EnermyManager.Instance.PauseGane();
    }


}
