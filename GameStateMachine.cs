using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class defines the master state machine of the entire game
public class GameStateMachine : IStateMachine<GameStateMachine.GameState>
{
    //stores the possible game states of this state machine
    public enum GameState{
        Login,
        StartMenu,
        LoadScreen,
        GamePlay,
        Settings,
        Achievements,
        Inventory,
        Paused,
        GameOver,
        Arsenal,
        PlayerStats
    }

    //overriding the default state method
    protected override GameState GetDefaultState(){
        return GameState.Login;
    }

    //how do we move between different states
}
