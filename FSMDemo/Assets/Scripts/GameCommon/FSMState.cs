using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FSMState
{
    protected FSMSystem fsm;

    protected Dictionary<Transition, StateID> map = new Dictionary<Transition, StateID>();

    protected StateID id;
    public StateID ID
    {
        get
        {
            return id;
        }
    }

    public void SetState(StateID value)
    {
        id = value;
    }

    public FSMState(FSMSystem fsm)
    {
        this.fsm = fsm;
    }

    public void AddTransition(Transition transtion, StateID state)
    {
        if (transtion == Transition.NULL)
        {
            Debug.LogError("transtion must be not null");
            return;
        }

        if (state == StateID.NULL)
        {
            Debug.LogError("state must be not null");

            return;
        }

        if (map.ContainsKey(transtion))
        {
            Debug.LogError("had contain transtion");
            return;
        }

        map.Add(transtion, state);

        Debug.Log("current trans is:" + transtion + "  current state is:" + state + "  is add success");
    }

    public void DeleteTransition(Transition transtion)
    {

        if (transtion == Transition.NULL)
        {
            Debug.LogError("transtion must be not null");
            return;
        }

        if (!map.ContainsKey(transtion))
        {
            Debug.LogError("not contain " + transtion.ToString());
            return;
        }

        map.Remove(transtion);
    }

    public StateID GetOutPutState(Transition transtion)
    {
        if (map.ContainsKey(transtion))
        {
            return map[transtion];
        }
        return StateID.NULL;
    }

    public virtual void DoBeforEnter(GameObject player,GameObject npc) { }

    public virtual void DoBeforLeave(GameObject player,GameObject npc) { }

    public abstract void Act(GameObject player, GameObject npc);

    public abstract void Reason(GameObject player, GameObject npc);
}