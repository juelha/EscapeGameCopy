using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public Transform target;
    private CharacterController _controller;

    private void OnTriggerEnter(Collider other)
    {
        var player = GameObject.Find("Player");
        _controller = player.GetComponent<CharacterController>();

        // check if the collision that triggered the OnTriggerEnter call was the character controller
        if (other == _controller.GetComponent<Collider>())
        {
            // disable the character controller before moving the player
            _controller.enabled = false;
            // move player to the teleport position (target)
            player.transform.position = target.position;
            // re-enable the controller to allow player to move again
            _controller.enabled = true;
        }
    }
}
