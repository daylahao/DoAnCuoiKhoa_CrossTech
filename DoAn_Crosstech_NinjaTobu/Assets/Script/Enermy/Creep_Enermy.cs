using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creep_Enermy : BaseEnermy
{
    private GameObject Zone_Attack;
    private int Attack_Count;
    public float Fore_Attack = 100f;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        Zone_Attack = transform.GetChild(0).gameObject;
        Zone_Attack.GetComponent<Zone_AddFoce>().Fore_Attack = Fore_Attack;
        Attack_Count = 1;
    }

    // Update is called once per frame
    void Update()
    {
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

}
