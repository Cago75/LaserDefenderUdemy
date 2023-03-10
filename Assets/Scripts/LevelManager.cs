using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    float SceneLoadDelay = 2f;
    ScoreKeeper scoreKeeper;

    void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }


    public void LoadGame()
    {
        scoreKeeper.ResetScore();
        SceneManager.LoadScene("GameScene");
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    
    public void LoadEndScreen()
    {
        StartCoroutine(WaitAndLoad("EndScreen", SceneLoadDelay));
        
    }
    
    
    public void QuitGame()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }

    IEnumerator WaitAndLoad(string sceneName, float delay)
    { 
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}
