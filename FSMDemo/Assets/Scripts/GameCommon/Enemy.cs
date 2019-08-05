/**
 * 创建者：栾浩元
 * 描述：
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private FSMSystem fsmSystem;

    private FSMState tempState;

    private GameObject player;

    private GameObject npc;

    public Animator myAnimator;

    [Header("移动速度")]
    public float moveSpeed = 0;

    [Header("碰撞层")]
    public LayerMask layerMask;

    private void Start()
    {
        this.player = GameObject.Find("Man");

        this.npc = this.transform.gameObject;

        fsmSystem = new FSMSystem(player,npc);

        tempState = new IdelState(fsmSystem);
        // tempState.AddTransition(Transition.NO_SEE_PLAYER, StateID.PATROL);
        fsmSystem.AddState(tempState);

        tempState = new AttackState(fsmSystem);
        // tempState.AddTransition(Transition.SEE_PLAYER, StateID.ATTACK);
        fsmSystem.AddState(tempState);

        tempState = new PatrolState(fsmSystem);
        // tempState.AddTransition(Transition.GAME_PAUSE, StateID.IDEL);
        // tempState.AddTransition(Transition.SEE_PLAYER, StateID.ATTACK);
        fsmSystem.AddState(tempState);
    }

    private void Update()
    {
        fsmSystem.Update();
    }
}