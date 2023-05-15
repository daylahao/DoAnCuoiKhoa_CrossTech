using UnityEngine;

public class EnermyManager : MonoSingleton<EnermyManager>
{
    public GameObject Creep_Enermy;
    public GameObject Boss_Enermy;
    private bool IsStartGame;
    float Timer;
    public float speed_spawn = 1f;
    public void StartGame()
    {
        IsStartGame = true;
        Timer = Time.time;
    }
    public void PauseGane()
    {
        IsStartGame = false;
        Timer = 0;
    }
    public void Update()
    {
        if (IsStartGame)
        {
            
        }
    }
}

