using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodExplosion : MonoBehaviour
{
    public Sprite[] bloodSprites;
    public Color[] ColorRange;

    private void Start()
    {
        int randomSprite = Random.Range(0, bloodSprites.Length);
        int randomColor = Random.Range(0, ColorRange.Length);
        int randomRotation = Random.Range(0, 360);

        gameObject.GetComponent<SpriteRenderer>().sprite = bloodSprites[randomSprite];
        gameObject.GetComponent<SpriteRenderer>().color = ColorRange[randomColor];
        gameObject.transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, randomRotation);
    }

}
