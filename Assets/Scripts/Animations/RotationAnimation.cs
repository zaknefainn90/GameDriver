using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationAnimation : MonoBehaviour
{
    public float speed = 0.25f;

    // Update is called once per frame
    private void Update()
    {
        float randomScale = Random.Range(0.90f, 1f);
        transform.Rotate(0, 0, speed);
        transform.localScale = new Vector3(randomScale, randomScale, transform.localScale.z);
    }
}