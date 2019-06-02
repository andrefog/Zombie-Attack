using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    public GameObject Blood;

    protected int MaxLife = 1;
    protected float MovimentSpeed = 1;
    protected int life;
    protected bool dead = false;
    protected AnimationControl anCtrl;

    private Rigidbody rbCharacter;

    protected void Awake()
    {
        life = MaxLife;
        rbCharacter = GetComponent<Rigidbody>();
    }

    protected void Start()
    {
        anCtrl = GetComponent<AnimationControl>();
    }

    public int GetLife()
    {
        return life;
    }

    protected void Move(Vector3 direction)
    {
        rbCharacter.MovePosition(rbCharacter.position +
                       (direction.normalized * MovimentSpeed * Time.deltaTime));
    }

    protected void Rotation(Vector3 direction)
    {
        Quaternion rotation = Quaternion.LookRotation(direction);
        rbCharacter.MoveRotation(rotation);
    }

    public virtual void Hit(int damage)
    {
        if (!IsDead())
        {
            life = Mathf.Clamp(life - damage, 0, MaxLife);

            if (life <= 0)
                SetDead();
        }
    }

    public void SquirtBlood(Vector3 position, Quaternion rotation)
    {
        Instantiate(Blood, position, rotation);
    }

    protected virtual void SetDead()
    {
        dead = true;
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<CapsuleCollider>().enabled = false;
        anCtrl.Dead();
    }

    public virtual void Cure(int cure)
    {
        life = Mathf.Clamp(life + cure, 0, MaxLife);
    }

    public bool IsDead()
    {
        return dead;
    }
}
