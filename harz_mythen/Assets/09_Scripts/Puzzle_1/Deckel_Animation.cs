using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deckel_Animation : MonoBehaviour
{
    private Animator animator;

    private void OnEnable() // Eventmanagement fuer Animation
    {
        Puzzle1_Camera.animationVictory += VictoryAnimation;
    }

    void Start()
    {
        animator = GetComponent<Animator>();
    }
    
    /*void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.Play("Deckel_open");
        }
    }*/

    public void VictoryAnimation() // Eventmanagement fuer Animation
    {
        animator.Play("Deckel_open_2");
    }

    private void OnDestroy()
    {
        Puzzle1_Camera.animationVictory -= VictoryAnimation;
    }
}
