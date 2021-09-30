using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool main_door_key;
    private bool sliding_door_key;
    private int garlic;
    private bool demon_defeated;
    
    //[SerializeField] private GameObject _slidingDoor;
    // Start is called before the first frame update
    void Start()
    {
        main_door_key = false;
        sliding_door_key = false;
        garlic = 0;
        demon_defeated = false;
        //_slidingDoor.GetComponent<SlidingDoor>().OpenDoor();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
