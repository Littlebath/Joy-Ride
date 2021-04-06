using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [Header("Stats")]
    public float speed;
    public float bulletSpeed;
    public float stoppingDistance;
    public float nearDistance;
    public float startTimeBtwShots;
    private float timeBtwShots;

    [Header("References")]
    public GameObject shot;
    public GameObject gunPoint;
    private Transform player;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, player.position) < nearDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }

        else if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }

        else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > nearDistance)
        {
            transform.position = this.transform.position;
        }

        //Makes the enemy shoot
        if (timeBtwShots <= 0)
        {
            GameObject bullet = Instantiate(shot, gunPoint.transform.position, gunPoint.transform.rotation);
            Rigidbody2D rb2D = bullet.GetComponent<Rigidbody2D>();
            rb2D.AddForce(gunPoint.transform.up * bulletSpeed, ForceMode2D.Impulse);
            timeBtwShots = startTimeBtwShots;
        }

        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
}
