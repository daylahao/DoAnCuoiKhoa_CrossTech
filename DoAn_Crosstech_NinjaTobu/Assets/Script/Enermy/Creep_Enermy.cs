using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creep_Enermy : BaseEnermy
{
    private GameObject Zone_Attack;
    private int Attack_Count;
    public float Fore_Attack = 100f;
    public const string ANIMATOR_IDLE = "CreepAnimation_Idle";
    public const string ANIMATOR_Attack = "CreepAnimation_Attack";
    // Start is called before the first frame update
    void Start()
    {
        _animator = this.GetComponent<Animator>();
        time_ = Time.time;
        Player = GameObject.Find("Player");
        Zone_Attack = transform.GetChild(0).gameObject;
        Zone_Attack.GetComponent<Zone_AddFoce>().Fore_Attack = Fore_Attack;
        Attack_Count = 1;
    }

    // Update is called once per frame
    void Update()
    {
        Flip_X();
        if(Zone_Attack!=null)
            if (Zone_Attack.GetComponent<PolygonCollider2D>().IsTouching(Player.GetComponent<BoxCollider2D>()))
            {
                Attack_Count--;
                _animator.Play(ANIMATOR_Attack);
            }
        if (Attack_Count < 1)
        {
            Destroy(Zone_Attack);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerKill(collision.gameObject);
    }
    public override void PlayerKill(GameObject Object)
    {
        base.PlayerKill(Object);
    }
    public void ANIMATION_IDLE()
    {
        _animator.Play(ANIMATOR_IDLE);
    }

}
