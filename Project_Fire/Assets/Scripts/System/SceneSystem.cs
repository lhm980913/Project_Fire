using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSystem : MonoBehaviour
{
    static public SceneSystem instance;
    public GameObject Gate;

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
        testplayer.Instance.transform.position = LastSaveposition;
        testplayer.Instance.FixHpAndMp();
    }

    public void FixEnemy()
    {
        foreach (var enemy in enemys)
        {
            enemy.Hp = enemy.maxhp;
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
        testplayer.Instance.transform.position = TargetPosition.position;
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
