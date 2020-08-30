using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingPlatform : MonoBehaviour
{
    [SerializeField] float _RotationSpeed = 50.0f;

    private void Update()
    {
        transform.Rotate(Vector3.forward, _RotationSpeed * Time.deltaTime);
    }
}
