﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainmenuController : MonoBehaviour
{
    public void OpenScene(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
