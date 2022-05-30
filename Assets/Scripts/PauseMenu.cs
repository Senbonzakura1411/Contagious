using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class PauseMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public static bool GameIsPaused = false;
    
    public GameObject PauseMenuUI;

    private InputManager inputManager;

    private void Start() => inputManager = InputManager.GetInstance();
    void Update()
    {
        if (inputManager.playerControls.UIControls.PauseMenu.WasPressedThisFrame())
        {
            Debug.Log("oa");
            if (GameIsPaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
