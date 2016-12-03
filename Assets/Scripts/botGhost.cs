using UnityEngine;
using System.Collections;

public class botGhost : MonoBehaviour
{
    Animator animator;

    // Use this for initialization
    void Start()
    {
        //characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

        Invoke("beginInvulnerability", 2);
    }


    void beginInvulnerability()
    {
        animator.SetTrigger("invulnerable");
        Invoke("beginInvulnerability", 5);
    }
}
