using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MissionItems : MonoBehaviour
{
    public TextMeshProUGUI _tmpMisionTitle;
    public TextMeshProUGUI _tmpMisionStep;
    public BaseMissionBehavior _behavior;
    public void AssignBehaviour(Mission_ID id)
    {
        _behavior = System.Activator.CreateInstance(EnumUtility.GetStringType(id)) as BaseMissionBehavior;
        _behavior.DoMissions();
        _tmpMisionTitle.SetText(_behavior.ContentMission);
        _tmpMisionStep.SetText(_behavior._CurrentStep.ToString() + " / " + _behavior._MissionStep.ToString());
    }

}
