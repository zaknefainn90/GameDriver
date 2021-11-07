using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Animations
{
    public class RotationAnimation : MonoBehaviour
    {
        [SerializeField] private float speed = 0.25f;

        private void Update()
        {
            float randomScale = Random.Range(0.90f, 1f);
            transform.Rotate(0, 0, speed);
            transform.localScale = new Vector3(randomScale, randomScale, transform.localScale.z);
        }
    }
}