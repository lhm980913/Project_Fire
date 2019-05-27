using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_assassin : enemy_base
{
    public Enemy enemy;
    public enemy_assassin self;


    public Assassin_Stand assassin_stand_stage;
    public Assassin_Hurt assassin_hurt_stage;
    public Assassin_Dead assassin_dead_stage;
    public Assassin_Walk assassin_walk_stage;
    public Assassin_Att assassin_att_stage;
    public Assassin_Att2 assassin_att2_stage;
    public float skillcd;
    [HideInInspector]
    public float skillcound  = 0;

    public SkinnedMeshRenderer assassin1;
    public SkinnedMeshRenderer assassin2;
    public Material assassin_mar;
    private void Awake()
    {
        type = "assassin";
        if (self != this)
        {
            self = this;
        }
        assassin_stand_stage = new Assassin_Stand(self);
        assassin_att_stage = new Assassin_Att(self);
        assassin_dead_stage = new Assassin_Dead(self);
        assassin_hurt_stage = new Assassin_Hurt(self);
        assassin_att2_stage = new Assassin_Att2(self);
        assassin_walk_stage = new Assassin_Walk(self);

        Hp = maxhp;
        hurt_count = hurt_yuzhi;
        enemy = new Enemy(assassin_stand_stage);
    }
    private void Start()
    {

    }


    private void Update()
    {
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

            enemy.SetStage(assassin_dead_stage);
            candamage = false;
            dead = true;
        }
        skillcound -= Time.deltaTime;
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
    protected override void OnTriggerEnter(Collider other)
    {
        if (!wudi)
        {
            ProcessSystem.Instance.FPlayerWeapon_Enemy(other, this);
            StartCoroutine(wudicount());
        }
      //  ProcessSystem.Instance.FPlayerWeapon_Enemy(other, this);

        if (other.tag == "player_weapon" && enemy._enemy != assassin_att_stage && enemy._enemy != assassin_hurt_stage && enemy._enemy != assassin_dead_stage && enemy._enemy != assassin_stand_stage )
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




//}

