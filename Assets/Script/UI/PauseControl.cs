using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseControl : MonoBehaviour
{
    public static bool gameIsPaused;
    public static bool playerIsDead;

    [Header("Keybinds")]
    [SerializeField] KeyCode pauseKey = KeyCode.Escape;

    [Header("References")]
    [SerializeField] GameObject goDeathPanel;
    [SerializeField] GameObject goPauseMenu;          
    AudioSource audioSource;
    public AudioClip clicClip;

    private void Start()
    {
        goPauseMenu.SetActive(false);
        goDeathPanel.SetActive(false);
        audioSource = GetComponent<AudioSource>();
        Time.timeScale = 1f;
    }
    void Update()
    {
        if (Input.GetKeyDown(pauseKey) && !playerIsDead)
        {
            gameIsPaused = !gameIsPaused;
            PauseGame();
        }
        if(Input.GetKeyDown(KeyCode.R))
        {
            Retry();
            print("aaaa");
        }
    }
    void PauseGame()
    {
        if (gameIsPaused)
        {
            Time.timeScale = 0f;
            goPauseMenu.SetActive(true);
        }
        else
        {
            ResumeGame();
        }
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
        gameIsPaused = false;
        goPauseMenu.SetActive(false);
        PlayClic();
    }
    public void ToMainMenu()
    {
        Time.timeScale = 1;
        gameIsPaused = false;
        SceneManager.LoadScene(0);
        PlayClic();
    }
    public void QuitGame()
    {
        Application.Quit();
        PlayClic();
        Debug.Log("quit");
    }
    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        PlayClic();
    }
    public void PlayClic()
    {
        //audioSource.PlayOneShot(clicClip, 0.8f);
    }
    public void DeathPanel()
    {
        if (playerIsDead)
        {
            goDeathPanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
