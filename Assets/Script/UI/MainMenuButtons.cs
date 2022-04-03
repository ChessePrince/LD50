using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip clicClip;
    public GameObject main, credits;

    private void Awake()
    {
        main.SetActive(true);
        audioSource = GetComponent<AudioSource>();
        if (0 == SceneManager.GetActiveScene().buildIndex)
        {
            credits.SetActive(false);
        }
    }
    public void ChangeScene(int index)
    {
        SceneManager.LoadScene(index);
        PlayClic();
    }
    public void Credits()
    {
        main.SetActive(false);
        credits.SetActive(true);
        PlayClic();
    }
    public void Back()
    {
        main.SetActive(true);
        credits.SetActive(false);
        PlayClic();
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
        PlayClic();
    }
    public void PlayClic()
    {
        audioSource.PlayOneShot(clicClip, 0.2f);
    }
}
