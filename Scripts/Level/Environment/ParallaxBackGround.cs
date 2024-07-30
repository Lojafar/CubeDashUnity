using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackGround : MonoBehaviour
{
    [SerializeField] float EffectForce;
    float startPos;
    float length;
    [SerializeField] int BackGroundObjectsCount;
    GameObject cam;
    void Start()
    {
        cam = Camera.main.gameObject;
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x * BackGroundObjectsCount;
    }
    private void LateUpdate()
    {
        float temp = cam.transform.position.x * (1 - EffectForce);
        float dist = cam.transform.position.x * EffectForce;

        transform.position = new Vector3(startPos + dist, transform.position.y, transform.position.z);

        if (temp > startPos + length)
            startPos += length;
        else if (temp < startPos - length)
            startPos -= length;
    }
}
