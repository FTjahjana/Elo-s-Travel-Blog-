using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryNode //basically, a chunk, piece, part of the story whatever you wanna call it in this case!!
{
    public List<string> storyTextParts = new List<string>();  //for multiple outputs in one node 
    public Dictionary<string, StoryNode> choices = new Dictionary<string, StoryNode>();
        // Im still not used to using this bear with me. string is the dataType of the KEY 👍
    public string preset;
    


    public StoryNode(params string[] texts)
    {
        storyTextParts.AddRange(texts);
    }

    public StoryNode(int timeChange = 0, params string[] texts) // duplicate of the previous constructor but with time yay
    {
        storyTextParts.AddRange(texts);
        
        if (timeChange != 0)
        {
            if (timeChange > 0)
                TimeManager.Instance.AddTime(timeChange); 
            else
                TimeManager.Instance.SetTime(-timeChange);
        }
    }



    public void AddChoice(string command, StoryNode nextNode) //command is your input if valid by the wayy
    { choices[command.ToLower()] = nextNode;  }  
    public void AddChoice(string command, StoryNode nextNode, string preset)
    {  choices[command.ToLower()] = nextNode; this.preset = preset; }

    public void SetPreset(string preset)
    {  this.preset = preset;  }

    public void AddTime(int time) {  TimeManager.Instance.AddTime(time); }
}
