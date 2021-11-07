using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallowCamera : MonoBehaviour
{
    [SerializeField] GameObject thingToFallow;
    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = thingToFallow.transform.position + new Vector3(0,0,-10);
    }
}
