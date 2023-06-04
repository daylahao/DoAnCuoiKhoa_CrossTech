using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : MonoSingleton<GameUIManager>
{
    public TextMeshProUGUI Text_Score;
    public TextMeshProUGUI Text_highscore;
    public LevelHandler _LevelHandler;
    public void Update_Highscore_text()
    {
        //GameDataManager.Instance.data.high_score.Sort();
        //List<int> scores = GameDataManager.Instance.data.high_score;
        //Text_highscore.text = scores[scores.Count - 1].ToString();
    }
    public void Update_score()
    {
        Text_Score.text = GamePlayManager.Instance.Score_player.ToString();    
    }
    public void Reset_Score()
    {
        GamePlayManager.Instance.Score_player = 0;
        Text_Score.text = GamePlayManager.Instance.Score_player.ToString();
    }
    public void OnInit()
    {
        _LevelHandler?.InitHandler();
        //LoadMenu();
    }
    public void LoadMenu()
    {
        GameManager.Instance.OnShowDialog<MenuHomeDialog>("Dialog/DialogBtn_Home_Container");
    }
    public void load_ToggleSound()
    {
        GameManager.Instance.OnShowDialog<MenuHomeDialog>("Dialog/ContianerSound_Dialog");
    }
    public LevelConfig NextLevel(int LevelCurrent_Id)
    {
        LevelCurrent_Id++;
        return _LevelHandler.GetLevel(LevelCurrent_Id);
    }
}
