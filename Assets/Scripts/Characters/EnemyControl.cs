using UnityEngine;

public class EnemyControl : CharacterControl
{
    protected int Damage = 1;
    protected GameObject goPlayer;
    protected BoxCollider weaponCollider;
    public GameObject goWeapon;

    protected new void Start()
    {
        goPlayer = GameObject.FindWithTag("Player");
        if ( goWeapon != null )
            weaponCollider = goWeapon.GetComponent<BoxCollider>();
        base.Start();
    }

    protected override void SetDead()
    {
        base.SetDead();
        AudioControl.playZombie();
        GameControl.GetInstance().KillZombie();
        Destroy(this.gameObject, 5);
    }

    protected void FollowPlayer()
    {
        Vector3 direction = goPlayer.transform.position - transform.position;

        Move(direction);
        Rotation(direction);
        anCtrl.Move(direction.magnitude);
    }

    protected void HitPlayer()
    {
        //goPlayer.GetComponent<PlayerControl>().Hit(Damage);
    }

    protected void StartAtack()
    {

        weaponCollider.enabled = true;
    }

    protected void StopAtack()
    {
        weaponCollider.enabled = false;
    }

    private void OnTriggerEnter(Collider objCollision)
    {
        if (objCollision.tag == "Player")
        {
            objCollision.GetComponent<CharacterControl>().Hit(1);
            objCollision.GetComponent<CharacterControl>().SquirtBlood(transform.position, Quaternion.LookRotation(-transform.forward));
        }
    }
}
