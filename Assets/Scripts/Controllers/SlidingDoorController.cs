using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingDoorController : MonoBehaviour
{
    public void OpenDoor()
    {
        Vector3 doorOpening = new Vector3(0, 0, 0.1f);
        transform.Translate(doorOpening);
    }
}
