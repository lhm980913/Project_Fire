using System;
using System.Collections.Generic;
using UnityEngine;

public enum RuneType
{
    passive,
    active
}

public abstract class Rune
{
    protected RuneEvent rune_Event;
    public RuneEvent runeEvent
    {
        get
        {
            return rune_Event;
        }
    }
    public RuneEntity runeEntity;
    protected RuneType rune_Type;
    public RuneType runeType
    {
        get
        {
            return rune_Type;
        }
    }
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
    public void SetActiveEvent(int index)
    {
        if (rune_Event != RuneEvent.ActiveOne || rune_Event != RuneEvent.ActiveTwo)
        {
            return;
        }
        else
        {
            rune_Event = (RuneEvent)index;
        }
    }
}

public class testRune : Rune
{
    public testRune(RuneEntity runeEntity):base(runeEntity)
    {
        rune_Event = RuneEvent.OnAttack;
        this.name = "Test";
        rune_Type = RuneType.passive;
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
        rune_Event = RuneEvent.ActiveOne;
        this.name = "XianDan";
        rune_Type = RuneType.active;
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
    int Damage;
    testplayer player;
    public YinXian(RuneEntity runeEntity) : base(runeEntity)
    {
        rune_Event = RuneEvent.ActiveOne;
        this.name = "YinXian";
        rune_Type = RuneType.active;
        this.runeEntity = runeEntity;
        Damage = 4;
        player = testplayer.Instance;
    }

    public override void Execute()
    {
        Collider[] colliders;
        colliders = Physics.OverlapBox(player.transform.position, new Vector3(100, 1, 1), Quaternion.identity, 1 << 11);
        enemy_base[] enemys = new enemy_base[colliders.Length];
        for (int i = 0; i < colliders.Length; i++)
        {
            enemys[i] = colliders[i].GetComponent<enemy_base>();
            ProcessSystem.Instance.FPlayerSkill_Enemy(enemys[i]);
        }
        RuneManager.Instance.StartCoroutine(buffer(enemys));
    }

    public IEnumerator<YieldInstruction> buffer(enemy_base[] enemys)
    {
        for(int i = 0; i < 3; i++)
        {
            foreach (var enemy in enemys)
            {
                enemy.FBeHurt(Damage);
            }
            yield return new WaitForSeconds(0.25f);
        }
        
    }
}

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