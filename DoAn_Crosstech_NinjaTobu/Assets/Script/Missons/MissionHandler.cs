using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionHandler : MonoBehaviour
{
    public MissionItems[] _Item;
    public List<Mission_ID> missions;
    public Mission_ID missionid;
    public void OnInit()
    {
       missions = new List<Mission_ID> { Mission_ID.COMPLETE_LEVELONE,Mission_ID.COMPLETE_ALLLEVEL, Mission_ID.COMPLETE_LEVELTWO_KILL };
    }
    public void GetMissions()
    {

        for(int i = 0; i < 3; i++)
        {
            missionid = missions[i];
            _Item[i].AssignBehaviour(missionid);
        }
    }
}
