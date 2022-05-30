using System.Collections;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    private void Start()
    {
        AudioManager.Instance.Play("menuMusic1");
    }

    public void PlayGame()
    {
        GameManager.Instance.LoadNextScene();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void SetVolume(float volume)
     {
        audioMixer.SetFloat("volume", volume);
        
     }
}