using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuFunctions : MonoBehaviour
{
    MainMenuButtons button;
    private void Start()
    {
        button = GetComponent<MainMenuButtons>();
    }
    public void BCambioDeEscena(int index)
    {
        button.ChangeScene(index);
    }
    public void BCreditos()
    {
        button.Credits();
    }
    public void BSalir()
    {
        button.QuitGame();
    }
    public void BVolver()
    {
        button.Back();
    }
}
