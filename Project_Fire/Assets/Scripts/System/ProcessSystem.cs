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

    public void FPlayerWeapon_Enemy(Collider playeratt, enemy_base Enemy)
    {
        if (playeratt.tag == "player_weapon")
        {
            if(Enemy.type=="lizarrd")
            {
                enemy_lizarrd_new a = (enemy_lizarrd_new)Enemy;
                a.hurt_count -= testplayer.Instance.player_attack;
                a.Hp -= testplayer.Instance.player_attack;
                if (a.hurt_count<0)
                {
                    a.enemy.SetStage(a.lizarrd_hurt_stage);
                }
                
            }
            if (Enemy.type == "bird")
            {
                enemy_bird a = (enemy_bird)Enemy;
                a.hurt_count -= testplayer.Instance.player_attack;
                a.Hp -= testplayer.Instance.player_attack;
                if (a.hurt_count < 0)
                {
                    a.enemy.SetStage(a.bird_hurt_stage);
                }
               
            }
            StartCoroutine(CameraEffectSystem.Instance.FTimeScaleControl());
            StartCoroutine(CameraEffectSystem.Instance.FCameraShake());
            RuneManager.Instance.UseRune(RuneEvent.OnAttack);
        }


    }
    public void FPlayerWeapon_EnemyWeapon(playerweapon PlayerWeapon)
    {
       
    }
    public void FPlayer_EnemyWeapon(testplayer Player)
    {

    }
    public void Fenemy_re(GameObject enemy)
    {
        if(enemy.GetComponent<enemy_lizarrd_new>())
        {
            enemy.GetComponentInParent<Animator>().CrossFade("lizarrd_stand1", 0.1f);
        }
        
    }
}
