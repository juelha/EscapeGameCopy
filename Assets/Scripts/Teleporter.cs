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
        _controller.enabled = false;
        player.transform.position = target.position;
        _controller.enabled = true;

    }
}
