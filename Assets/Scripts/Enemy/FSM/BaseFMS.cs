using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseFSM
{
    public IState currentState;

    public StateId stateId;

    public Dictionary<StateId, IState> state_dictionary = new();

    public void Begin(StateId stateId)
    {
        currentState = state_dictionary[stateId];
        currentState.Enter();
        this.stateId = stateId;
    }

    public void ChangeState(StateId stateId)
    {
        currentState.Exit();
        currentState = state_dictionary[stateId];
        this.stateId = stateId;
        currentState.Enter();
    }

}
