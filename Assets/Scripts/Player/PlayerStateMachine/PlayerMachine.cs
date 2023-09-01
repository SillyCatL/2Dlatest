using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMachine
{
    public PlayerState currentState{ get;private set; }
    public PlayerStateId StateId;
    public Dictionary<PlayerStateId, PlayerState> keyValuePairs = new Dictionary<PlayerStateId, PlayerState>();
    public void ChangeState(PlayerStateId playerStateId)
    {
        currentState.Exit();
        currentState = keyValuePairs[playerStateId];
        StateId = playerStateId;
        currentState.Enter();
    }

    public void Begin(PlayerStateId playerStateId)
    {
        currentState = keyValuePairs[playerStateId];
        currentState.Enter();
        StateId = playerStateId;
    }
}
