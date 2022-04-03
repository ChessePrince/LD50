using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangePitch : MonoBehaviour
{
    AudioSource audioSource;
    int buildIndex;

    private void Awake()
    {
        //DontDestroyOnLoad(this.gameObject);
        buildIndex = SceneManager.GetActiveScene().buildIndex;
        audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        switch (buildIndex)
        {
            case 0:
                audioSource.pitch = 1f;
                audioSource.volume = 0.25f;
                break;
            case 1:
                audioSource.pitch = 1f;
                LowerVolume();
                break;
        }
    }
    void LowerVolume()
    {
        if (PauseControl.gameIsPaused)
            audioSource.volume = 0.1f;
        else
            audioSource.volume = 0.25f;
    }
}
