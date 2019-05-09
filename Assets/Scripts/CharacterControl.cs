using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{

    public int MaxLife = 10;
    public float CharacterSpeed = 10;
    protected int life;

    private Rigidbody rbCharacter;

    public int GetLife()
    {
        return life;
    }

    private void Awake()
    {
        life = MaxLife;
        rbCharacter = GetComponent<Rigidbody>();
    }

    protected void Move(Vector3 direction)
    {
        rbCharacter.MovePosition(rbCharacter.position +
                      (direction.normalized * CharacterSpeed * Time.deltaTime));
    }

    protected void Rotation(Vector3 direction)
    {
        Quaternion rotation = Quaternion.LookRotation(direction);
        rbCharacter.MoveRotation(rotation);
    }

    public void Hit()
    {
        life--;
    }

    public bool IsDead()
    {
        return life <= 0;
    }
}
