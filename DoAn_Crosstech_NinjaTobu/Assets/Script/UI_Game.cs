using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Game : MonoBehaviour
{
    public Transform PopUpDialog;
    // Start is called before the first frame update
    private void Start()
    {
        GameManager.Instance._popUpContainer = PopUpDialog;
        load_ToggleSound();
    }
        public void load_ToggleSound()
    {
        GameUIManager.Instance.load_ToggleSound();
        SoundManager.Instance.PlayLoopBGMusic("MusicGameplay");
    }
}
