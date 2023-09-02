using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public bool pau = false;
    public GameObject pm;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameStart()
    {
        SceneManager.LoadScene("Difficulty");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Instructions()
    {
        SceneManager.LoadScene("Instructions");
    }

    public void Ex()
    {
        Application.Quit();
    }

    public void Pause()
    {
        if (!pau) { Time.timeScale = 0f; pau = true; }
        else { Time.timeScale = 1f; pau = false; }
        pm.SetActive(!(pm.activeSelf));
    }
}
