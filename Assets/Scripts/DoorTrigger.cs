using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public Transform player;
    public Transform door;
    public float threshhold; 
    private bool door_active; 
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
      threshhold = 1;
      door_active = false; 
      player = GameObject.Find("Player").transform; 
      door = GameObject.Find("Door").transform;
      anim = GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        // check the distance to the door
        var dist = Vector3.Distance(player.position,door.position);

        // if the distance is below the threshold, open door
        if (dist <= threshhold){
            door_active = true;
        }

        if (door_active){
            anim.Play("dooropen");
        }
    }
}
