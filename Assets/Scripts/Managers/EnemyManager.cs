using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject youWin;

    private int enemyCounter;
    public void AddEnemyToCounter ()
    {
        enemyCounter++;

        if (enemyCounter >= 22)
        {
            youWin.SetActive(true);
            Time.timeScale = 0.2f;
            Debug.Log("You Win");
        }
    }
}
