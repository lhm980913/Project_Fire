//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;


//public enum Enemy_Stage
//{
//    Idle,
//    Attack,
//    Patrol,
//    Alert,
//    Hurt
//    
//}
//public class enemy_base : MonoBehaviour
//{
//    public float MaxHP;
//    public float ATK;
//    public float VisionDistance;
//    public float AttackDistance;
//    public float MoveSpeed;
//    public float RunSpeed;
//    public float IdleTime;
//    public bool  BeatAway;
//    public float LowBeatForce;
//    public float HighBeatForce;
//    public float HitCD;

//    public bool atting = false;
//    public Animator anim;

//    private float HP;

//    protected Coroutine stateCoroutine;
//    protected int faceto = 1;
//    protected LayerMask player_layermask = 1 << 12;
//    protected BehaviorDesigner.Runtime.BehaviorTree BT;

//    Enemy_Stage _stage;
//    public Enemy_Stage Stage
//    {
//        get{return this._stage;}
//        set{this._stage = value;}
//    }
//    public float Hp
//    {
//        set
//        {
//            this.HP = Mathf.Clamp(value, 0f, MaxHP);

//        }
//        get
//        {
//            return this.HP;
//        }
//    }

//    public virtual void FSM(Enemy_Stage stage)
//    {

//    }
//    public virtual void FBeatBack()
//    {

//    }
//    public virtual void FBeHurt(int damage)
//    {

//    }
//    public virtual void FEnableMove()
//    {

//    }
//    public virtual void FDisableMove()
//    {

//    }
//    public virtual void FBeHurt(float force)
//    {

//    }

//    public virtual bool FCanSeePlayer()
//    {
//        return false;
//    }
//    public virtual bool FCanAttPlayer()
//    {
//        return false;
//    }
//    public virtual bool FCanFilp()
//    {
//        return false;
//    }
//    public virtual bool FIsFaceToPlayer()
//    {
//        return false;
//    }
//    public virtual IEnumerator FHurt(float time,Enemy_Stage stage_)
//    {
//        yield return new WaitForSeconds(time);
//        Stage = stage_;
//        StopAllCoroutines();
//    }


//}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//public enum Enemy_Stage
//{
//    stand,
//    att,
//    walk,
//    run,
//    hurt
//}
public class enemy_base : UnityEngine.MonoBehaviour
{

    public string type = "";
    public float maxhp;
    public float attfield;
    public float movespeed;
    public float visionfield;
    public float beattforce;
    public float hurt_count;
    public float hurt_yuzhi;
    public bool atting = false;
    public bool dead = false;
    public Animator anim;
    public bool candamage = true;

    private bool canMove;
    public int faceto = 1;
    public LayerMask player_layermask = 1 << 12;


    //Enemy_Stage _stage;
    //public Enemy_Stage Stage
    //{
    //    get
    //    {
    //        return this._stage;
    //    }
    //    set
    //    {
    //        this._stage = value;
    //    }

    //}
    float _hp;
    public float Hp
    {
        set
        {
            this._hp = Mathf.Clamp(value, 0f, maxhp);

        }
        get
        {
            return this._hp;
        }
    }

    //public virtual void FSM(Enemy_Stage stage)
    //{

    //}
    public virtual void FBeatBack()
    {

    }
    public virtual void FBeHurt(int damage)
    {

    }
    public virtual void FEnableMove()
    {

    }
    public virtual void FDisableMove()
    {

    }
    public virtual void FBeHurt(float force)
    {

    }


    public virtual bool FSeePlayer()
    {
        return false;
    }
    public virtual bool FAttPlayer()
    {
        return false;
    }
    public virtual bool FCheckFilp()
    {
        return false;
    }
    public virtual void FFaceToPlayer()
    {

    }
    //public virtual IEnumerator FHurt(float time, Enemy_Stage stage_)
    //{
    //    yield return new WaitForSeconds(time);
    //    Stage = stage_;
    //    StopAllCoroutines();
    //}

    protected virtual void OnTriggerEnter(Collider other)
    {

        ProcessSystem.Instance.FPlayerWeapon_Enemy(other, this);
        

    }
    public virtual void destroyself()
    {
        Destroy(this.gameObject);
    }
}
