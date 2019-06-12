using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initiative_Stage : Player_Base_Stage
{
    float count;
    
    public Initiative_Stage()
    {

    }
    public void Enter()
    {
        Rune Rune;
        
        if(testplayer.Instance.skillid==1)
        {
            if (RuneManager.Instance.TryGetRune(0, out Rune))
            {
                if(testplayer.Instance.mana>Rune.MpNeed)
                {
                    if (Rune.Name == "XianDan")
                    {
                        testplayer.Instance.anim.CrossFade("player_gunshot", 0.1f);
                    }
                    else
                    {
                        testplayer.Instance.anim.CrossFade("player_specialattack", 0.1f);
                    }
                }
    
              
            }
            testplayer.Instance.FActiveRuneOne();
        }
        else
        {
            if (RuneManager.Instance.TryGetRune(1, out Rune))
            {
                if (testplayer.Instance.mana > Rune.MpNeed)
                {
                    if (Rune.Name == "XianDan")
                    {
                        testplayer.Instance.anim.CrossFade("player_gunshot", 0.1f);
                    }
                    else
                    {
                        testplayer.Instance.anim.CrossFade("player_specialattack", 0.1f);
                    }
                }
             
            }
            testplayer.Instance.FActiveRuneTwo();
        }


        count = 0.2f;

        Player_Function.FStop(testplayer.Instance.gameObject);
    }

    public void Input()
    {
        
    }

    // Update is called once per frame
    public void Update_()
    {
        count -= Time.deltaTime;
        if(count<0)
        {
            testplayer._player.SetStage(testplayer.Instance.jump_stage);
        }
    }
}
