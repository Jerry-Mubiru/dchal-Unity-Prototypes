using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class defines the base definition for any state machine in the game
public abstract class IStateMachine<IState> : MonoBehaviour where IState : System.Enum
 {
    //stores the current active state in this State machine among its siblings 
    protected IState currentState; 
    //stores the default State of this state machine, the entry state
    protected IState defaultState;

    //start method to set the current State to the default state at the beginning
    protected virtual void Awake(){
        defaultState = GetDefaultState();
        ChangeState(defaultState);
    }

    //default method that must be overriden to sure that a default state is set with its return value
    protected abstract IState GetDefaultState();

    //returns the current state of this state machine
    public IState GetCurrentState(){
        return currentState;
    }

    //method to handle the changing of states for this state Machine
    public void ChangeState(IState newState){
        //sets the current state to the new State
        currentState  = newState;
    }
}
