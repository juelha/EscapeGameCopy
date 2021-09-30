using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    // to be accessed from player
    public static KeyController Instance; 

    // bool variables to keep track of the state the key is in
    public bool taken { get; set; }
    public bool used { get; set; }

    // needed for glow effect
    MeshRenderer mr;

    void Awake()
    {
        Instance = this;
        mr = GetComponent<MeshRenderer>();
        taken = false;
        used = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (taken)
        {
            // glowing
            mr.material.EnableKeyword("_EMISSION");

            // key is vertical
            Vector3 _rotation = new Vector3(90f, 90f, 90f);
            Instance.transform.rotation = Quaternion.Euler(_rotation);

            // floats in front of camera
            transform.position = Camera.main.transform.position + Camera.main.transform.forward ;

            // moves along camera being child
            Transform target = Camera.main.transform;
            transform.parent = target;
        }


        if (used)
        {
            // overwrite old state (not needed anymore)
            taken = false;

            // keeps glowing
            mr.material.EnableKeyword("_EMISSION");

            // de-parent 
            transform.parent = null;
            transform.SetParent(null);

            // falls to bottom
            transform.position += Vector3.down * Time.deltaTime;
        }
    }
}
