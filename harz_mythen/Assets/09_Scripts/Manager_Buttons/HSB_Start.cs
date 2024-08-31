using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HSB_Start : MonoBehaviour
{
    private Animator animator;
    //[SerializeField] GameObject weiter;
    private AudioSource Audio;

    void Start()
    {
        animator = GetComponent<Animator>();
        animator.Play("HSB");
        Audio = GetComponent<AudioSource>();
    }
}
