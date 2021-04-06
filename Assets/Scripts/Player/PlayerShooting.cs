using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey;
using CodeMonkey.Utils;

public class PlayerShooting : MonoBehaviour
{
    public GameObject shot;
    [SerializeField] private PlayerInput pi;
    [SerializeField] private PlayerController pc;
    [SerializeField] private MeshParticleSystem particleSystem;
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
            CameraController.Instance.ShakeCamera(5f, 0.1f);
            BulletParticles(pc.firePoint.transform.position);
            GameObject bullet = Instantiate(shot, pc.firePoint.transform.position, pc.firePoint.transform.rotation);
            Rigidbody2D rb2D = bullet.GetComponent<Rigidbody2D>();
            rb2D.AddForce(pc.firePoint.transform.up * pc.bulletSpeed, ForceMode2D.Impulse);
            Destroy(bullet, pc.bulletTime);
        }
    }
    public void BulletParticles(Vector3 position)
    {
        Vector3 quadPosition = position;
        Vector3 quadSize = new Vector3(0.5f, 0.5f);
        float rotation = 0f;

        Vector3 shootDir = (pc.firePoint.transform.position - pc.gameObject.transform.position).normalized;
        quadPosition += (shootDir * -0.5f);

        Vector3 shellMoveDir = UtilsClass.ApplyRotationToVector(shootDir, Random.Range(-95f, -85f));

        ShellParticleSystemHandler.Instance.SpawnShell(quadPosition, shellMoveDir);

        /*
        int uvIndex = UnityEngine.Random.Range(0, 8);
        int spawnedQuadIndex = AddQuad(quadPosition, rotation, quadSize, true, uvIndex);

        FunctionUpdater.Create(() =>
        {
            quadPosition += new Vector3(0.2f, 0.2f) * 3f * Time.deltaTime;
            //quadSize += new Vector3(0.2f, 0.2f) * Time.deltaTime;
            //rotation += 360f * Time.deltaTime;
            UpdateQuad(spawnedQuadIndex, quadPosition, rotation, quadSize, true, uvIndex);
        });*/
    }
}
