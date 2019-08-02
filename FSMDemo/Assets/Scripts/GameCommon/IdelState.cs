/**
 * 创建者：栾浩元
 * 描述：
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdelState : FSMState
{
    // base 是调用基类的有参数构造函数
    // 因为在子类不能直接继承父类的构造函数
    public IdelState(FSMSystem fsm) : base(fsm)
    {
        // 相当于ts中的 super.()
        this.id = StateID.IDEL;
    }

    public override void Act(GameObject player, GameObject npc)
    {
       
    }

    public override void Reason(GameObject player, GameObject npc)
    {
        if (Time.time > 2)
        {
            fsm.PerformTransition(Transition.NO_SEE_PLAYER);
        }
    }

    public override void DoBeforLeave(GameObject player,GameObject npc)
    {
        Debug.Log("leave current state:" + id.ToString());
    }

    public override void DoBeforEnter(GameObject player, GameObject npc)
    {
        Debug.Log("enter current state:" + id.ToString());
    }
}