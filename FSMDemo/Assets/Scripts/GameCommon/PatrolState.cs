/**
 * 创建者：栾浩元
 * 描述：巡逻状态
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : FSMState
{
    public PatrolState(FSMSystem fsm) : base(fsm)
    {
        this.id = StateID.PATROL;
    }
    public override void Act(GameObject player, GameObject npc)
    {

    }

    public override void Reason(GameObject player, GameObject npc)
    {

    }

    public override void DoBeforLeave()
    {
        Debug.Log("leave current state:" + id.ToString());
    }

    public override void DoBeforEnter()
    {
        Debug.Log("enter current state:" + id.ToString());
    }
}