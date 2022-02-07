using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine
{
    public EnemyState[] states;
    public EnemyController enemyController;
    public EnemyStateId currentState;

    public EnemyStateMachine(EnemyController enemyCon)
    {
        this.enemyController = enemyCon;
        int numStates = System.Enum.GetNames(typeof(EnemyStateId)).Length;

        states = new EnemyState[numStates];
    }

    public void RegisterState(EnemyState state)
    {
        int index = (int)state.GetId();
        states[index] = state;
    }

    public EnemyState GetState(EnemyStateId stateId)
    {
        int index = (int)stateId;
        return states[index];
    }

    public void Update()
    {
        GetState(currentState)?.Update(enemyController);
    }

    public void ChangeState(EnemyStateId newState)
    {
        GetState(currentState)?.Exit(enemyController);
        currentState = newState;
        GetState(currentState)?.Enter(enemyController);
    }
}
