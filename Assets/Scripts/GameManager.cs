using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    private DateTime _sessionStartTime;
    private DateTime _sessionEndTime;

    private void Start()
    {
        _sessionStartTime = DateTime.Now;
        Debug.Log(
            "Game session start @: " + DateTime.Now);
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            LoadNextScene();
        }
    }
    
    private void OnApplicationQuit()
    {
        _sessionEndTime = DateTime.Now;

        TimeSpan timeDifference = 
            _sessionEndTime.Subtract(_sessionStartTime);
        
        Debug.Log(
            "Game session ended @: " + DateTime.Now);
        Debug.Log(
            "Game session lasted: " + timeDifference);
    }
    
    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}