using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerCollisions : MonoBehaviour
{
    [SerializeField] private Transform _RespawnPoint = null;
    [SerializeField] private float _WaitTime = 2.0f;

    private PlayerMovement _Player;

    private void Start()
    {
        _Player = GetComponent<PlayerMovement>();
    }

    private IEnumerator WaitToMove(float WaitTime)
    {
        yield return new WaitForSeconds(WaitTime);
        _Player.CanMove = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            _Player.CanMove = false;
            transform.position = _RespawnPoint.position;

            StartCoroutine(WaitToMove(_WaitTime));
        }

        if (other.gameObject.tag == "LevelEnd")
        {
            _Player.CanMove = false;
            //Level Completed
        }
    }
}
