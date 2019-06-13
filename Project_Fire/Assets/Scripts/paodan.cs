using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paodan : enemy_base
{
    public float speedx;
    public float speedy;
    public Transform player;
    // Start is called before the first frame update
    private void Awake()
    {
        type = "paodan";
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
        this.GetComponent<Rigidbody>().velocity = new Vector3(speedx, speedy, 0);
        speedy -= 10 * Time.deltaTime;
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
        if (other.tag == "map")
        {
            Destroy(this.gameObject);
        }

    }
}
