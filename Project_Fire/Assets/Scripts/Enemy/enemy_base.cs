using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Enemy_Stage
{
    stand,
    att,
    walk,
    run,
    hurt
}
public class enemy_base : MonoBehaviour
{
    public float maxhp;
    public float attfield;
    public float movespeed;
    public float visionfield;
    public float beattforce;
    public bool atting = false;
    public Animator anim;

    private bool canMove;
    protected int faceto = 1;
    protected LayerMask player_layermask = 1 << 12;

   
    Enemy_Stage _stage;
    public Enemy_Stage Stage
    {
        get
        {
            return this._stage;
        }
        set
        {
            this._stage = value;
        }

    }
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

    protected virtual void OnTriggerEnter(Collider other)
    {
        


    }

}
