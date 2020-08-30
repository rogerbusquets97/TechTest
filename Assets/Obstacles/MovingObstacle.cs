using System.Collections; 
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
    enum Direction
    {
        Horizontal = 0,
        Vertical
    }

    [SerializeField] private float _Speed = 10.0f;

    [SerializeField] private Vector3 _Source = Vector3.zero;
    [SerializeField] private Vector3 _Dest = Vector3.zero;
    [SerializeField] Direction _Direction = Direction.Horizontal;

    private Vector3 _Velocity;

    private void Start()
    {
        _Velocity = _Direction == Direction.Horizontal ? Vector3.right : Vector3.up;
    }

    private void Update()
    {

        transform.position += _Velocity * _Speed * Time.deltaTime;

        if (Vector3.Distance(transform.position, _Source) < 0.1f || Vector3.Distance(transform.position, _Dest) < 0.3f)
        {
            _Velocity *= -1.0f;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;

        Gizmos.DrawSphere(_Source, 0.5f);
        Gizmos.DrawSphere(_Dest, 0.5f);

        Gizmos.color = Color.white;
    }
}
