using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy
{
    public Enemy_Base_Stage _enemy;

    public Enemy(Enemy_Base_Stage stage)
    {
        _enemy = stage;
    }
    public void SetStage(Enemy_Base_Stage stage)
    {
        stage.Enter();
        _enemy = stage;
    }
    public void Update()
    {
       
        _enemy.Update();
        _enemy.Check();
    }
}
