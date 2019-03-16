using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_lizarrd : enemy_base
{
     void Start()
    {
        Stage = Enemy_Stage.stand;
    }
    private void Update()
    {
        FSM(Stage);

    }



    public override void FSM(Enemy_Stage stage)
    {
        switch (stage)
        {
            case Enemy_Stage.att:
                {

                }
                break;
            case Enemy_Stage.move:
                {

                }
                break;
            case Enemy_Stage.stand:
                {

                }
                break;
                

        }
    }
}
