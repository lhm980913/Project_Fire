using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Lizard_StateMachine : EnemyState_Base
{
    abstract public void Enter();
    abstract public void Update();
    abstract public void Exit();
}

public class Lizard_State_Stand : Lizard_StateMachine
{
    override public void Enter()
    {

    }

    override public void Update()
    {

    }

    override public void Exit()
    {

    }
}

public class Lizard_State_Walk : Lizard_StateMachine
{
    override public void Enter()
    {

    }

    override public void Update()
    {

    }

    override public void Exit()
    {

    }
}

public class Lizard_State_Run : Lizard_StateMachine
{
    override public void Enter()
    {

    }

    override public void Update()
    {

    }

    override public void Exit()
    {

    }
}

public class Lizard_State_Attack : Lizard_StateMachine
{
    override public void Enter()
    {

    }

    override public void Update()
    {

    }

    override public void Exit()
    {

    }
}

public class Lizard_State_Hurt : Lizard_StateMachine
{
    override public void Enter()
    {

    }

    override public void Update()
    {

    }

    override public void Exit()
    {

    }
}
