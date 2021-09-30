using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool main_door_key;
    private bool sliding_door_key;
    private bool demon_defeated;
    
    void Start()
    {
        main_door_key = false;
        sliding_door_key = false;
        demon_defeated = false;
    }
    
}
