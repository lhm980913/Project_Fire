using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_boss : enemy_base
{
    public Enemy enemy;
    public enemy_boss self;

    public Boss_Stand boss_stand_stage;
    public Boss_Dead boss_dead_stage;
    public Boss_Att1 boss_att1_stage;
    public Boss_Att2 boss_att2_stage;
    public Boss_Backjump boss_backjump_stage;
    public Boss_Gun boss_gun_stage;
    public Boss_Hurt boss_hurt_stage;
    public Boss_Jatt boss_jatt_stage;
    public Boss_Att3 boss_att3_stage;


    public float yingzhi = 0.4f;
    int skillid=0;
    //public GameObject fire;
    //public GameObject fire1;
    //public Transform huoba;
    private void Awake()
    {

        base.FRegister();
        type = "boss";
        if (self != this)
        {
            self = this;
        }
        boss_stand_stage = new Boss_Stand(self);
        boss_dead_stage = new Boss_Dead(self);
        boss_att1_stage = new Boss_Att1(self);
        boss_att2_stage = new Boss_Att2(self);
        boss_att3_stage = new Boss_Att3(self);
        boss_backjump_stage = new Boss_Backjump(self);
        boss_gun_stage = new Boss_Gun(self);
        boss_hurt_stage = new Boss_Hurt(self);
        boss_jatt_stage = new Boss_Jatt(self);

        Hp = maxhp;
        hurt_count = hurt_yuzhi;
        enemy = new Enemy(boss_stand_stage);
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

            enemy.SetStage(boss_dead_stage);
            candamage = false;
            dead = true;
        }
        // tuozhan();
        FSeePlayer();
        attcd -= Time.deltaTime;
        exattcd -= Time.deltaTime;

        houtiao();
    }

    void houtiao()
    {
        if(Vector3.Distance(testplayer.Instance.transform.position,transform.position)<3&&Player_Controller_System.Instance.Button_X == Player_Controller_System.Button_Stage.down)
        {
            if(Random.Range(0,100)<30)
            {
                if (enemy._enemy==boss_stand_stage)
                enemy.SetStage(boss_backjump_stage);
            }
        }

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
        bool b = Physics.Raycast(transform.position + transform.forward * 1, -transform.up, 2f, 1 << 9);

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

        bool a = Physics.BoxCast(transform.position, Vector3.one, transform.forward, Quaternion.identity, visionfield * 2, player_layermask);
        bool b = Physics.BoxCast(transform.position, Vector3.one, -transform.forward, Quaternion.identity, visionfield, player_layermask);
        bool c = Physics.OverlapSphere(this.transform.position, 5, player_layermask).Length != 0 ? true : false;



        if ((a || b || c) && !fighting)
        {
            fighting = true;
        }

        return a || b || c;
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

            ProcessSystem.Instance.FPlayerWeapon_Enemy(other, this);
            StartCoroutine(wudicount());
        }
        //ProcessSystem.Instance.FPlayerWeapon_Enemy(other, this);

        //if (other.tag == "player_weapon" && (enemy._enemy == boss_att1_stage ))
        //{
        //    if (testplayer.Instance.transform.position.x - this.transform.position.x > 0 && faceto == -1)
        //    {
        //        faceto *= -1;
        //    }
        //    else if (testplayer.Instance.transform.position.x - this.transform.position.x < 0 && faceto == 1)
        //    {
        //        faceto *= -1;
        //    }
        //}
    }

    public override void destroyself()
    {
        Destroy(this.gameObject);
        // Destroy(weapon.gameObject);
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
    public int switch_skill()
    {
        int a = -1;
        while(a==-1)
        {
            if(FAttPlayer())
            {
                int[] fatt = { 1, 3, 4, 5 };
                if(Random.Range(0,2)==0)
                {
                    a = 1;
                }
                else
                {
                    a = fatt[Random.Range(1,4)];
                }
            }
            else
            {
                int[] fatt = { 2, 3, 4, 5 };
                a = fatt[Random.Range(0, 4)];
            }
        }
       
        if(a!=skillid)
        {
            skillid = a;
            return a;
        }
        else
        {
            return switch_skill();
        }
        
    }

}
