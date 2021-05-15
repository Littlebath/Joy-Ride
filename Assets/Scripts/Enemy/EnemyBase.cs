using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [Header("Designer values")]
    public float maxHealth;
    [HideInInspector] public float health = 2;
    public float knockbackForce = 3f;
    public int characterID;
    private static int enemyNumber = 22;
    private static int enemyNumberCounter;

    Vector2 playerPos;

    [Header("References")]
    [SerializeField] private GameObject damagePopup;
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private Rigidbody2D rb2D;
    [SerializeField] private Collider2D coll;
    public SpriteRenderer sprite;
    [SerializeField] private GameObject characterHead;
    [SerializeField] private GameObject bloodExplosion;
    [SerializeField] private GameObject bloodPermanent;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        healthBar.SetSize(health, maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        RotateToPlayer();
    }

    private void knockBack(GameObject target, Vector3 direction, float length, float overTime)
    {
        direction = direction.normalized;
        StartCoroutine(knockBackCoroutine(target, direction, length, overTime));
    }

    IEnumerator knockBackCoroutine(GameObject target, Vector3 direction, float length, float overTime)
    {
        float timeleft = overTime;
        while (timeleft > 0)
        {

            if (timeleft > Time.deltaTime)
                target.transform.Translate(direction * Time.deltaTime / overTime * length);
            else
                target.transform.Translate(direction * timeleft / overTime * length);
            timeleft -= Time.deltaTime;

            yield return null;
        }

    }

    public IEnumerator FlashRed()
    {
        for (int i = 0; i < 1; i++)
        {
            sprite.color = Color.red;
            yield return new WaitForSeconds(0.1f);
            sprite.color = Color.white;
        }
    }

    public void TakeDamage (float damage)
    {
        health -= damage;

        healthBar.SetSize(health, maxHealth);
        StartCoroutine(FlashRed());

        Vector3 direction = playerPos - rb2D.position;
        knockBack(gameObject, direction, knockbackForce, 0.2f);

        DamagePopup.Create(damagePopup, transform.position, damage);
        CameraController.Instance.ShakeCamera(6f, 0.1f);
        BloodParticleSystemHandler.Instance.SpawnBlood(transform.position, -direction);

        StartCoroutine(FindObjectOfType<SlowDownEffects>().SlowDown(0.3f, 0.1f));

        if (health <= 0)
        {
            //GameObject head = Instantiate(characterHead, transform.position, Quaternion.identity);
            //head.GetComponent<CharacterHead>().characterID = characterID;
            //head.transform.localScale = gameObject.transform.localScale;

            GameObject bloodExplode = Instantiate(bloodExplosion, transform.position, Quaternion.identity);
            FindObjectOfType<AudioManager>().PlaySound("Blood Explosion");

            bloodExplode.transform.localScale = gameObject.transform.localScale;
            Instantiate(bloodPermanent, transform.position, Quaternion.identity);
            //enemyNumberCounter++;
            FindObjectOfType<EnemyManager>().AddEnemyToCounter();
            Debug.Log(enemyNumberCounter);
            Destroy(healthBar.gameObject);

            Time.timeScale = 1f;
            Destroy(gameObject);
        }
    }

    private void RotateToPlayer ()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        Vector2 lookDir = playerPos - rb2D.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb2D.rotation = angle;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            TakeDamage(Random.Range (100, 200));
        }
    }


}
