using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMSystem
{
    private List<FSMState> states;

    private StateID currentStateID;
    public StateID CurrentStateID { get { return currentStateID; } }

    private FSMState currentState;
    public FSMState CurrentState { get { return currentState; } }

    private GameObject player;

    private GameObject npc;

    public FSMSystem(GameObject player,GameObject npc)
    {
        states = new List<FSMState>();
        this.player = player;
        this.npc = npc;
    }

    public void Update()
    {
        currentState.Act(player, npc);
        currentState.Reason(player, npc);
    }

    public void AddState(FSMState id)
    {
        if (id == null)
        {
            Debug.LogError("null id is not allowed!!");
            return;
        }

        if (states.Count == 0)
        {
            states.Add(id);
            currentState = id;
            currentStateID = id.ID;
            return;
        }

        foreach (FSMState fsmState in states)
        {
            if (fsmState.ID == id.ID)
            {
                Debug.LogError(id.ID.ToString() + "has already exist");
                return;
            }
        }

        states.Add(id);
    }

    public void DeleteState(StateID id)
    {

        if (id == StateID.NULL)
        {
            Debug.LogError("id is not allowed null");
            return;
        }
        
        foreach(FSMState fsmState in states)
        {
            if(fsmState.ID == id)
            {
                states.Remove(fsmState);
                break;
            }
        }

        Debug.LogError("you will delete" + id.ToString() + "is not exist");
    }

    public void PerformTransition(Transition trans)
    {
        if(trans == Transition.NULL)
        {
            Debug.LogError("trans is not allowed null");
            return;
        }

        StateID id = currentState.GetOutPutState(trans);

        if(id == StateID.NULL)
        {
            Debug.LogError("trans corrponsing state is null");
            return;
        }

        currentStateID = id;

        foreach(FSMState fsmState in states)
        {
            if(fsmState.ID == currentStateID)
            {
                this.currentState.DoBeforLeave(player,npc);
                currentState = fsmState;
                this.currentState.DoBeforEnter(player,npc);
                break;
            }
        }

    }


}
