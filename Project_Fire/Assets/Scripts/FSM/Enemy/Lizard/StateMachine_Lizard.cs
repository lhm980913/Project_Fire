using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lizard_StateMachine : FiniteStateMachine
{
    public Lizard_StateMachine(enemy_base e, Animator animator)
    {
        Lizard_State_Alert alert = new Lizard_State_Alert(e,this);
        Lizard_State_Attack attack = new Lizard_State_Attack(e,this);
        Lizard_State_Hurt hurt = new Lizard_State_Hurt(e,this);
        Lizard_State_Idle idle = new Lizard_State_Idle(e,this);
        Lizard_State_Patrol patrol = new Lizard_State_Patrol(e,this);

        states.Add("alert", alert);
        states.Add("attack", attack);
        states.Add("hurt", hurt);
        states.Add("idle", idle);
        states.Add("patrol", patrol);

        initialState = idle;
        activeState = idle;
    }
}
//State
public class Lizard_State_Idle : EnemyState_Base
{
    public Lizard_State_Idle(enemy_base enemy,FiniteStateMachine f)
    {
        instance = enemy;
        fsm = f;
    }

    override public void Enter()
    {

    }

    override public IEnumerator<YieldInstruction> Update()
    {
        yield return null;
    }

    override public void Exit()
    {

    }
}

public class Lizard_State_Alert : EnemyState_Base
{
    public Lizard_State_Alert(enemy_base enemy, FiniteStateMachine f)
    {
        instance = enemy;
        fsm = f;
    }

    override public void Enter()
    {

    }

    override public IEnumerator<YieldInstruction> Update()
    {
        yield return null;
    }

    override public void Exit()
    {

    }
}

public class Lizard_State_Patrol : EnemyState_Base
{
    public Lizard_State_Patrol(enemy_base enemy, FiniteStateMachine f)
    {
        instance = enemy;
        fsm = f;
    }

    override public void Enter()
    {

    }

    override public IEnumerator<YieldInstruction> Update()
    {
        yield return null;
    }

    override public void Exit()
    {

    }
}

public class Lizard_State_Attack : EnemyState_Base
{
    public Lizard_State_Attack(enemy_base enemy, FiniteStateMachine f)
    {
        instance = enemy;
        fsm = f;
    }

    override public void Enter()
    {

    }

    override public IEnumerator<YieldInstruction> Update()
    {
        yield return null;
    }

    override public void Exit()
    {

    }
}

public class Lizard_State_Hurt : EnemyState_Base
{
    public Lizard_State_Hurt(enemy_base enemy, FiniteStateMachine f)
    {
        instance = enemy;
        fsm = f;
    }

    override public void Enter()
    {

    }

    override public IEnumerator<YieldInstruction> Update()
    {
        yield return null;
    }

    override public void Exit()
    {

    }
}