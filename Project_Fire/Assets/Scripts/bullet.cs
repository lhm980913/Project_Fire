using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : enemy_base
{
    float speed = 10;
    public Transform player;
    // Start is called before the first frame update
    private void Awake()
    {
        type = "bullet";
        Hp = maxhp;
    }
    void Start()
    {
        Destroy(this.gameObject, 5);
        player = testplayer.Instance.transform;
        this.transform.LookAt(player);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += transform.forward * speed*Time.deltaTime;

        if (Hp <= 0 && !dead)
        {

            
            candamage = false;
            dead = true;
            Destroy(this.gameObject);
        }
    }
    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        if(other.tag=="map")
        {
            Destroy(this.gameObject);
        }
       
    }
}
