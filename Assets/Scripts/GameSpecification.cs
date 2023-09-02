using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSpecification : MonoBehaviour
{
    //public AudioSource ClickSound;
    public static int Gamediff;

    public void GameStart()
    {
        SceneManager.LoadScene("court");
    }
    public void Update()
    {

    }
    public void DiffEasy()
    {
        Gamediff = 0;
        Invoke("GameStart", 0.2f);
    }
    public void DiffMedium()
    {
        Gamediff = 1;
        Invoke("GameStart", 0.2f);
    }
    public void DiffHard()
    {
        Gamediff = 2;
        Invoke("GameStart", 0.2f);
    }
}
