using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hurt_Stage : Player_Base_Stage
{
    Vector3 enemypos;
    float count;
    public Hurt_Stage()
    {

    }

    public void Enter()
    {
        count = 0.25f;
        testplayer.Instance.anim.CrossFade("player_strike", 0.1f);
        //Debug.Log("hurt");
        enemypos = testplayer.Instance.enemypos;
        testplayer.Instance.canhurt = false;
        if (enemypos.x-testplayer.Instance.transform.position.x<0)
        {
            testplayer.Instance.GetComponent<Rigidbody>().velocity = new Vector3(1, 1, 0) * testplayer.Instance.hurtforce;
        }
        else
        {
            testplayer.Instance.GetComponent<Rigidbody>().velocity = new Vector3(-1, 1, 0) * testplayer.Instance.hurtforce;
        }

        testplayer.Instance.StartCoroutine(counthurt(testplayer.Instance.canthurtcount));
    }

    public void Input()
    {
        count -= Time.deltaTime;
        if(count<0)
        {
            testplayer._player.SetStage(testplayer.Instance.stand_stage);
        }
            
        
    }

    // Update is called once per frame
    public void Update_()
    {

        testplayer.Instance.playergameobj.GetComponent<Rigidbody>().velocity += Vector3.down * 40 * Time.deltaTime;
    }
    IEnumerator counthurt(float count)
    {
        yield return new WaitForSeconds(count);
        testplayer.Instance.canhurt = true;
        //testplayer.Instance.StopAllCoroutines();
    }

}
