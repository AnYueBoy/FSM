﻿/**
 * 创建者：栾浩元
 * 描述：巡逻状态
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : FSMState
{

    private Animator myAnimator;

    private float horizatolValue;

    private float moveSpeed;

    private LayerMask layerMask;
    public PatrolState(FSMSystem fsm) : base(fsm)
    {
        this.id = StateID.PATROL;
    }
    public override void Act(GameObject player, GameObject npc)
    {
        this.myAnimator.SetBool("isRun",true);

        npc.transform.localScale = new Vector3(-horizatolValue, 1, 1);

        npc.transform.Translate(new Vector3(horizatolValue * Time.deltaTime * moveSpeed, 0, 0));
        
    }

    public override void Reason(GameObject player, GameObject npc)
    {
        if(Physics2D.Raycast(npc.transform.position,new Vector2(horizatolValue, 0), 1.5f, layerMask))
        {
            this.myAnimator.SetBool("isRun", false);
            fsm.PerformTransition(Transition.SEE_PLAYER);
            return;
        }

        if (Time.time > 3.0f)
        {
            fsm.PerformTransition(Transition.GAME_PAUSE);
        }
    }

    public override void DoBeforLeave(GameObject player,GameObject npc)
    {
        Debug.Log("leave current state:" + id.ToString());
    }

    public override void DoBeforEnter(GameObject player,GameObject npc)
    {
        Debug.Log("enter current state:" + id.ToString());
        this.myAnimator = npc.transform.GetComponent<Animator>();
        Vector3 tempLocalScale = npc.transform.localScale;
        horizatolValue = tempLocalScale.x;
        moveSpeed = npc.transform.GetComponent<Enemy>().moveSpeed;
        this.layerMask = npc.transform.GetComponent<Enemy>().layerMask;
    }

  
}