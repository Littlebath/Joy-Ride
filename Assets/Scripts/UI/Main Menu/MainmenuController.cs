using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainmenuController : MonoBehaviour
{
    private IEnumerator OpenScene(string levelName)
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(levelName);
    }
    public void PlayLevel(string level)
    {
        StartCoroutine(OpenScene(level));
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
