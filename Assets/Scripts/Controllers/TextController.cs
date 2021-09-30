using UnityEngine;

public class TextController : MonoBehaviour {

    public Animator anim;

    //quick fix damit es nur einmal closed, wird noch besser
    public int temp;

    // Make it the actual animator
    void Start()
    {
        anim = GetComponent<Animator>();
        temp = 0;
        //Debug.Log("hi");   
    }

    // Windows are supposed to close with space key
    void Update()
    {
        
        if (Input.GetKeyDown("space") && (temp == 0)) {

            temp = 1;
            //Debug.Log("drin");
            anim.Play("close");
        }       
    }
}
