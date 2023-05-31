using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSpawner : MonoSingleton<MapSpawner>
{
    public Transform _RootTranForm;
    private void Start()
    {
        OnJoneGame(GameManager.Instance._CurrentPlayinglevel._PrefabLevel);
    }
    public void OnJoneGame(GameObject Prefab)
    {
        Instantiate(Prefab, _RootTranForm);
    }
}
