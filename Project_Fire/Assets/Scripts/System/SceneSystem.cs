using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SceneSystem : MonoBehaviour
{
    static public SceneSystem instance;
    public GameObject[] Gates;
    public enemy_boss boss;
    public CinemachineVirtualCamera main;

    [SerializeField]
    private float GateCD;
    [SerializeField]
    private Transform TargetPosition;
    [HideInInspector]
    public float GateCoolDownTime;
    
    List<enemy_base> enemys;

    Vector3 LastSaveposition;
    SavePoint LastSavePoint;

    private void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
        enemys = new List<enemy_base>();
    }

    private void Update()
    {
        if(GateCoolDownTime <= 0)
        {
            GateCoolDownTime = 0;
        }
        else
        {
            GateCoolDownTime -= Time.deltaTime;
        }
    }

    public void UseGate()
    {
        GateCoolDownTime = GateCD;
    }

    public void AddEnemy(enemy_base enemy)
    {
        enemys.Add(enemy);
    } 

    public void Delete(enemy_base enemy)
    {
        enemys.Remove(enemy);
    }

    public void Reborn()
    {
        boss.anim.CrossFade("boss_stand 1", 0.1f);
        testplayer.Instance.transform.position = LastSaveposition;
        testplayer.Instance.FixHpAndMp();

        MainPanel.Instance.UpdateHp();
        MainPanel.Instance.UpdateMp();
        if (!main.enabled)
        {
            main.enabled = true;
        }
        if (boss.fighting)
        {
            boss.fighting = false;  
        }
    }

    public void FixEnemy()
    {
        foreach (var enemy in enemys)
        {
            enemy.Hp = enemy.maxhp;
            enemy.transform.position = enemy.begin_pos;
        }
    }

    public void UpdateSavePoint(Vector3 position, SavePoint point)
    {
        if (LastSavePoint)
        {
            LastSavePoint.Fire.color = Color.white;
        }
        LastSaveposition = position;
        LastSavePoint = point;
    }

    public void OpenGate()
    {
        //testplayer.Instance.transform.position = TargetPosition.position;
        foreach(var Gate in Gates)
        {
            if (!Gate)
            {
                Debug.LogWarning("SceneSystemDon'tHaveGate");
            }
            else
            {
                Gate.SetActive(true);
            }
        }
    }
}
