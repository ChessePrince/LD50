using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PManagmentHealth : MonoBehaviour
{
    public Image HealthBar;

    public void UpdateHealthUI(float playerHealth, float maxPlayerHealth)
    {
        HealthBar.fillAmount = playerHealth / maxPlayerHealth;
        //Debug.Log(playerHealth);
    }
}
