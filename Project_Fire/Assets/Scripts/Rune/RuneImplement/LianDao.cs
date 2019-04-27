using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LianDao : Rune
{
    GameObject Sickle;
    testplayer player;
    public LianDao(RuneEntity runeEntity) : base(runeEntity)
    {
        rune_Event = RuneEvent.ActiveOne;
        this.name = "LianDao";
        RuneName = "飓风之镰";
        rune_Type = RuneType.active;
        this.runeEntity = runeEntity;
        player = testplayer.Instance;
        Sickle = (GameObject)Resources.Load("Prefab/Sickle");
    }
    public override void Execute()
    {
        GameObject temp;
        temp = UnityEngine.Object.Instantiate(Sickle, player.transform.position, Quaternion.identity);
        temp.GetComponent<LianDaoEntity>().dir = testplayer.Instance.face_to * new Vector3(1, 0, 0);
    }
}
