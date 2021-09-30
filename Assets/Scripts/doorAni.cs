using UnityEngine;

public class doorAni : MonoBehaviour
{
    Animator m_Animator;

    private PadlockController padlockInst;

    void Start()
    {
        //Getting the Animator attached to the GameObject we are intending to animate.
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