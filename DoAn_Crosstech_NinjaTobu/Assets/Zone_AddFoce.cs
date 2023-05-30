using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zone_AddFoce : MonoBehaviour
{
    public float Fore_Attack;
    public Creep_Enermy _EnermyBody;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="Player")
        {
            float Velocity_x = collision.gameObject.GetComponent<Rigidbody2D>().velocity.x;
            float Velocity_y = collision.gameObject.GetComponent<Rigidbody2D>().velocity.y;
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector3(-Velocity_x,-Velocity_y, 0f) * Fore_Attack);
            _EnermyBody.Attack_ZoneActive();
        }
    }
}
