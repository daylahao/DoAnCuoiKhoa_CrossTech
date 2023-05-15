using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Userdata
{
    public List<int> high_score;
    public string user_name="N";
    public int id_Skin;
    public static Userdata Instance => GameDataManager.Instance.data;
}

