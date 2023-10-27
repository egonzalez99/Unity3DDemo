using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator animator;
    private bool isWalkingBackward = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // Detect player input for reverse walking (e.g., pressing a specific key)
        if (Input.GetKey(KeyCode.S)) // Replace with the appropriate input condition
        {
            isWalkingBackward = true;
        }
        else
        {
            isWalkingBackward = false;
        }

        // Update the animator parameter to control the animation state
        animator.SetBool("WalkingBackward", isWalkingBackward);
    }
}
