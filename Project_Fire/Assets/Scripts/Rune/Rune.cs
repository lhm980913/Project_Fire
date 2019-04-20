using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class Rune
{
    private RuneEvent rune_Event;
    public RuneEvent runeEvent
    {
        get
        {
            return rune_Event;
        }
        set
        {
            rune_Event = value;
        }
    }
    public RuneEntity runeEntity;
    protected string name;
    public string Name
    {
        get
        {
            return name;
        }
    }
    public Rune(RuneEntity runeEntity)
    {
        this.runeEntity = runeEntity;
    }
    public abstract void Execute();
}

public class testRune : Rune
{
    public testRune(RuneEntity runeEntity):base(runeEntity)
    {
        runeEvent = RuneEvent.OnAttack;
        this.name = "Test";
        this.runeEntity = runeEntity;
    }
    public override void Execute()
    {
        Debug.Log("TestRune");
    }
}

public class XianDan : Rune
{
    testplayer player;
    public XianDan(RuneEntity runeEntity) : base(runeEntity)
    {
        runeEvent = RuneEvent.Active;
        this.name = "XianDan";
        this.runeEntity = runeEntity;
        player = testplayer.Instance;
    }
    public override void Execute()
    {
        Collider[] colliders;
        colliders = Physics.OverlapBox(player.transform.position + Vector3.right * testplayer.Instance.face_to * 2.0f * 0.6f, new Vector3(2.0f, 1.0f, 1.0f), Quaternion.identity, 1 << 11);
        foreach (var collider in colliders)
        {
            if(collider.tag == "enemy")
            {
                ProcessSystem.Instance.FPlayerSkill_Enemy(collider.gameObject.GetComponent<enemy_base>());
            }
        }
    }
}

public class YinXian : Rune
{
    public YinXian(RuneEntity runeEntity) : base(runeEntity)
    {

    }

    public override void Execute()
    {
        throw new NotImplementedException();
    }
}

//public class YinXian : activeEffect
//{
//    float Duration;
//    float Intervals;
//    int Damage;

//    Transform playerTransform;

//    public YinXian(int damage)
//    {
//        callType = CallType.active;
//        Duration = 0.75f;
//        Intervals = 0.25f;
//        Damage = damage;
//        playerTransform = testplayer.Instance.transform;
//        Name = "银线";
//        Description = "将与主角同一水平面的所有敌人定身，持续" + Duration + "秒，每" + Intervals + "秒对敌人造成" + Damage + "点伤害";
//    }

//    public override void Execute()
//    {

//        Collider[] colliders;
//        colliders = Physics.OverlapBox(playerTransform.position, new Vector3(100,1,1), Quaternion.identity, enemy_layermask);
//        enemy_base[] enemys = new enemy_base[colliders.Length];
//        for (int i = 0; i < colliders.Length; i++)
//        {
//            enemys[i] = colliders[i].GetComponent<enemy_base>();
//            enemys[i].FDisableMove();
//        }
//        WeaponSystem.instance.StartCoroutine(Disable(enemys));
//    }

//    private IEnumerator<YieldInstruction> Disable(enemy_base[] enemys)
//    {
//        float time = 0;
//        while(time < Duration)
//        {
//            foreach (var enemy in enemys)
//            {
//                enemy.FBeHurt(Damage);
//            }
//            yield return new WaitForSeconds(Intervals);
//        }
//        foreach (var enemy in enemys)
//        {
//            enemy.FEnableMove();
//        }
//    }


//}

//public class HuiShen : activeEffect
//{
//    float Duration;
//    float Intervals;
//    float Distance;
//    float Damage;
//    float ShockRadius;
//    float ShockDamage;

//    Transform playerTransform;

//    public HuiShen(int damage, int shockDamage)
//    {
//        Duration = 3;
//        Intervals = 0.5f;
//        Distance = 2;
//        ShockDamage = shockDamage;
//        playerTransform = testplayer.Instance.transform;
//        Damage = damage;
//        ShockRadius = 2;
//        callType = CallType.active;
//        Name = "回身";
//        Description = "每" + Intervals + "秒对角色左右分别释放一道距离为" + Distance + "的斩击，造成" + damage + "点伤害，持续" + Duration + "秒." + "期间再次激活可以造成一次半径为" +
//            ShockRadius + "的冲击波，造成" + damage + "点伤害，并击飞敌人";
//    }

//    public override void Execute()
//    {

//    }

//    private IEnumerator<YieldInstruction> Sword()
//    {
//        float time = 0;
//        Collider[] colliders;
//        enemy_base[] enemys;
//        while (time < Duration)
//        {
//            colliders = Physics.OverlapBox(playerTransform.position, new Vector3(Distance + 1, 1, 1));
//            enemys = new enemy_base[colliders.Length];
//            for (int i = 0; i < colliders.Length; i++)
//            {
//                enemys[i] = colliders[i].GetComponent<enemy_base>();
//                enemys[i].FBeHurt(Damage);
//            }
//            yield return new WaitForSeconds(Intervals);
//        }
//    }

//    //private IEnumerator<YieldInstruction> Shock()
//    //{
//    //    float time = 0;
//    //    Player_Controller_System.Instance.
//    //}
//}