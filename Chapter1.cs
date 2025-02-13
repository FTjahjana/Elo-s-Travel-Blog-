using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chapter1 : MonoBehaviour
{
    public static void StartChapter1()
    {
        StoryNode startNode = new StoryNode(
            "'Okay!! Big trip, big plans. Big future ahead.'(Psst, the enter key!!)",
            "'The Worldwide Train ~ and four whole pages of stamps, and then boom! I'll be there, I promise ~'",
            "'…Alright, alright, you probably have no idea what I’m talking about. Where do I start?'",
            "'How bout this? There are three VERY important things in this room right now.'",
            "You look around and see in Elo's hand a thick, old-looking book. Near him, you see a glittering suitcase packed full. And... you don't see anything else quite interesting.. hmmm...",
            "'Ah yeah, and before anything, if you forget how things work around here, just shout out 'help!' Maybe not here though..mmm.."
        );
        StoryNode n2book = new StoryNode(
            "Elo flips through the old, worn pages. 'My dad started this.'",
            "'His dad before him. And his dad before that. Almost a full collection.'",
            "'Almost.'"
        );  startNode.AddChoice("book", n2book);

        StoryNode n2suitcase = new StoryNode(
            "'a'",
            "'a'",
            "'a'"
        );  startNode.AddChoice("suitcase", n2suitcase);
        if (GameManager.Instance.currentNode == n2book || GameManager.Instance.currentNode == n2suitcase)
        { DefaultResponses.RemoveLastHint();}



        n2book.SetPreset("Why so dramatic?");
        StoryNode n3book = new StoryNode("Elo laughs at your response. 'Guess who's gonna finish it?'");

        // Send the starting node to GameManager
        GameManager.Instance.StartStory(startNode);
    }
}

//startNode.SetPreset("what the hell, sure"); IS A SAMPLE TO SET A PRESET WITHOUT ASSOCIATING IT TO CHOICE