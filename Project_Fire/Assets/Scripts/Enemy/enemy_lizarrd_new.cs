//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class enemy_lizarrd_new : enemy_base
//{


//    void Start()
//    {

//        Stage = Enemy_Stage.stand;
//    }
//    private void Update()
//    {
//        FSM(Stage);

//        FCheckFilp();
//    }

//    public override void FSM(Enemy_Stage stage_canshu)
//    {
//        if (faceto == 1)
//        {
//            transform.rotation = Quaternion.Euler(0, 90, 0);
//        }
//        else
//        {
//            transform.rotation = Quaternion.Euler(0, -90, 0);
//        }
//        switch (stage_canshu)
//        {
//            case Enemy_Stage.att:
//                {

//                    StartCoroutine(att(2f));

//                }
//                break;
//            case Enemy_Stage.walk:
//                {
//                    // anim.SetBool("run", false);
//                    anim.CrossFade("lizarrd_walk",0.2f);
//                    transform.Translate(transform.right * -faceto * movespeed * Time.deltaTime, Space.Self);
//                    if (FCheckFilp())
//                    {
//                        Stage = Enemy_Stage.stand;
//                        //anim.SetBool("stand", true);
//                        anim.CrossFade("lizarrd_walk", 0.2f);
//                    }
//                    if (FSeePlayer())
//                    {
//                        Stage = Enemy_Stage.run;
//                        //anim.SetBool("run", true);
//                        anim.CrossFade("lizarrd_run", 0.2f);

//                    }else if (FAttPlayer())
//                    {
//                        Stage = Enemy_Stage.att;
//                        //anim.SetTrigger("att");
//                        anim.CrossFade("lizarrd_att", 0.2f);
//                    }
//                }
//                break;
//            case Enemy_Stage.stand:
//                {

//                   // anim.CrossFade("lizarrd_walk", 0.2f);


//                    faceto *= -1;
//                    transform.Translate(transform.right * -faceto * movespeed * 2.5f * Time.deltaTime, Space.Self);
//                    Stage = Enemy_Stage.walk;
//                    //anim.SetBool("run", false);
//                    //anim.SetBool("stand", false);
//                    //StartCoroutine(stand_lizarrd(1));

//                }
//                break;
//            case Enemy_Stage.run:
//                {

//                    transform.Translate(transform.right * -faceto * movespeed * 2.5f * Time.deltaTime, Space.Self);
//                    if (FCheckFilp())
//                    {
//                        Stage = Enemy_Stage.stand;
//                        //anim.SetBool("stand", true);
//                        anim.CrossFade("lizarrd_walk", 0.2f);
//                    }

//                    if (FAttPlayer())
//                    {
//                        Stage = Enemy_Stage.att;
//                       // anim.SetTrigger("att");
//                        anim.CrossFade("lizarrd_att", 0.2f);
//                    }
//                }
//                break;
//            case Enemy_Stage.hurt:
//                {


//                    //FHurt(1, Enemy_Stage.stand);
//                    FFaceToPlayer();
//                    FBeHurt(beattforce);

//                    Stage = Enemy_Stage.walk;


//                }
//                break;


//        }
//    }

//    public override void FBeatBack()
//    {
//    }

//    public override void FBeHurt(int damage)
//    {
//    }

//    public override void FEnableMove()
//    {
//    }

//    public override void FDisableMove()
//    {
//    }

//    public override void FBeHurt(float force)
//    {
//        if (testplayer.Instance.transform.position.x < this.transform.position.x)
//        {
//            this.GetComponent<Rigidbody>().velocity += new Vector3(1, 1, 0) * force;
//        }
//        else
//        {
//            this.GetComponent<Rigidbody>().velocity += new Vector3(-1, 1, 0) * force;
//        }

//    }
//    public override bool FCheckFilp()
//    {
//        bool a;// = Physics.Raycast(transform.position, transform.forward, 1f, 1 << 9);
//        a = Physics.BoxCast(transform.position, Vector3.one, transform.forward, Quaternion.identity, 1, 1 << 9);
//        bool b;//= Physics.Raycast(transform.position, -transform.up, 2, 1 << 9);
//        b = Physics.BoxCast(transform.position+transform.up + transform.forward * 1, Vector3.one*0.1f, -transform.up, Quaternion.identity, 3, 1 << 9);
//        print(!b);
//        return a || !b;
//    }
//    public override bool FAttPlayer()
//    {
//        //return Physics.Raycast(transform.position, transform.forward, attfield, player_layermask);
//        return Physics.BoxCast(transform.position, Vector3.one, transform.forward, Quaternion.identity, attfield, player_layermask);
//    }
//    public override void FFaceToPlayer()
//    {
//        if (testplayer.Instance.transform.position.x < this.transform.position.x)
//        {
//            this.faceto = -1;
//        }
//        else
//        {
//            this.faceto = 1;
//        }
//    }
//    public override bool FSeePlayer()
//    {
//        //return Physics.Raycast(transform.position, transform.forward, visionfield, player_layermask);
//        return Physics.BoxCast(transform.position, Vector3.one, transform.forward, Quaternion.identity, visionfield, player_layermask);
//    }
//    public IEnumerator stand_lizarrd(float time)
//    {
//        // yield return 
//        yield return new WaitForSeconds(time);
//        transform.Rotate(0, 180, 0, Space.Self);
//        faceto *= -1;
//        Stage = Enemy_Stage.walk;
//        StopAllCoroutines();
//    }

//    public IEnumerator att(float time)
//    {
//        // yield return 
//        yield return new WaitForSeconds(time);
//        StopAllCoroutines();
//        Stage = Enemy_Stage.walk;

//    }

//    private void OnTriggerEnter(Collider other)
//    {

//        ProcessSystem.Instance.FPlayerWeapon_Enemy(WeaponSystem.instance, other, this);
//    }
//    public override IEnumerator FHurt(float time, Enemy_Stage stage_)
//    {
//        yield return new WaitForSeconds(time);
//        print(11);
//        FFaceToPlayer();
//        // FBeHurt();
//        Stage = stage_;
//        StopAllCoroutines();
//    }
//}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_lizarrd_new : enemy_base
{
    public Enemy enemy;
    public enemy_lizarrd_new self;


    public Lizarrd_Stand lizarrd_stand_stage;
    public Lizarrd_Hurt lizarrd_hurt_stage;
    public Lizarrd_Dead lizarrd_dead_stage;
    public Lizarrd_Walk lizarrd_walk_stage;
    public Lizarrd_Att lizarrd_att_stage;
    public Lizarrd_Run lizarrd_run_stage;
    private void Awake()
    {
        type = "lizarrd";
        if(self!=this)
        {
            self = this;
        }
        lizarrd_stand_stage = new Lizarrd_Stand(self);
        lizarrd_att_stage = new Lizarrd_Att(self);
        lizarrd_dead_stage = new Lizarrd_Dead(self);
        lizarrd_hurt_stage = new Lizarrd_Hurt(self);
        lizarrd_run_stage = new Lizarrd_Run(self);
        lizarrd_walk_stage = new Lizarrd_Walk(self);

        Hp = maxhp;
        hurt_count = hurt_yuzhi;
        enemy = new Enemy(lizarrd_walk_stage);
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

        if(Hp<=0&&!dead)
        {
            
            enemy.SetStage(lizarrd_dead_stage);
            candamage = false;
            dead = true;
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
        bool b= Physics.Raycast(transform.position + transform.up + transform.forward * 1, -transform.up, 1.5f, 1 << 9);
       // b = Physics.BoxCast(transform.position + transform.up + transform.forward * 1, Vector3.one * 0.1f, -transform.up, Quaternion.identity, 3, 1 << 9);

        return a || !b;
    }
    public override bool FAttPlayer()
    {
        //return Physics.Raycast(transform.position, transform.forward, attfield, player_layermask);
        return Physics.BoxCast(transform.position, Vector3.one, transform.forward, Quaternion.identity, attfield, player_layermask);
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
        return Physics.BoxCast(transform.position, Vector3.one, transform.forward, Quaternion.identity, visionfield, player_layermask);
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

        if(other.tag=="player_weapon"&&enemy._enemy!=lizarrd_att_stage && enemy._enemy != lizarrd_hurt_stage&& enemy._enemy != lizarrd_dead_stage && enemy._enemy != lizarrd_stand_stage)
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
