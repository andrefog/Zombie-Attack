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

    new void Awake()
    {
        MovimentSpeed = PlayerSpeed;
        MaxLife = PlayerMaxLife;
        base.Awake();
    }

    new void Start()
    {
        transform.GetChild(Skin).gameObject.SetActive(true);
        base.Start();
    }
     
    void Update()
    {
        if (!IsDead())
        {
            float eixoX = Input.GetAxis("Horizontal");
            float eixoZ = Input.GetAxis("Vertical");

            direction = new Vector3(eixoX, 0, eixoZ);

            anCtrl.Move(direction.magnitude);
        }
    }

    void FixedUpdate()
    {
        if (!IsDead())
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

    public override void Hit(int damage)
    {
        base.Hit(damage);
        GameControl.GetInstance().UpdateLifeGauge();
    }

    public override void Cure(int cure)
    {
        base.Cure(cure);
        GameControl.GetInstance().UpdateLifeGauge();
    }
}
