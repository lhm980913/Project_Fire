using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcessSystem : MonoBehaviour
{
    static public ProcessSystem Instance;
    //public Collider player_att = null;
    //public Collider player_body = null;
    //public Collider enemy_att = null;
    //public Collider enemy_body = null;


    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }


    }
    private void Start()
    {
        
    }


    private void Update()
    {
        



    }

    public void FPlayerWeapon_Enemy(WeaponSystem PlayerWeapon ,Collider playeratt, enemy_base Enemy)
    {
       if(playeratt.tag=="player_weapon")
        {
            if (Enemy.Stage != Enemy_Stage.att)
            {
                Enemy.Stage = Enemy_Stage.hurt;
            }
            else
            {
                Enemy.FFaceToPlayer();
                Enemy.FBeHurt(Enemy.beattforce);
            }
            if(Enemy.atting)
            StartCoroutine(CameraEffectSystem.Instance.FTimeScaleControl());

        }


    }
    public void FPlayerWeapon_EnemyWeapon(playerweapon PlayerWeapon)
    {
       
    }
    public void FPlayer_EnemyWeapon(testplayer Player)
    {

    }
}
