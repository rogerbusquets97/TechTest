using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingStick : MonoBehaviour
{
    [SerializeField] float _RotationSpeed = 10.0f;
    [SerializeField] Transform Target = null;

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(Target.transform.position , Vector3.up, _RotationSpeed * Time.deltaTime);
    }
}
