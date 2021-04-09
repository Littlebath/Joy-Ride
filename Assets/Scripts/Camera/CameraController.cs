using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    public static CameraController Instance { get; private set; }
    public bool canShake;
    public float distanceMultiplier;
    private Camera cam;
    private Transform player;
    private Vector3 offset;
    public CinemachineCameraOffset cineCam;

    private CinemachineVirtualCamera cinemachineVirtualCamera;
    private float shakeTimer;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        cam = Camera.main;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        offset = cam.ScreenToWorldPoint(Input.mousePosition).normalized;
        cineCam.m_Offset = offset * distanceMultiplier;

        if (canShake)
        {
            if (shakeTimer > 0)
            {
                shakeTimer -= Time.deltaTime;

                if (shakeTimer <= 0)
                {
                    CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
                    cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = 0f;

                }
            }
        }
    }

    public void ShakeCamera (float intensity, float time)
    {
        if (canShake)
        {
            CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
            cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = intensity;
            shakeTimer = time;
        }
    }
}
