using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameoverUI : MonoBehaviour
{
    public void PlayAgain ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenu ()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
