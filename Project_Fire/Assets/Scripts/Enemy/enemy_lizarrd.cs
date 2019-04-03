using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_lizarrd : enemy_base
{
    
    void Start()
    {
        Stage = Enemy_Stage.Idle;  
    }
    private void Update()
    {
        //FSM(Stage);
        RuleBasedAI();
    }

    public override void FSM(Enemy_Stage stage)
    {
        switch (stage)
        {
            case Enemy_Stage.Idle:
                {
                    if (stateCoroutine == null)
                    {
                        stateCoroutine = StartCoroutine(Idle(IdleTime));
                    }
                    if (FCanSeePlayer())
                    {
                        Stage = Enemy_Stage.Alert;
                        anim.SetTrigger("IdleToAlert");
                        StopCoroutine(stateCoroutine);
                    }
                    break;
                }
            case Enemy_Stage.Patrol:
                {
                    stateCoroutine = null;
                    if (FCanSeePlayer())
                    {
                        Stage = Enemy_Stage.Alert;
                        anim.SetTrigger("PatrolToAlert");
                    }
                    if (FCanFilp())
                    {
                        Stage = Enemy_Stage.Idle;
                        anim.SetTrigger("PatrolToIdle");
                    }
                    transform.Translate(Vector3.forward * MoveSpeed * Time.deltaTime, Space.Self);
                    break;
                }
            case Enemy_Stage.Alert:
                {
                    stateCoroutine = null;
                    if (!FCanSeePlayer())
                    {
                        Stage = Enemy_Stage.Patrol;
                        anim.SetTrigger("AlertToPatrol");
                    }
                    if (FCanAttPlayer())
                    {
                        Stage = Enemy_Stage.Attack;
                        anim.SetTrigger("AlertToAttack");
                    }
                    if((Player_Controller_System.Instance.transform.position.x - transform.position.x) < 0)
                    {
                        FFlip();
                        transform.Translate(Vector3.right * MoveSpeed * Time.deltaTime, Space.Self);
                    }
                    else
                    {
                        transform.Translate(Vector3.right * MoveSpeed * Time.deltaTime, Space.Self);
                    }
                    break;
                }
            case Enemy_Stage.Attack:
                {
                    if (!FCanAttPlayer())
                    {
                        Stage = Enemy_Stage.Alert;
                        anim.SetTrigger("AttackToAlert");
                    }
                    if (!FCanSeePlayer())
                    {
                        Stage = Enemy_Stage.Patrol;
                        anim.SetTrigger("AttackToPatrol");
                    }
                    break;
                }
            case Enemy_Stage.Hurt:
                {
                    
                    break;
                }
        }
    }

    public override void FBeatBack()
    {
    }

    public override void FBeHurt(int damage)
    {
    }

    public override void FEnableMove()
    {
    }

    public override void FDisableMove()
    {
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
    
    public override IEnumerator FHurt(float time, Enemy_Stage stage_)
    {
        yield return new WaitForSeconds(time);
        print(11);
        FIsFaceToPlayer();
        // FBeHurt();
        Stage = stage_;
        StopAllCoroutines();
    }
    public IEnumerator Idle(float time)
    {
       // yield return 
        yield return new WaitForSeconds(time);
        FFlip();
        anim.SetTrigger("IdleToPatrol");
        Stage = Enemy_Stage.Patrol;
    }
    public IEnumerator Hurt()
    {
        anim.SetTrigger("AnyToHurt");
        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime < 1)
        {
            yield return null;
        }
        anim.SetTrigger("HurtToAlert");
    }
    public IEnumerator att(float time)
    {
        // yield return 
        yield return new WaitForSeconds(time);
        Stage = Enemy_Stage.Alert;
        StopAllCoroutines();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        //ProcessSystem.Instance.FPlayerWeapon_Enemy(WeaponSystem.instance,other, this);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawCube(transform.position, Vector3.one + transform.forward * VisionDistance);
    }

    //private void OnGUI()
    //{
    //    GUI.Label(new Rect(0, 0, 100, 100), stateCoroutine.ToString());
    //}
    /************************************************RuleBasedAI******************************************/
    private void RuleBasedAI()
    {
        if(anim.GetCurrentAnimatorStateInfo(0).IsName("Attack")&&anim.GetCurrentAnimatorStateInfo(0).normalizedTime <= 1)
        {
            return;
        }
        if (FCanAttPlayer())
        {
            FAttack();
            Debug.Log("Att");
            return;
        }
        
        if (FCanSeePlayer())
        {
            FCatch();
            Debug.Log("cat");
            return;
        }
        else 
        {
            FPatrol();
            Debug.Log("Patrol");
            return;
        }
        Debug.Log("Bug");
    }
    /****************************************************************************************************/

    /************************************************Declare**********************************************/
    public override bool FCanFilp()
    {
        bool a = Physics.BoxCast(transform.position, Vector3.one, transform.forward, Quaternion.identity, 1, 1 << 9);
        bool b = Physics.CheckBox(transform.position + transform.forward * 2 - transform.up, Vector3.one, Quaternion.identity, 1 << 9);
        return a || !b;
    }

    public override bool FCanAttPlayer()
    {
        return Physics.BoxCast(transform.position, Vector3.one * 0.5f, transform.forward, Quaternion.identity, AttackDistance, player_layermask);
        
    }

    public override bool FIsFaceToPlayer()
    {
        if((testplayer.Instance.transform.position - transform.position).x * transform.forward.x < 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    public override bool FCanSeePlayer()
    {
        //return Physics.BoxCast(transform.position, Vector3.one, transform.forward, Quaternion.identity, VisionDistance, player_layermask);
        return Physics.CheckBox(transform.position, Vector3.one + transform.forward * VisionDistance, Quaternion.identity, player_layermask);
    }
    /***********************************************************************************************************/

    /*************************************************Action****************************************************/
    private void FFlip()
    {
        transform.Rotate(new Vector3(0, 180, 0), Space.Self);
    }

    private void FAttack()
    {
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            //anim.Play("Attack");
            anim.CrossFade("Attack", 0.01f);
        }
        else if(anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1){
            anim.Play("Attack",0,0.0f);
        }
    }

    private void FWalk()
    {
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Walk"))
        {
            //anim.Play("Walk",0,0.0f);
            anim.CrossFade("Walk", 0.01f);
        }
        transform.Translate(transform.forward * MoveSpeed * Time.deltaTime, Space.World);
    }

    private void FCatch()
    {
        if (FIsFaceToPlayer())
        {
            FWalk();
        }
        else
        {
            FFlip();
            FWalk();
        }
    }

    private void FPatrol()
    {
        if (FCanFilp())
        {
            FFlip();
            FWalk();
        }
        else
        {
            FWalk();
        }
    }

    private void FStand()
    {
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Stand"))
        {
            anim.CrossFade("Stand", 0.0f);
        }
    }

    //private void FIsDead()
    //{
    //    if(Hp <= 0)
    //    {
    //        animation.Play("Lizard_Dead");
    //    }
    //}
    /***********************************************************************************************************/
}
