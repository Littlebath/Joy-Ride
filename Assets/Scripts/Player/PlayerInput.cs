using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [HideInInspector] public float horizontalInput;
    [HideInInspector] public float verticalInput;
    [HideInInspector] public bool fire;
     public bool dash;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SetControls();
    }

    void SetControls()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        fire = Input.GetButtonDown("Fire1");
        //dash = Input.GetButtonDown("Dash");
        
        //Debug.Log(horizontalInput);
        //Debug.Log(verticalInput);
        //Debug.Log(fire);
    }
}
