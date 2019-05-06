using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_bird : enemy_base
{

    public Enemy enemy;
    public enemy_bird self;

    public Bird_Att bird_att_stage;
    public Bird_Dead bird_dead_stage;
    public Bird_Hurt bird_hurt_stage;
    public Bird_Move bird_move_stage;
    public Bird_Stand bird_stand_stage;

    Vector3 beginpos;
    public float xunluofanwei;
    public GameObject bullet;
    private void Awake()
    {
        type = "bird";
        if (self != this)
        {
            self = this;
        }
        bird_att_stage = new Bird_Att(self);
        bird_dead_stage = new Bird_Dead(self);
        bird_hurt_stage = new Bird_Hurt(self);
        bird_move_stage = new Bird_Move(self);
        bird_stand_stage = new Bird_Stand(self);

        
        hurt_count = hurt_yuzhi;
        Hp = maxhp;
        
        enemy = new Enemy(bird_stand_stage);
    }
    private void Start()
    {
        beginpos = this.transform.position;
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
            candamage = false;
            enemy.SetStage(bird_dead_stage);
            dead = true;
        }

        
    }

    public override bool FAttPlayer()
    {
        return base.FAttPlayer();


    }
    public override bool FSeePlayer()
    {

        Collider[] a = Physics.OverlapSphere(transform.position, visionfield, player_layermask);
        if(a.Length==0)
        {
            return false;
        }
        else
        {
            return true;
        }
         
    }
    public override bool FCheckFilp()
    {
        bool a = Physics.Raycast(transform.position, transform.forward, 1f, 1 << 9);
        if (this.transform.position.x > beginpos.x + xunluofanwei||a)
        {
            return true;
        }
        else if(this.transform.position.x < beginpos.x - xunluofanwei)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void Fatt()
    {

        //print("att");
        GameObject a = Instantiate(bullet);
        a.transform.position = this.transform.position;
        
    }

   

}
