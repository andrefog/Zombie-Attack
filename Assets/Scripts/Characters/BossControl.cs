using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class BossControl : EnemyControl
{
    private readonly float bossSpeed = 6;
    private readonly int bossMaxLife = 20;
    private readonly int bossDamage = 3;
    public Slider BossLifeGauge;

    private Vector3 position;
    private NavMeshAgent navMeshAgent;

    new void Awake()
    {
        MaxLife = GameControl.GetInstance().GetKills() / 10 + bossMaxLife;
        Damage = bossDamage;
        BossLifeGauge.value = BossLifeGauge.maxValue = MaxLife;
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.speed = MovimentSpeed = bossSpeed;
        base.Awake();
    }


    void FixedUpdate()
    {
        if (!IsDead())
        {
            BossLifeGauge.transform.LookAt(BossLifeGauge.transform.position - Camera.main.transform.forward);
            navMeshAgent.SetDestination(goPlayer.transform.position);
            anCtrl.Move(navMeshAgent.velocity.magnitude);

            if (navMeshAgent.hasPath && navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)
            {
                if (GameControl.GetInstance().GameOver)
                    anCtrl.Eat();
                else
                    anCtrl.Attack();
            }
        }
    }

    public void UpdateLifeGauge()
    {
        if (life < MaxLife && !BossLifeGauge.gameObject.activeSelf)
        {
            BossLifeGauge.gameObject.SetActive(true);
        }

        BossLifeGauge.value = life;
    }

    public override void Hit(int damage)
    {
        base.Hit(damage);
        UpdateLifeGauge();
    }

    protected override void SetDead()
    {
        navMeshAgent.SetDestination(transform.position);
        BossLifeGauge.gameObject.SetActive(false);
        base.SetDead();
    }
}
