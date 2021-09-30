//Attach this script to a GameObject with an Animator component attached.
//For this example, create parameters in the Animator and name them “Crouch” and “Jump”
//Apply these parameters to your transitions between states

//This script allows you to trigger an Animator parameter and reset the other that could possibly still be active. Press the up and down arrow keys to do this.

using UnityEngine;

public class doorAni : MonoBehaviour
{
    Animator m_Animator;

    private PadlockController padlockInst;

    void Start()
    {
        //Get the Animator attached to the GameObject you are intending to animate.
        m_Animator = GetComponent<Animator>();
        padlockInst = PadlockController.Instance;

    }

    void Update()
    {

        if (padlockInst.unlocked)
        {
            m_Animator.Play("doorslide");
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            m_Animator.Play("dooropen");
        }
    }
}