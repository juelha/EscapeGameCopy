using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PadlockController : MonoBehaviour
{

    public static PadlockController Instance;

    public bool unlocked { get; set; }
    MeshRenderer mr;

    void Awake()
    {
        Instance = this;

        mr = GetComponent<MeshRenderer>();
        unlocked = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(transform.position);
        //var dist_to_key = Vector3.Distance();
        // if ((Input.GetKeyDown(KeyCode.E)))
        if (unlocked)
        {

            mr.material.EnableKeyword("_EMISSION");

            Vector3 _rotation = new Vector3(90f, 90f, 90f);



            Instance.transform.rotation = Quaternion.Euler(_rotation);

            //debug.log("fix rotation of captured boids")
            //  Destroy(Instance, Time.deltaTime);
            // var corner = new Vector3(.1f, .1f, 0f); 
            var corner = new Vector3(0, 0, 0);
            transform.position += Camera.main.ScreenToViewportPoint(corner) * 20f;

            transform.position = Camera.main.transform.position + Camera.main.transform.forward;

            Transform target = Camera.main.transform;
            transform.parent = target;



        }
    }
}
