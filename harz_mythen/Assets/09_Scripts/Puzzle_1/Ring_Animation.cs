using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring_Animation : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            animator.Play("Ring");
        }
    }
}
