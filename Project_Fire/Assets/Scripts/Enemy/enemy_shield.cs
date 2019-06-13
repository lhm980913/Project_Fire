using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_shield : enemy_base
{
    public Enemy enemy;
    public enemy_shield self;


    public Shield_Stand shield_stand_stage;
    public Shield_Hurt shield_hurt_stage;
    public Shield_Dead shield_dead_stage;
    public Shield_Walk shield_walk_stage;
    public Shield_Att shield_att_stage;
    public Shield_Def shield_def_stage;
    public Shield_Tanfan shield_tanfan_stage;
    public Shield_Back shield_back_stage;
    //public GameObject fire;
    //public GameObject fire1;
    //public Transform huoba;
    private void Awake()
    {
        base.FRegister();
        type = "shield";
        if (self != this)
        {
            self = this;
        }
        shield_stand_stage = new Shield_Stand(self);
        shield_att_stage = new Shield_Att(self);
        shield_dead_stage = new Shield_Dead(self);
        shield_hurt_stage = new Shield_Hurt(self);
        shield_def_stage = new Shield_Def(self);
        shield_walk_stage = new Shield_Walk(self);
        shield_tanfan_stage = new Shield_Tanfan(self);
        shield_back_stage = new Shield_Back(self);

        Hp = maxhp;
        hurt_count = hurt_yuzhi;
        enemy = new Enemy(shield_walk_stage);
        // attfield = attfield - Random.Range(0, 0.25f);
    }
    private void Start()
    {
        //fire1 = Instantiate(fire);
    }


    private void Update()
    {
        //fire1.transform.position = huoba.position;
        enemy.Update();
        if (faceto == 1)
        {
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, -90, 0);
        }

        if (Hp <= 0 && !dead)
        {

            enemy.SetStage(shield_dead_stage);
            candamage = false;
            dead = true;
        }
        tuozhan();
        FSeePlayer();
        attcd -= Time.deltaTime;
    }






    public override void FBeHurt(float force)
    {
        if (testplayer.Instance.transform.position.x < this.transform.position.x)
        {
            this.GetComponent<Rigidbody>().velocity += new Vector3(1, 1, 0) * force;
        }
        else
        {
            this.GetComponent<Rigidbody>().velocity += new Vector3(-1, 1, 0) * force;
        }

    }
    public override bool FCheckFilp()
    {
        bool a = Physics.Raycast(transform.position, transform.forward, 1f, 1 << 9);

        // a = Physics.BoxCast(transform.position, Vector3.one, transform.forward, Quaternion.identity, 1, 1 << 9);
        bool b = Physics.Raycast(transform.position + transform.forward * 1, -transform.up, 1.5f, 1 << 9);

        // b = Physics.BoxCast(transform.position + transform.up + transform.forward * 1, Vector3.one * 0.1f, -transform.up, Quaternion.identity, 3, 1 << 9);

        return a || !b;
    }
    public bool FCheckFilp(int typeid)
    {
        bool a = Physics.Raycast(transform.position, -transform.forward, 1f, 1 << 9);

        // a = Physics.BoxCast(transform.position, Vector3.one, transform.forward, Quaternion.identity, 1, 1 << 9);
        bool b = Physics.Raycast(transform.position - transform.forward * 1, -transform.up, 1.5f, 1 << 9);

        // b = Physics.BoxCast(transform.position + transform.up + transform.forward * 1, Vector3.one * 0.1f, -transform.up, Quaternion.identity, 3, 1 << 9);

        return a || !b;
    }
    public override bool FAttPlayer()
    {
        //return Physics.Raycast(transform.position, transform.forward, attfield, player_layermask);
        bool a = Physics.BoxCast(transform.position - transform.forward * 2, Vector3.one, transform.forward, Quaternion.identity, attfield + 2, player_layermask);
        bool b = Physics.BoxCast(transform.position + transform.forward * 2, Vector3.one, -transform.forward, Quaternion.identity, attfield + 2, player_layermask);
        return a || b;
    }
    public override void FFaceToPlayer()
    {
        if (testplayer.Instance.transform.position.x < this.transform.position.x)
        {
            this.faceto = -1;
        }
        else
        {
            this.faceto = 1;
        }
    }
    public override bool FSeePlayer()
    {
        //return Physics.Raycast(transform.position, transform.forward, visionfield, player_layermask);
        if (Vector3.Distance(this.transform.position, testplayer.Instance.transform.position) > visionfield)
        {
            return false;
        }
        if (Physics.Raycast(this.transform.position, testplayer.Instance.transform.position - this.transform.position, Vector3.Distance(this.transform.position, testplayer.Instance.transform.position), 1 << 9))
        {
            return false;
        }
        bool a = Physics.BoxCast(transform.position, Vector3.one, transform.forward, Quaternion.identity, visionfield, player_layermask);
        bool b = Physics.BoxCast(transform.position, Vector3.one, -transform.forward, Quaternion.identity, visionfield / 3, player_layermask);
        bool c = Physics.OverlapSphere(this.transform.position, 4, player_layermask).Length != 0 ? true : false;


        if ((a || b || c) && !fighting)
        {
            fighting = true;
        }

        return a || b || c;
    }
    public void tuozhan()
    {
        if (Vector3.Distance(this.transform.position, testplayer.Instance.transform.position) > 5)
        {
            fighting = false;
        }
    }
    //public IEnumerator stand_lizarrd(float time)
    //{
    //    // yield return 
    //    yield return new WaitForSeconds(time);
    //    transform.Rotate(0, 180, 0, Space.Self);
    //    faceto *= -1;
    //    Stage = Enemy_Stage.walk;
    //    StopAllCoroutines();
    //}

    //public IEnumerator att(float time)
    //{
    //    // yield return 
    //    yield return new WaitForSeconds(time);
    //    StopAllCoroutines();
    //    Stage = Enemy_Stage.walk;

    //}

    //public override void OnTriggerEnter(Collider other)
    //{

    //    ProcessSystem.Instance.FPlayerWeapon_Enemy(other, this);
    //}
    protected override void OnTriggerEnter(Collider other)
    {
        if (!wudi)
        {
            
            if((transform.position.x - testplayer.Instance.transform.position.x) * faceto < 0&&enemy._enemy==shield_def_stage&&testplayer.Instance.attlevel!= testplayer.Instance.Exatt)
            {
                if(other.tag=="player_weapon")
                {
                    ProcessSystem.Instance.Def(other, this);
                }
               
            }
            else
            {
                ProcessSystem.Instance.FPlayerWeapon_Enemy(other, this);
                StartCoroutine(wudicount());
            }

        }
        // ProcessSystem.Instance.FPlayerWeapon_Enemy(other, this);

        if (other.tag == "player_weapon" && enemy._enemy != shield_att_stage && enemy._enemy != shield_hurt_stage && enemy._enemy != shield_dead_stage && enemy._enemy != shield_stand_stage && enemy._enemy != shield_def_stage)
        {
            if (testplayer.Instance.transform.position.x - this.transform.position.x > 0 && faceto == -1)
            {
                faceto *= -1;
            }
            else if (testplayer.Instance.transform.position.x - this.transform.position.x < 0 && faceto == 1)
            {
                faceto *= -1;
            }
        }

    }

    public override void destroyself()
    {
        Destroy(this.gameObject);
        //Destroy(fire1);
    }

    //public override IEnumerator FHurt(float time, Enemy_Stage stage_)
    //{
    //    yield return new WaitForSeconds(time);
    //    print(11);
    //    FFaceToPlayer();
    //    // FBeHurt();
    //    Stage = stage_;
    //    StopAllCoroutines();


}

