using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text.RegularExpressions;
//IMPORTS STUFFF

public class GameManager : MonoBehaviour
{
    private static GameManager _instance; // hidden (private) reference to the GameManager
    public static GameManager Instance => _instance; // allows other scripts to access GameManager safely with GameManager.Instance

    void Awake()
    {  if (_instance != null && _instance != this)
        { Destroy(gameObject);
            return; }
        _instance = this;  }
    // PREVENT DUPLICATES 

    public TextMeshProUGUI storyText;  
    public TMP_InputField playerInput;  
    public TextMeshProUGUI presetText;  

    public StoryNode currentNode;
    public StoryNode previousNode;
    public int storyIndex = 0;
    private int previousIndex = 0;
    private bool waitingForKnockResponse = false;

    private bool inIntro = true;

    void Start()
    {
        StoryNode startNode = new StoryNode("Ready to Start the Game?! (Yes / No)");
        currentNode = startNode;
        DisplayStory();
        
        playerInput.onSubmit.AddListener(ProcessInput);
        playerInput.ActivateInputField();
    }
    // BASICALLY A MAIN MENU
    
    void ProcessInput(string input)
    {
        input = RemovePunctuation(input.ToLower().Trim());
        playerInput.text = "";

        if (storyIndex < currentNode.storyTextParts.Count - 1)
        {
            storyIndex++; 
            DisplayStory();
            return;     
        }
        //ITERATE THROUGH EACH PART OF A NODE UNTIL ITS END


        if (storyIndex == currentNode.storyTextParts.Count - 1 && string.IsNullOrEmpty(input))
        { 
            string response = DefaultResponses.GetSilentResponse(); // ref to the default responses script
            storyText.text = response;
            playerInput.ActivateInputField();

            waitingForKnockResponse = (response == "'Knock Knock!'");
            return; 

            /*
            ON ENTER 
            if (NullNode = true)
            { if (previousNode != null)
                    { currentNode = previousNode;
                    storyIndex = previousIndex;
                        DisplayStory();
                    }
            */


        } 
        // USER INPUT: NULL
        if (waitingForKnockResponse && (input == "who's there" || input == "whos there"))
        {
            storyText.text = "'It's a me Eloooo!!!'"; 
            waitingForKnockResponse = false;  
            playerInput.ActivateInputField();
            return;
        }
        // CONT OF USER INPUT: NULL (SPECIAL CASE: KNOCK KNOCK JOKE)


        if (input == "back" && previousNode != null)
        {
            currentNode = previousNode;
            storyIndex = 0;  
            DisplayStory();
            return;
        }
        // USER INPUT: BACK


        if (input == "help")
        {
            previousNode = currentNode; 
            currentNode = DefaultResponses.GetHelpResponse();  // ref to the default responses script
            storyIndex = 0;
            DisplayStory();
            return;
        }
        // USER INPUT: HELP


        if (inIntro && input == "yes")
            {
                Chapter1.StartChapter1();  // Calls the method from Chapter1.cs
                return; 
                inIntro = false;
            }
        // INTRO_YES
            else if (inIntro && input == "no")
            {
                storyText.text = "Well, you're gonna play anyway! Or.. would you like to feature test?";
                playerInput.ActivateInputField();
                if (input == "test") { FeatureTest.Test(); }
            }
        // INTRO_NO


        if (storyIndex == currentNode.storyTextParts.Count - 1)
        {if (currentNode.choices.ContainsKey(input))
        {
                previousNode = currentNode;  
                previousIndex = storyIndex;
                currentNode = currentNode.choices[input]; 
                storyIndex = 0; 
                DisplayStory();
        }
        else
        {
            storyText.text = DefaultResponses.GetInvalidResponse(); 
            playerInput.ActivateInputField();
        }}
        // THE ACTUAL PROCESS INPUT PART 
        playerInput.ActivateInputField();  
    }

    void DisplayStory()
    {
        storyText.text = currentNode.storyTextParts[storyIndex];  

        if (!string.IsNullOrEmpty(currentNode.preset))
        { presetText.text = "Suggested Response: " + currentNode.preset;  }
        else
        {  presetText.text = "";  }
    }
    // SHOW THE STORY IN THE UI

    public void Nevermind()
    {
        if (previousNode != null)
        {
            currentNode = previousNode;
            storyIndex = previousIndex;
            DisplayStory();
        }
    }


    public void StartStory(StoryNode storyNode) 
    {   
        currentNode = storyNode;
        storyIndex = 0;
        DisplayStory();
    }

    public void UsePreset()
    {
        playerInput.text = presetText.text;
        playerInput.ActivateInputField();
    }


    private string RemovePunctuation(string input)
    {
        return Regex.Replace(input, @"[^\w\s]", "");
    }

    public void ReInput(){  playerInput.ActivateInputField(); }
}
