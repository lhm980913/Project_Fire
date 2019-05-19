using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_fire : enemy_base
{
    public Enemy enemy;
    public enemy_fire self;


    public Fire_Stand fire_stand_stage;
    public Fire_Hurt fire_hurt_stage;
    public Fire_Dead fire_dead_stage;
    public Fire_Walk fire_walk_stage;
    public Fire_Att fire_att_stage;
    public Fire_Throw fire_throw_stage;

    public GameObject fire;
    public GameObject fire1;
    public Transform huoba;
    private void Awake()
    {
        type = "fire";
        if (self != this)
        {
            self = this;
        }
        fire_stand_stage = new Fire_Stand(self);
        fire_att_stage = new Fire_Att(self);
        fire_dead_stage = new Fire_Dead(self);
        fire_hurt_stage = new Fire_Hurt(self);
        fire_throw_stage = new Fire_Throw(self);
        fire_walk_stage = new Fire_Walk(self);

        Hp = maxhp;
        hurt_count = hurt_yuzhi;
        enemy = new Enemy(fire_walk_stage);
       // attfield = attfield - Random.Range(0, 0.25f);
    }
    private void Start()
    {
        fire1 = Instantiate(fire);
    }


    private void Update()
    {
        fire1.transform.position = huoba.position;
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

            enemy.SetStage(fire_dead_stage);
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
        print(b);
        // b = Physics.BoxCast(transform.position + transform.up + transform.forward * 1, Vector3.one * 0.1f, -transform.up, Quaternion.identity, 3, 1 << 9);

        return a || !b;
    }
    public override bool FAttPlayer()
    {
        //return Physics.Raycast(transform.position, transform.forward, attfield, player_layermask);
        bool a = Physics.BoxCast(transform.position - transform.forward * 2, Vector3.one, transform.forward, Quaternion.identity, attfield + 2, player_layermask);
        bool b = Physics.BoxCast(transform.position + transform.forward * 2, Vector3.one, -transform.forward, Quaternion.identity,attfield + 2, player_layermask);
        return a||b;
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
        if (Vector3.Distance(this.transform.position, testplayer.Instance.transform.position)>visionfield)
        {
            return false;
        }
        if (Physics.Raycast(this.transform.position, testplayer.Instance.transform.position - this.transform.position, Vector3.Distance(this.transform.position, testplayer.Instance.transform.position), 1 << 9))
        {
            return false;
        }
        bool a = Physics.BoxCast(transform.position, Vector3.one, transform.forward, Quaternion.identity, visionfield, player_layermask);
        bool b = Physics.BoxCast(transform.position, Vector3.one, -transform.forward, Quaternion.identity, visionfield/3, player_layermask);
        bool c = Physics.OverlapSphere(this.transform.position, 4, player_layermask).Length != 0 ? true : false;
        

        if ((a||b || c) &&!fighting)
        {
            fighting = true;
        }
        
        return a||b||c;
    }
    public void tuozhan()
    {
        if (Vector3.Distance(this.transform.position, testplayer.Instance.transform.position) > 7)
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

        ProcessSystem.Instance.FPlayerWeapon_Enemy(other, this);

        if (other.tag == "player_weapon" && enemy._enemy != fire_att_stage && enemy._enemy != fire_hurt_stage && enemy._enemy != fire_dead_stage && enemy._enemy != fire_stand_stage && enemy._enemy != fire_throw_stage)
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
        Destroy(fire1);
    }

    //public override IEnumerator FHurt(float time, Enemy_Stage stage_)
    //{
    //    yield return new WaitForSeconds(time);
    //    print(11);
    //    FFaceToPlayer();
    //    // FBeHurt();
    //    Stage = stage_;
    //    StopAllCoroutines();



    //}




}
