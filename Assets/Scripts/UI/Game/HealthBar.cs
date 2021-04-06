using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Vector3 offset;
    [SerializeField] private Transform followTarget;
    [SerializeField] private Transform bar;
    // Start is called before the first frame update
    void Start()
    {

    }

    private void Update()
    {
        gameObject.transform.position = followTarget.position + offset;
    }

    public void SetSize (float sizeNormalized, float fullBar)
    {
        bar.localScale = new Vector3(sizeNormalized/fullBar, 1f);
    }
}
