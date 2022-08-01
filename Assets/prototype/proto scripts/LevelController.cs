using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public static LevelController instance;
    [SerializeField] GameObject door;
    [SerializeField] GameObject loseScreen, winScreen;
    int ScoreToWin = 8;
    void Start()
    {
        instance = this;
    }

    public void DecreasScore()
    {
        ScoreToWin--;
        if (ScoreToWin <= 3)
        {
            OpenTheDoor();
        }
        if (ScoreToWin <= 0)
        {
            Win();
        }
    }
    void Win()
    {
        winScreen.SetActive(true);
    }
    public void Lose()
    {
        loseScreen.SetActive(true);
    }
    public void ReloadLevel()
    {
        SceneManager.LoadScene(0);
    }

    public void OpenTheDoor()
    {
        Destroy(door);
    }
}
