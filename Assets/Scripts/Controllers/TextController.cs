using UnityEngine;
using TMPro;

public class TextController : MonoBehaviour {

    public Animator anim;

    //one trigger per textfeld animation (so they can never play at once)
    private bool trigger1;
    private bool trigger2;
    private bool trigger3;
    private bool trigger4;

    public TMP_Text tmpobject;
    
    void Start()
    {
        anim = GetComponent<Animator>();
        tmpobject = GetComponent<TMP_Text>();
        trigger1 = true; // first textfeld opens immediately
        trigger2 = false;
        trigger3 = false;
        trigger4 = false;   
    }

    
    void Update()
    {
        // close first window when space is pressed
        if (Input.GetKeyDown("space") && (trigger1 == true)) {

            anim.Play("close");
            trigger1 = false; //this should not happen again
            trigger2 = true; //it's the next textfeld's turn
            //tmpobject.text = "The text is different now hehe"; //change the content of the textfeld

        }  

        //TESTTEST hat sich der trigger wirklich geändert
        if (Input.GetKeyDown("1") && (trigger2 == true)) {

            anim.Play("pop");
            trigger2 = false;
            trigger3 = true;
        }  

        if (Input.GetKeyDown("2") && (trigger3 == true)) {

            anim.Play("close");
            trigger3 = false;
            trigger4 = true;

        }     
    }
}
