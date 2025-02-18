using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FeatureTest
{
    public static void Test()
    {
        StoryNode testStart = new StoryNode(
        @"Feature Test Mode Activated!
        What do you want to test?
        1. Test Time System ('test time')
        2. Test Node Creation ('test node')
        3. Test Choices ('test choice')
        4. Test Suggestions ('test suggest')"
        );

        //have only fixed up til here
        GameManager.Instance.StartStory(testStart);
    }
}