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
            "Around the room, you scan through frames upon frames of pictures of Elo and his friends. You start to notice some of them look more like a performance than a casual hangout.",
            "You push the thought away to look around further and see in Elo's hand a thick, old-looking book. Near him, you see a glittering suitcase packed full. And... you don't see anything else quite interesting.. hmmm...",
            "'Ah yeah, and before anything, if you forget how things work around here, just shout out 'help!' Maybe not here though..mmm.."
        );
        StoryNode n2book = new StoryNode(
            "Elo flips through the old, worn pages. 'My dad started this.'",
            "'His dad before him. And his dad before that. Almost a full collection.'",
            "'Almost.'"
        );  startNode.AddChoice("book", n2book);

        StoryNode n2suitcase = new StoryNode(
            "You raise an eyebrow at the glittering suitcase. THAT seems ‘important’.",
            "Elo smirks. 'Yeah, I'm packed and ready.'"
        );  startNode.AddChoice("suitcase", n2suitcase);
        if (GameManager.Instance.currentNode == n2book || GameManager.Instance.currentNode == n2suitcase)
        { DefaultResponses.RemoveLastHint();} // the hint assuming u havent played



        n2book.SetPreset("Why so dramatic?");
        StoryNode n3book = new StoryNode("Elo laughs at your response. 'Guess who's gonna finish it?'");

        n2book.SetPreset("Why so sparkly?");
        StoryNode n3book = new StoryNode("Elo laughs at your response. 'What's the big deal with that?!'",
        "Anyway.. I got some snacks, toiletries, my outfits, and yeah I have my passport and some foreign cash. Anything I'm missing?",
        "You think for a moment.");
        n2book.AddChoice("phone", n3book_null)
        n2book.AddChoice("charger", n3book_null)

        StoryNode n3book_null = new StoryNode("'Hm?' Ah- nevermind.");

        // Send the starting node to GameManager
        GameManager.Instance.StartStory(startNode);
    }
}

//startNode.SetPreset("what the hell, sure"); IS A SAMPLE TO SET A PRESET WITHOUT ASSOCIATING IT TO CHOICE