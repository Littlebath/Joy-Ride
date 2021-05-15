using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharge : MonoBehaviour
{
    [SerializeField] private float chaseSpeed;
    [SerializeField] private float dashSpeed;
    [SerializeField] private float chaseTimer;
    [SerializeField] private float dashTimer;

    [SerializeField] private SpriteRenderer sprite;

    private Transform lastKnowPos;

    private float timerCountdown;
    public enum EnemyBehavior
    {
        Chase,
        Dash
    }

    public EnemyBehavior enemyBehavior;

    private GameObject player;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>().gameObject;

        timerCountdown = chaseTimer;
        enemyBehavior = EnemyBehavior.Chase;
    }

    private void Update()
    {
        EnemyAI();
    }

    private void EnemyAI()
    {
        if (enemyBehavior == EnemyBehavior.Chase)
        {
            //Chase the player
            timerCountdown -= Time.deltaTime;

            if (timerCountdown <= 0)
            {
                timerCountdown = dashTimer;
                enemyBehavior = EnemyBehavior.Dash;
                lastKnowPos = player.transform;
                sprite.color = Color.magenta;
            }

            else
            {
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, chaseSpeed * Time.deltaTime);
                sprite.color = Color.Lerp(Color.magenta, Color.white, timerCountdown);
            }
        }

        else if (enemyBehavior == EnemyBehavior.Dash)
        {
            timerCountdown -= Time.deltaTime;

            if (timerCountdown <= 0)
            {
                timerCountdown = chaseTimer;
                enemyBehavior = EnemyBehavior.Chase;
                sprite.color = Color.white;
            }

            else
            {
                transform.position = Vector2.MoveTowards(transform.position, lastKnowPos.transform.position, dashSpeed * Time.deltaTime);
            }
        }
    }
}
