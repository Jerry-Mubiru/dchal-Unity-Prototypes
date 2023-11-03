using UnityEngine;
using System.Collections;

public abstract class Challenge : MonoBehaviour
{
    //This abstract class represents a Generic Challenge that is presented to the player

    //stores the Question associated with this challenge
    public Question question;

    //constructor
    public Challenge(Question question){
        //assign the question to the variable
        this.question = question;
    }

    //abstract methods that are implemented by all challenges
    public abstract void StartChallenge(); //called when a challenge is started

    public abstract void FinishChallenge(); //called when a challenge is completed

    public abstract void FailChallenge();  //called when the player gets a wrong answer on a challenge
}