using System;
using System.Collections.Generic;
using UnityEngine;

public class XianDan : activeEffect
{
    float Distance;
    float Height;
    int Damage;
    
    Transform playerTransform;

    public XianDan(int damage)
    {
        callType = CallType.active;
        Distance = 4;
        Height = 2;
        playerTransform = testplayer.Instance.transform;
        Name = "霰弹";
        Damage = damage;
        Description = "对角色面前距离为" + Distance + "以内的敌人造成" + Damage + "的伤害，将其击飞，伤害随距离递减";
    }

    public override void Execute()
    {
        Transform playerTransform = testplayer.Instance.transform;
        Collider[] colliders;
        colliders = Physics.OverlapBox(playerTransform.position + playerTransform.forward * 0.5f, new Vector3(Distance / 2, 1, 1), Quaternion.identity, enemy_layermask);
        foreach (var collider in colliders)
        {
            if (collider.transform.tag == "Enemy")
            {
                collider.GetComponent<enemy_base>().FBeatBack();
                collider.GetComponent<enemy_base>().FBeHurt(Damage);
            }
        }
    }
}

public class YinXian : activeEffect
{
    float Duration;
    float Intervals;
    int Damage;
    
    Transform playerTransform;

    YinXian(int damage)
    {
        callType = CallType.active;
        Duration = 0.75f;
        Intervals = 0.25f;
        Damage = damage;
        playerTransform = testplayer.Instance.transform;
        Name = "银线";
        Description = "将与主角同一水平面的所有敌人定身，持续" + Duration + "秒，每" + Intervals + "秒对敌人造成" + Damage + "点伤害";
    }

    public override void Execute()
    {
        
        Collider[] colliders;
        colliders = Physics.OverlapBox(playerTransform.position, new Vector3(100,1,1), Quaternion.identity, enemy_layermask);
        enemy_base[] enemys = new enemy_base[colliders.Length];
        for (int i = 0; i < colliders.Length; i++)
        {
            enemys[i] = colliders[i].GetComponent<enemy_base>();
            enemys[i].FDisableMove();
        }
        WeaponSystem.instance.StartCoroutine(Disable(enemys));
    }

    public IEnumerator<YieldInstruction> Disable(enemy_base[] enemys)
    {
        float time = 0;
        while(time < Duration)
        {
            foreach (var enemy in enemys)
            {
                enemy.FBeHurt(Damage);
            }
            yield return new WaitForSeconds(Intervals);
        }
        foreach (var enemy in enemys)
        {
            enemy.FEnableMove();
        }
    }


}
