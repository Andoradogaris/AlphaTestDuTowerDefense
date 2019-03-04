using UnityEngine;
using UnityEngine.SceneManagement;

public class CompleteLevel : MonoBehaviour
{

    public SceneFader sceneFader;

    public string menuSceneName = "MainMenu";
    public string nextLevel = "LevelSelect";
    public int levelToUnlock = 2;

    public void OnEnable()
    {
        if (levelToUnlock > PlayerPrefs.GetInt("level Reached", 1))
        {
            PlayerPrefs.SetInt("level Reached", levelToUnlock);
        }
    }

    public void Continue()
    {
        sceneFader.FadeTo(nextLevel);
    }

    public void Menu()
    {
        sceneFader.FadeTo(menuSceneName);
    }

}
