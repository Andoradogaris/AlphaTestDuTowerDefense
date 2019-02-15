using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static bool gameIsOver;

    public GameObject gameOverUI;

    public string nextLevel = "LevelSelect";
    public int levelToUnlock = 2;

    public SceneFader sceneFader;

    public GameObject completeLevelUI;

    private void Start()
    {
        gameIsOver = false;
    }

    void Update()
    {

        if (gameIsOver)
        {
            return;
        }

        if (PlayerStats.lives <= 0)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        gameIsOver = true;
        gameOverUI.SetActive(true);
    }

    public void WinLevel()
    {
        Debug.Log("Niveau Terminé !!");
        if(levelToUnlock > PlayerPrefs.GetInt("level Reached", 1))
        {
            PlayerPrefs.SetInt("level Reached", levelToUnlock);
        }

        sceneFader.FadeTo(nextLevel);
        //gameIsOver = true;
        //completeLevelUI.SetActive(true);
    }
}
