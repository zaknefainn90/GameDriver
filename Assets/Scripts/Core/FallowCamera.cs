using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class FallowCamera : MonoBehaviour
    {
        [SerializeField] private GameObject thingToFallow;

        // Update is called once per frame
        private void LateUpdate()
        {
            transform.position = thingToFallow.transform.position + new Vector3(0, 0, -10);
        }
    }
}