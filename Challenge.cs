public abstract class Challenge
{
    //This abstract class represents a Generic Challenge that is presented to the player

    //stores the Question associated with this challenge
    public Question challenge_question;

    //abstract methods that are implemented by all challenges
    //called when a challenge is started
    public abstract void StartChallenge();
    //called when a challenge is completed
    public abstract void FinishChallenge();
    //called when the player gets a wrong answer on a challenge
    public abstract void FailChallenge();
    
}