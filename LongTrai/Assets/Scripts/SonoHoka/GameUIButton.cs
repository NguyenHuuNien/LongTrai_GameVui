using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUIButton : MonoBehaviour
{
    public void OnPlay()
    {
        SceneManager.LoadScene(1);
    }
    public void OnExit()
    {
        Application.Quit();
    }
}
