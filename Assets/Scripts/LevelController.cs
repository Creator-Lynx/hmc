using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public static LevelController instance;
    [SerializeField] GameObject door;
    [SerializeField] GameObject loseScreen, winScreen;

    [SerializeField] GameObject player;
    int ScoreToWin = 8;
    void Start()
    {
        if (!Camera.main.GetComponent<AudioSource>().isPlaying)
            Camera.main.GetComponent<AudioSource>().Play();
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
        //winScreen.SetActive(true);
        player.GetComponent<PlayerAnimator>().HelmetChange();
        Camera.main.GetComponent<AudioSource>().Stop();

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
