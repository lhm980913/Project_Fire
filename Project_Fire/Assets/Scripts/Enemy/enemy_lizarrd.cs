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
        FSM(Stage);
    }

    public override void FSM(Enemy_Stage stage)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            stateCoroutine = StartCoroutine(Hurt());
        }
        switch (stage)
        {
            case Enemy_Stage.Idle:
                {
                    if (stateCoroutine == null)
                    {
                        stateCoroutine = StartCoroutine(Idle(IdleTime));
                    }
                    if (FSeePlayer())
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
                    if (FSeePlayer())
                    {
                        Stage = Enemy_Stage.Alert;
                        anim.SetTrigger("PatrolToAlert");
                    }
                    if (FCheckFilp())
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
                    if (!FSeePlayer())
                    {
                        Stage = Enemy_Stage.Patrol;
                        anim.SetTrigger("AlertToPatrol");
                    }
                    if (FAttPlayer())
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
                    if (!FAttPlayer())
                    {
                        Stage = Enemy_Stage.Alert;
                        anim.SetTrigger("AttackToAlert");
                    }
                    if (!FSeePlayer())
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
    public override bool FCheckFilp()
    {
        bool a;// = Physics.Raycast(transform.position, transform.forward, 1f, 1 << 9);
        a = Physics.BoxCast(transform.position, Vector3.one, transform.forward, Quaternion.identity, 1, 1 << 9);
        bool b=true;//= Physics.Raycast(transform.position, -transform.up, 2, 1 << 9);
        //b = Physics.BoxCast(transform.position + Vector3.right * 2, Vector3.one, -transform.up, Quaternion.identity, 5, 1 << 9);
        b = Physics.CheckBox(transform.position + transform.forward * 2 - transform.up, Vector3.one, Quaternion.identity, 1 << 9);
        return a||!b;
    }
    public override bool FAttPlayer()
    {
        //return Physics.Raycast(transform.position, transform.forward, attfield, player_layermask);
        return Physics.BoxCast(transform.position, Vector3.one, transform.forward, Quaternion.identity, AttackDistance, player_layermask);
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
        return Physics.BoxCast(transform.position, Vector3.one + (Vector3.right * VisionDistance), transform.forward, Quaternion.identity, VisionDistance, player_layermask);
    }
    public override IEnumerator FHurt(float time, Enemy_Stage stage_)
    {
        yield return new WaitForSeconds(time);
        print(11);
        FFaceToPlayer();
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
    private void FFlip()
    {
        transform.Rotate(new Vector3(0, 180, 0),Space.World);
    }
    private void OnTriggerEnter(Collider other)
    {
        //ProcessSystem.Instance.FPlayerWeapon_Enemy(WeaponSystem.instance,other, this);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawCube(transform.position + transform.forward, Vector3.one);
    }

    //private void OnGUI()
    //{
    //    GUI.Label(new Rect(0, 0, 100, 100), stateCoroutine.ToString());
    //}

}
