/**
 * 创建者：栾浩元
 * 描述：追击状态
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : FSMState
{
    public ChaseState(FSMSystem fsm) : base(fsm)
    {
        this.id = StateID.CHASE;
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