using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerControl : CharacterControl
{
    public float PlayerSpeed = 10;
    public int PlayerMaxLife = 10;
    public LayerMask FloorLayerMask;

    [HideInInspector]
    public static int Skin = 1;

    private Vector3 direction;
    private AnimationControl anCtrl;

    void Start()
    {
        anCtrl = GetComponent<AnimationControl>();
        transform.GetChild(Skin).gameObject.SetActive(true);
        life = PlayerMaxLife;
    }
        
    public void AddLife()
    {
        life += 2;

        if (life > 10)
            life = 10;
    }

    void Update()
    {
        if (!GameControl.GameOver)
        {
            float eixoX = Input.GetAxis("Horizontal");
            float eixoZ = Input.GetAxis("Vertical");

            direction = new Vector3(eixoX, 0, eixoZ);

            anCtrl.Move(direction.magnitude);
        }
        else
            anCtrl.Dead();
    }

    void FixedUpdate()
    {
        if (!GameControl.GameOver)
        {
            Move(direction);
            Rotation2Aim();
        }
    }

    void Rotation2Aim()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit impact;

        if (Physics.Raycast(ray, out impact, 300, FloorLayerMask))
        {
            Vector3 aimPosition = impact.point - transform.position;

            aimPosition.y = 0;

            Rotation(aimPosition);
        }
    }
}
