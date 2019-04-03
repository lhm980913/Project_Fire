using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Enemy_Stage
{
    Idle,
    Attack,
    Patrol,
    Alert,
    Hurt
}
public class enemy_base : MonoBehaviour
{
    public float MaxHP;
    public float ATK;
    public float VisionDistance;
    public float AttackDistance;
    public float MoveSpeed;
    public float IdleTime;
    public bool  BeatAway;
    public float LowBeatForce;
    public float HighBeatForce;

    public bool atting = false;
    public Animator anim;

    private float HP;

    protected Coroutine stateCoroutine;
    protected int faceto = 1;
    protected LayerMask player_layermask = 1 << 12;
   
    Enemy_Stage _stage;
    public Enemy_Stage Stage
    {
        get{return this._stage;}
        set{this._stage = value;}
    }
    public float Hp
    {
        set
        {
            this.HP = Mathf.Clamp(value, 0f, MaxHP);

        }
        get
        {
            return this.HP;
        }
    }

    public virtual void FSM(Enemy_Stage stage)
    {

    }
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
    public virtual IEnumerator FHurt(float time,Enemy_Stage stage_)
    {
        yield return new WaitForSeconds(time);
        Stage = stage_;
        StopAllCoroutines();
    }
    

}
