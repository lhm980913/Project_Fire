using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcessSystem : MonoBehaviour
{
    static public ProcessSystem Instance;
    public float pianyi;
    //public Collider player_att = null;
    //public Collider player_body = null;
    //public Collider enemy_att = null;
    //public Collider enemy_body = null;
    public ParticleSystem enemy_hurt1;
    public ParticleSystem enemy_hurt2;
    public ParticleSystem enemy_hurt3;
    public ParticleSystem att3;
    public ParticleSystem att4; 
    public ParticleSystem att5;
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
            Att_Stage b = (Att_Stage)testplayer.Instance.att_stage;
            if (b.jattack)
            {
                Player_Function.FJump(testplayer.Instance.gameObject, 11);
            }

            Destroy( Instantiate(enemy_hurt1, Enemy.transform.position + Vector3.up, Quaternion.Euler(Vector3.zero)).gameObject,3f);
            Destroy( Instantiate(enemy_hurt2, Enemy.transform.position + Vector3.up, Quaternion.Euler(Vector3.zero)).gameObject ,3f);
            Destroy( Instantiate(enemy_hurt3, Enemy.transform.position + Vector3.up, Quaternion.Euler(Vector3.zero)).gameObject,3f);
            //Instantiate(enemy_hurt2, Enemy.transform.position + Vector3.up, Quaternion.Euler(Vector3.zero));
            //Instantiate(enemy_hurt3, Enemy.transform.position + Vector3.up, Quaternion.Euler(Vector3.zero));
            //Instantiate(att3, Enemy.transform.position, Quaternion.Euler(Vector3.zero));
            //Instantiate(att4, Enemy.transform.position, Quaternion.Euler(Vector3.zero));
            
            if (Enemy.type=="lizarrd")
            {
                enemy_lizarrd_new a = (enemy_lizarrd_new)Enemy;
                a.hurt_count -= testplayer.Instance.player_attack;
                a.Hp -= testplayer.Instance.player_attack;
                if (a.hurt_count<0&&!a.dead)
                {
                    a.enemy.SetStage(a.lizarrd_hurt_stage);
                }
                
            }
            if (Enemy.type == "bird")
            {
                enemy_bird a = (enemy_bird)Enemy;
                a.hurt_count -= testplayer.Instance.player_attack;
                a.Hp -= testplayer.Instance.player_attack;
                if (a.hurt_count < 0&&!a.dead)
                {
                    a.enemy.SetStage(a.bird_hurt_stage);
                }
               
            }
            StartCoroutine(CameraEffectSystem.Instance.FTimeScaleControl());
            StartCoroutine(CameraEffectSystem.Instance.FCameraShake());
            RuneManager.Instance.UseRune(RuneEvent.OnAttack);
        }
    }

    public void FPlayerSkill_Enemy(enemy_base enemy)
    {
        Debug.Log(enemy.name);
        if (enemy.type == "lizarrd")
        {
            enemy_lizarrd_new a = (enemy_lizarrd_new)enemy;
            a.hurt_count -= testplayer.Instance.player_attack;
            a.Hp -= testplayer.Instance.player_attack;
            if (a.hurt_count < 0)
            {
                a.enemy.SetStage(a.lizarrd_hurt_stage);
            }

        }
        if (enemy.type == "bird")
        {
            enemy_bird a = (enemy_bird)enemy;
            a.hurt_count -= testplayer.Instance.player_attack;
            a.Hp -= testplayer.Instance.player_attack;
            if (a.hurt_count < 0)
            {
                a.enemy.SetStage(a.bird_hurt_stage);
            }

        }
        StartCoroutine(CameraEffectSystem.Instance.FTimeScaleControl());
        StartCoroutine(CameraEffectSystem.Instance.FCameraShake());
    }

    public void FPlayerWeapon_EnemyWeapon(playerweapon PlayerWeapon)
    {
       
    }
    public void FPlayer_EnemyWeapon(testplayer Player)
    {

    }
    public void Fenemy_re(GameObject enemy)
    {


        Destroy(Instantiate(att3, testplayer.Instance.transform.position + pianyi*(Vector3.up + testplayer.Instance.face_to * Vector3.right), Quaternion.Euler(Vector3.zero)).gameObject, 3f);
        Destroy(Instantiate(att4, testplayer.Instance.transform.position + pianyi * (Vector3.up + testplayer.Instance.face_to * Vector3.right), Quaternion.Euler(Vector3.zero)).gameObject, 3f);
        Destroy(Instantiate(att5, testplayer.Instance.transform.position + pianyi * (Vector3.up + testplayer.Instance.face_to * Vector3.right), Quaternion.Euler(Vector3.zero)).gameObject, 3f);

        if (enemy.GetComponent<enemy_lizarrd_new>())
        {
            enemy.GetComponentInParent<Animator>().CrossFade("lizarrd_stand1", 0.1f);
        }
        
    }
}
