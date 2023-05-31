using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSpawner : MonoSingleton<MapSpawner>
{
    public Transform _RootTranForm;
    public CameraMove cam;
    private void Start()
    {
        OnJoneGame(GameManager.Instance._CurrentPlayinglevel._PrefabLevel);
        GamePlayManager.Instance.StartGame(GameDataManager.Instance.data);
        cam.FindObject();
    }
    public void OnJoneGame(GameObject Prefab)
    {
        Instantiate(Prefab, _RootTranForm);
    }
}
