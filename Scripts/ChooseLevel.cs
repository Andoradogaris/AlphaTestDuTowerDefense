using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseLevel : MonoBehaviour
{

    public string level1 = "Level1";
    public string level2 = "Level2";
    public SceneFader sceneFader;

    public void PlayLevel1()
    {
        sceneFader.FadeTo(level1);
    }

    public void PlayLevel2()
    {
        sceneFader.FadeTo(level2);
    }
}
