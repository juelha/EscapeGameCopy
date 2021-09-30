using UnityEngine;

public class CloseWindow : MonoBehaviour {

    public Animator anim;

    // Make it the actual animator
    void Start()
    {
        anim = GetComponent<Animator>();   
    }

    // Windows are supposed to close with space key
    void Update()
    {
        if (Input.GetKeyDown("space")) {

            anim.Play("close");
        }       
    }
}
