using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControl : MonoBehaviour {

    private Animator anCharacter;

    private void Awake()
    {
        anCharacter = GetComponent<Animator>();
    }

    public void Move(float value)
    {
        anCharacter.SetBool("Attack", false);
        anCharacter.SetFloat("Move", value);
    }

    public void Attack()
    {
        anCharacter.SetFloat("Move", 0);
        anCharacter.SetBool("Attack", true);
    }

    public void Dead()
    {
        anCharacter.SetTrigger("Dead");
    }

    public void Eat()
    {
        Move(0);
        anCharacter.SetBool("Eat", true);
    }
}
