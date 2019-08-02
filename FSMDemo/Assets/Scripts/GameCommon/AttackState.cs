/**
 * 创建者：栾浩元
 * 描述：攻击状态
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : FSMState
{
    private Animator myAnimator;

    private LayerMask layerMask;

    private float horizatolValue;

    public AttackState(FSMSystem fsm) : base(fsm)
    {
        this.id = StateID.ATTACK;
    }
    public override void Act(GameObject player, GameObject npc)
    {
        if (myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            return;
        }

        this.myAnimator.Play("Attack");
    }

    public override void Reason(GameObject player, GameObject npc)
    {
       if(Physics2D.Raycast(npc.transform.position,new Vector2(-horizatolValue, 0), 1.5f, layerMask))
       {
            return;
        }

        fsm.PerformTransition(Transition.NO_SEE_PLAYER);
    }

    public override void DoBeforLeave(GameObject player, GameObject npc)
    {
        Debug.Log("leave current state:" + id.ToString());
    }

    public override void DoBeforEnter(GameObject player, GameObject npc)
    {
        Debug.Log("enter current state:" + id.ToString());

        this.myAnimator = npc.transform.GetComponent<Enemy>().myAnimator;

        layerMask = npc.transform.GetComponent<Enemy>().layerMask;

        Vector3 tempLocalScale = npc.transform.localScale;

        horizatolValue = tempLocalScale.x;
    }
}
