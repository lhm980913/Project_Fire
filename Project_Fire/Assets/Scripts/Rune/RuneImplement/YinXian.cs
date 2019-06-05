using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//OK
public class YinXian : Rune
{
    int Damage;
    testplayer player;
    GameObject Xian;
    public YinXian(RuneEntity runeEntity) : base(runeEntity)
    {
        rune_Event = RuneEvent.ActiveOne;
        RuneName = "银线";
        name = "YinXian";
        rune_Type = RuneType.active;
        this.runeEntity = runeEntity;
        MpNeed = 10;
        Damage = 4;
        player = testplayer.Instance;
        Xian = (GameObject)Resources.Load("Prefab/yinxian");
    }

    public override void Execute()
    {
        GameObject xian =  Object.Instantiate(Xian, player.transform.position, Quaternion.Euler(0,0,-90));
        Collider[] colliders;
        if (!player)
        {
            player = testplayer.Instance;
        }
        colliders = Physics.OverlapBox(player.transform.position, new Vector3(Xian.transform.localScale.y, 1, 1), Quaternion.identity, 1 << 11);
        List<enemy_base> enemys = new List<enemy_base>();
        for (int i = 0; i < colliders.Length; i++)
        {
            enemy_base temp = colliders[i].GetComponent<enemy_base>();
            if(!temp)
            {
                continue;
            }
            else
            {
                enemys.Add(temp);
                ProcessSystem.Instance.FPlayerSkill_Enemy(temp);
            }
        }
        RuneManager.Instance.StartCoroutine(buffer(enemys,xian));
    }

    public IEnumerator<YieldInstruction> buffer(List<enemy_base> enemys,GameObject xian)
    {
        if(enemys.Count < 1)
        {
            yield return null;
        }
        for (int i = 0; i < 3; i++)
        {
            foreach (var enemy in enemys)
            {
                ProcessSystem.Instance.FPlayerSkill_Enemy(enemy);
            }
            yield return new WaitForSeconds(0.25f);
        }
        player.DestroyGameObject(xian);
    }
}
