using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HSB_Start : MonoBehaviour
{
    private Animator animator;
    //[SerializeField] GameObject weiter;

    void Start()
    {
        animator = GetComponent<Animator>();
        animator.Play("HSB");
    }
}
