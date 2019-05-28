using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    Player_Base_Stage stage;

    public Player()
    {
        stage = new Stand_Stage();
    }

    public void SetStage(Player_Base_Stage _stage)
    {
        stage = _stage;
        _stage.Enter();
    }

    public void Update()
    {
        stage.Input();
        stage.Update_();
    }
    
}
