using UnityEngine;
using System.Collections;

public abstract class Question
{
    //This abstract class represents a Generic Question that is presented to the player

    //stores the topic associated with this Question - every type of question has a topic.
    public Topic questionTopic;
    //stores the text prompt of the question
    public string questionPrompt;
}