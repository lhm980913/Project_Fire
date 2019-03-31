using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface EnemyState_Base
{
    void Enter();
    IEnumerator<YieldInstruction> Update();
    void Exit();
}

