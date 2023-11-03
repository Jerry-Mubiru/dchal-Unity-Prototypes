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
    private DoorState CurrentState = WaitingForPlayer;

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
        HandleTriggerEvent(DoorState.PlayerAttempting);
    }

    private void OnTriggerExit(Collider other)
    {
        HandleTriggerEvent(DoorState.WaitingForPlayer);
    }

    private void OnTriggerStay(Collider other)
    {
        // Handle transitions or behaviors while the player stays within the collider.
        // Determine correctness of answers and transition accordingly.
        // Update UI or other interactions based on player actions.
    }

    private void HandleTriggerEvent(DoorState nextState)
    {
        // Handle state transitions and state-specific logic here
        switch (nextState)
        {
            case DoorState.WaitingForPlayer:
                StartChallenge(); // StartChallenge behavior
                break;
            case DoorState.PlayerAttempting:
                // Handle UI or door interactions for this state
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

    //called when the player gets a wrong answer
    public override void FailChallenge()
    {
        currentState = DoorState.WaitingForPlayer;
        // Handle UI or door interactions specific to failing the challenge
    }
}
