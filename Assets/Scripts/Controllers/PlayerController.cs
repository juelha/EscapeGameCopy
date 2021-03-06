using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CharacterController _charController;

    // variables according to motion (movement speed of the player, falling velocity if not grounded and gravity)
    public float movSpeed = 12f;
    public float gravity = 9.8f;
    public float velocity = 0f;

    // variables for interacting with obj in env
    private Transform player; 
    private KeyController keyInst;
    private PadlockController padlockInst; 

    void Start()
    {
        player = GameObject.Find("MainCamera").transform;  // main camera for eyes

        keyInst = KeyController.Instance;
        padlockInst = PadlockController.Instance;

        _charController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        takeKey();
        sprint();
        unlockDoor();
    }

    // using LateUpdate to make sure movePlayer() is called last
    void LateUpdate()
    {
        movePlayer();
    }
        

    private void sprint()
    {
        // if shift is pressed, player can sprint
        if (Input.GetKey("left shift") && _charController.isGrounded)
            movSpeed = 20f;
    }

    private void takeKey()
    {
        var dir = (keyInst.transform.position - player.position);
        
        // if in right direction to the key and E pressed, set taken to true
        if ((Input.GetKeyDown(KeyCode.E)) && (dir.magnitude<=2.5))
        {
            keyInst.taken = true; // make key glow 
        }
    }

    private void unlockDoor()
    {
        var dir = (padlockInst.transform.position - keyInst.transform.position);

        // sets the padlock to unlocked and the key to used
        if ((Input.GetKeyDown(KeyCode.E)) && (dir.magnitude <= 2.5))
        {
            padlockInst.unlocked = true;
            keyInst.used = true;
        }
    }

    private void movePlayer()
    {
        float horizontalMov = Input.GetAxis("Horizontal") * movSpeed; //x
        float verticalMov = Input.GetAxis("Vertical") * movSpeed; //z

        // new Vector3(x, 0f, z) would be global and moves in same direction no matter where u face therefore:
        Vector3 move = transform.right * horizontalMov + transform.forward * verticalMov;

        // move the player by the direction (speed already applied) times Time.deltaTime for frame independence
        _charController.Move(move * Time.deltaTime);

        // Gravity mechanic: if player isn't grounded  falls (y-axis) with a velocity influenced by the time & gravity
        if (!_charController.isGrounded || transform.position.y >= 0)
        {
            velocity -= gravity* Time.deltaTime;
            _charController.Move(new Vector3(0, velocity, 0));
        }
    }
}