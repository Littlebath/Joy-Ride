using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowDownEffects : MonoBehaviour
{
    private void Awake()
    {
        Time.timeScale = 1f;
    }
    public IEnumerator SlowDown (float slowDownSpeed, float delay)
    {
        Time.timeScale = slowDownSpeed;
        yield return new WaitForSecondsRealtime(delay);
        Time.timeScale = 1f;
    }

    public IEnumerator PauseGame(float slowDownSpeed, float delay)
    {
        Time.timeScale = slowDownSpeed;
        yield return new WaitForSecondsRealtime(delay);
        Time.timeScale = 0.1f;
    }
}
