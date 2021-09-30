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

    // Update is called once per frame
    void Update()
    {
        if (unlocked)
        {
            // glowing
            mr.material.EnableKeyword("_EMISSION");
            // set rotation to vertical
            Vector3 _rotation = new Vector3(90f, 90f, 90f);
            Instance.transform.rotation = Quaternion.Euler(_rotation);
            transform.position += Vector3.down * Time.deltaTime;
        }
    }
}
