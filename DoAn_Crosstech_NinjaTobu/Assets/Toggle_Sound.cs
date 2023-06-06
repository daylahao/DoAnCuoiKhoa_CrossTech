using UnityEngine;
using UnityEngine.UI;

public class Toggle_Sound : BaseDialog
{
    public Sprite FxMute;
    public Sprite FxOn;
    public Sprite MusicMute;
    public Sprite MusicOn;
    public Image ToggleSFX;
    public Image ToggleMusic;
    bool OnSFX;
    bool OnMusic;
    public void Start()
    {
        OnInit();
        ToggleSFX.sprite = OnSFX == true ? FxOn : FxMute;
        ToggleMusic.sprite = OnMusic == true ? MusicOn : MusicMute;
    }
    public void Toggle_Sfx()
    {
        SoundManager.Instance._fxSoundBase.GetComponent<AudioSource>().mute = OnSFX;
        SoundManager.Instance.isOnFx = !OnSFX;
        OnSFX = !OnSFX;
        ToggleSFX.sprite = OnSFX == true ? FxOn : FxMute;
    }
    public void Toggle_Music()
    {
        SoundManager.Instance._fxMusicBGBase.GetComponent<AudioSource>().mute = OnMusic;
        SoundManager.Instance.isOnMusic = !OnMusic;
        OnMusic = !OnMusic;
        ToggleMusic.sprite = OnMusic == true ? MusicOn : MusicMute;
    }
    public void OnInit()
    {
        OnSFX = SoundManager.Instance.isOnFx;
        OnMusic = SoundManager.Instance.isOnMusic;
        SoundManager.Instance._fxSoundBase.GetComponent<AudioSource>().mute = !OnSFX;
        SoundManager.Instance._fxMusicBGBase.GetComponent<AudioSource>().mute = !OnMusic;
    }
}
