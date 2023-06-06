using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMissionBehavior
{
    public virtual Mission_ID ID => Mission_ID.COMPLETE_ALLLEVEL;
    public string ContentMission;
    public int _CurrentStep;
    public int _MissionStep;
    public virtual void DoMissions()
    {
    }

}

public enum Mission_ID
{
    [Type(typeof(COMPLETE_LEVELONE_MissionBehavior))]
    COMPLETE_LEVELONE,
    [Type(typeof(COMPLETE_ALLLEVEL_MissionBehavior))]
    COMPLETE_ALLLEVEL,
    [Type(typeof(COMPLETE_LEVELTWO_KILL_MissionBehavior))]
    COMPLETE_LEVELTWO_KILL,
}
public class COMPLETE_LEVELONE_MissionBehavior : BaseMissionBehavior
{
    public override Mission_ID ID => Mission_ID.COMPLETE_LEVELONE;
    public override void DoMissions()
    {
        ContentMission = "Hoàn thành màn chơi đầu tiên";
        if (GameDataManager.Instance.data._LevelData._CurrentLevelCompleted >=2)
            _CurrentStep = 1;
        else
            _CurrentStep = 0;
        _MissionStep = 1; 
    }
}
public class COMPLETE_ALLLEVEL_MissionBehavior: BaseMissionBehavior
{
    public override Mission_ID ID => Mission_ID.COMPLETE_ALLLEVEL;
    public override void DoMissions()
    {
        ContentMission = "Hoàn thành đến Level 5";
        _CurrentStep = GameDataManager.Instance.data._LevelData._CurrentLevelCompleted;
        _MissionStep = 5;
    }
}
public class COMPLETE_LEVELTWO_KILL_MissionBehavior: BaseMissionBehavior
{
    public override Mission_ID ID => Mission_ID.COMPLETE_LEVELTWO_KILL;
    public override void DoMissions()
    {
        ContentMission = "Hoàn Thành Level 2";
        if (GameDataManager.Instance.data._LevelData._CurrentLevelCompleted >= 3)
            _CurrentStep = 2;
        else
            _CurrentStep=GameDataManager.Instance.data._LevelData._CurrentLevelCompleted;
         _MissionStep = 2;
    }   
}