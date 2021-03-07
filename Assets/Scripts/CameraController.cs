using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    public float distanceMultiplier;
    private Camera cam;
    private Transform player;
    private Vector3 offset;
    public CinemachineCameraOffset cineCam;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        offset = cam.ScreenToWorldPoint(Input.mousePosition).normalized - player.transform.position.normalized;
        cineCam.m_Offset = offset * distanceMultiplier;
    }
}
