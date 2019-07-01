using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunctions : MonoBehaviour
{
    public Scenefader sf;

    public void PlayGame()
    {
        sf.FadeToScene("Prologue");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
