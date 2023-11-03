using UnityEngine;
using System.Collections;

public class DoorChallenge : Challenge
{
    //this class represents the Door challenges that the player encounters

    //---VARIABLES---
    //stores the different states that the Door challenge could exist in
    private enum DoorState{
        WaitingForPlayer,
        PlayerAttempting,
        Completed
    }
    //stores the current state of the Door Challenge
    private DoorState CurrentState = DoorState.WaitingForPlayer; //Default State 

    //---METHODS---
    //constructor
    public DoorChallenge(Question question) : base(question){ }

    //when starting a door challenge
    private void Start()
    {
        // Initialize the challenge, e.g., set the question, UI, etc.
    }

    private void OnTriggerEnter(Collider other)
    {
        //the trigger should do nothing if the state is not currently waiting for the player - initiate attempting state
        if (CurrentState == DoorState.WaitingForPlayer){ 
            HandleTriggerEvent(DoorState.PlayerAttempting);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //the trigger should only do something if the player was in a state of attemtping - return to waiting
        if (CurrentState == DoorState.PlayerAttempting){ 
            HandleTriggerEvent(DoorState.WaitingForPlayer);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        //This is where a player can obtain completed status - or have a fail trigger - FailChallenge(): 
        //we can handle this with two dedicated functions - CorrectAnswer() and WrongAnswer():
        // Handle transitions or behaviors while the player stays within the collider.
        // Determine correctness of answers and transition accordingly.
        // Update UI or other interactions based on player actions.
    }

    private void HandleTriggerEvent(DoorState nextState)
    {
        // Handle state transitions and state-specific logic here
        switch (nextState)
        {
            case DoorState.PlayerAttempting: 
                StartChallenge(); // StartChallenge behavior
                break;
            case DoorState.WaitingForPlayer:
                ForfeitChallenge(); //ForfeitChallenge behavior
                break;
            case DoorState.Completed:
                FinishChallenge(); // FinishChallenge behavior
                break;
        }

        // Update the current state to the next state to reflect the transition
        currentState = nextState;
    }

    //called when starting a challenge
    public override void StartChallenge()
    {
        currentState = DoorState.PlayerAttempting;
        // Handle UI or door interactions specific to starting the challenge
    }

    //called when a challenge is completed
    public override void FinishChallenge()
    {
        currentState = DoorState.Completed;
        // Handle UI or door interactions specific to finishing the challenge
    }

    //called when a challenge is forfeited
    public override void ForfeitChallenge()
    {
        currentState = DoorState.WaitingForPlayer;
    }

    //called when the player gets a wrong answer
    public override void FailChallenge()
    {
        //Trigger actions for a wrong answer like Trial account
        // Handle UI or door interactions specific to failing the challenge
    }
}
