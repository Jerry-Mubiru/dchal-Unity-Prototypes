using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class defines a generic state machine for a challenge of the entire game
public class ChallengeStateMachine : IStateMachine<ChallengeStateMachine.ChallengeState>
{
    // Stores the possible Challenge states for the state machine
    public enum ChallengeState{
        WaitingForPlayer,
        PlayerAttempting,
        Completed
    }

    //overriding the get default state method - defines teh default state for this state machine
    protected override ChallengeState GetDefaultState(){
        return ChallengeState.WaitingForPlayer;
    }

    //Depending on the EventHandler information
    protected void HandleTriggerEvent(ChallengeState nextState) //this function initiates events caused by state changes on all challenges
    {
        // Handle state transitions and state-specific logic here
        switch (nextState)
        {
            case ChallengeState.PlayerAttempting: 
                //OnChallengeStart(); // StartChallenge behavior
                break;
            case ChallengeState.WaitingForPlayer:
                //OnAttempCancel(); //ForfeitChallenge behavior
                break;
            case ChallengeState.Completed:
                //OnChallengePass(); // FinishChallenge behavior
                break;
        }
        // Update the current state to the next state to reflect the transition
        ChangeState(nextState);
    }
}
