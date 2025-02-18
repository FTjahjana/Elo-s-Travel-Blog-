using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DefaultResponses
{


    private static readonly string[] invalidResponses = {
        "'Sorry, what did you just say?'",
        "'Uhm, didn't quite catch that.'",
        "'Are you communicating with the aliens?!'",
        "'Wait, what?'",
        "'Can you repeat that?'",
        "'Are we speaking the same language?'",
        "'Is this a riddle or something?'",
        "'Hey buddy, you lost me there.'",
        "'Did I hear that right??'",
        "'What the?!'"
    };  public static string GetInvalidResponse()
    {     return invalidResponses[Random.Range(0, invalidResponses.Length)];    }



    private static readonly string[] silentResponses = {
        "'Heya, what's wrong? Why you so silent?'",
        "Elo looks.. disappointed in you for some reason. Maybe he's waiting for a response?",
        "'Aww come on.. help me out here!'",
        "'Hello? Am I talking to a wall?'",
        "'Knock Knock!'"
    };  public static string GetSilentResponse()
    {    return silentResponses[Random.Range(0, silentResponses.Length)];    }



    private static StoryNode helpNode = new StoryNode(
        "'Of course, the way you say it doesn't matter. You can type help or HELP!!!! and that's okay as long as it just says 'help''. That applies to all your answers ~",
        "'Anyway, 'back' to go back to the last part (including exiting this menu), 'help' for this thing, and...",
        "'No, you can't interrupt me while I'm talking.'",
        "'I usually look for one-word responses, unless there's a suggested response which can have many words. It's not that hard, just read carefully, gee.'",
        "'I don't know! You barely even gave me a listen yet, why're you even asking for help?'",
        "'Oh yeah uh, if you're on the first scene then my apologies - umm, just try to guess.. what do YOU think are the three very important responses right now?"
    ); 
    public static StoryNode GetHelpResponse()
    {
        return helpNode;
    } public static void AddNewHelp(string hint)
    { if (!helpNode.storyTextParts.Contains(hint))  // Avoid duplicates
        {  helpNode.storyTextParts.Add(hint);   }
    } public static void RemoveHelp(string hint)
    {  helpNode.storyTextParts.Remove(hint);  }
    public static void RemoveLastHint()
    { if (helpNode.storyTextParts.Count > 4) 
    {  helpNode.storyTextParts.RemoveAt(helpNode.storyTextParts.Count - 1); } 
    else { }
    }

}
