using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject shot;
    [SerializeField] private PlayerInput pi;
    [SerializeField] private PlayerController pc;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShootBullet ()
    {
        if (pi.fire)
        {
            GameObject bullet = Instantiate(shot, pc.firePoint.transform.position, pc.firePoint.transform.rotation);
            Rigidbody2D rb2D = bullet.GetComponent<Rigidbody2D>();
            rb2D.AddForce(pc.firePoint.transform.up * pc.bulletSpeed, ForceMode2D.Impulse);
            Destroy(bullet, pc.bulletTime);
        }
    }
}
