using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending : MonoBehaviour
{
    private bool hasEntered;
    [SerializeField] GameObject CongratsPanel;
    private void Awake()
    {
        hasEntered = false;
        CongratsPanel.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (!hasEntered)
            {
                StartCoroutine("Wait");
                hasEntered = true;
            }
            else
            {
                return;
            }

        }
    }
    IEnumerator Wait()
    {
        print("waiting");
        yield return new WaitForSeconds(0.25f);
        CongratsPanel.SetActive(true);
    }
}
