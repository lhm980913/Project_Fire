using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Lizard_State : EnemyState_Base
{
    protected enemy_base instance;
    abstract public void Enter();
    abstract public IEnumerator<YieldInstruction> Update();
    abstract public void Exit();
}

public class Lizard_State_Stand : Lizard_State
{
    public Lizard_State_Stand(enemy_base enemy)
    {
        instance = enemy;
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

public class Lizard_State_Walk : Lizard_State
{
    public Lizard_State_Walk(enemy_base enemy)
    {
        instance = enemy;
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

public class Lizard_State_Run : Lizard_State
{
    public Lizard_State_Run(enemy_base enemy)
    {
        instance = enemy;
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

public class Lizard_State_Attack : Lizard_State
{
    public Lizard_State_Attack(enemy_base enemy)
    {
        instance = enemy;
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

public class Lizard_State_Hurt : Lizard_State
{
    public Lizard_State_Hurt(enemy_base enemy)
    {
        instance = enemy;
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
