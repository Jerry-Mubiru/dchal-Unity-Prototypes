using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChallengeController : MonoBehaviour
{
    //stores reference to this controller's State Machine
    public ChallengeStateMachine stateMachine;

    //concrete methods that are implemented by all challenges
    protected void OnTriggerEnter(Collider other) //when a player enters the challenge zone
    {
        if(other.GetComponent<Collider>().tag == "Player"){
            //the trigger should do nothing if the state is not currently waiting for the player - initiate attempting state
            if (stateMachine.GetCurrentState() == stateMachine.ChallengeState.WaitingForPlayer){ 
                stateMachine.HandleTriggerEvent(stateMachine.ChallengeState.PlayerAttempting);
            }
        }
    }

    protected void OnTriggerStay(Collider other)
    {
        if(other.GetComponent<Collider>().tag == "Player"){
            //the trigger should only do something if the player was in a state of attempting
            if (stateMachine.GetCurrentState() == stateMachine.ChallengeState.PlayerAttempting){
                //if the player succeeds or fails - we update state accordingly
                //Has the player made an answer attempt
                if(AttemptChallenge()){
                    //Okay now is the attempt right or wrong
                    if(IsCorrectSolution()){
                        //challenge completion
                        stateMachine.HandleTriggerEvent(stateMachine.ChallengeState.Completed);  
                    }
                    else{
                        //they fail the challenge
                        OnChallengeFail();
                    }
                }
            }
        }
    }

    protected void OnTriggerExit(Collider other) //when the player leaves the challenge zone
    {
        if(other.GetComponent<Collider>().tag == "Player"){
            //the trigger should only do something if the player was in a state of attempting - return to waiting
            if (stateMachine.GetCurrentState() == stateMachine.ChallengeState.PlayerAttempting){ 
                stateMachine.HandleTriggerEvent(stateMachine.ChallengeState.WaitingForPlayer);
            }
        }
    }

}
