using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
public class PlayerController : MonoBehaviour
{
    private PlayerMover _playerMover;

    void Start()
    {
        _playerMover = GetComponent<PlayerMover>();
    }

    private void Update()
    {
     /*   if (Input.GetKey(KeyCode.LeftArrow))
        {
            _playerMover.MoveLeft();
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            _playerMover.MoveRight();
        }

        if (Input.GetKey(KeyCode.Space))
        {
            _playerMover.Jump();
        }*/
    }
}
