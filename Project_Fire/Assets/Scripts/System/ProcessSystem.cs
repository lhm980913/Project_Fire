using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcessSystem : UnityEngine.MonoBehaviour
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
    public void Def(Collider playeratt, enemy_shield Enemy)
    {
       
        Destroy(Instantiate(enemy_hurt3, Enemy.transform.position + Vector3.up * 0.5f+ Vector3.right* Enemy.faceto * 0.5f, Quaternion.Euler(Vector3.zero)).gameObject, 3f);
        Destroy(Instantiate(att5, Enemy.transform.position + Vector3.up * 0.5f + Vector3.right * Enemy.faceto * 0.5f, Quaternion.Euler(Vector3.zero)).gameObject, 3f);
        Destroy(Instantiate(att4, Enemy.transform.position + Vector3.up * 0.5f + Vector3.right * Enemy.faceto * 0.5f, Quaternion.Euler(Vector3.zero)).gameObject, 3f);
        Destroy(Instantiate(att3, Enemy.transform.position + Vector3.up * 0.5f + Vector3.right * Enemy.faceto * 0.5f, Quaternion.Euler(Vector3.zero)).gameObject, 3f);

      


        StartCoroutine(CameraEffectSystem.Instance.FTimeScaleControl(0.2f, 0.00001f));
    }
    public void FPlayerWeapon_Enemy(Collider playeratt, enemy_base Enemy)
    {
        if (playeratt.tag == "player_weapon"&& !Physics.Raycast(testplayer.Instance.transform.position,Enemy.transform.position-testplayer.Instance.transform.position,Vector3.Distance(Enemy.transform.position, testplayer.Instance.transform.position),1<<9))
        {
           
            AudioManager.Instance.TryPlayAudio(AudioManager.AudioType.AttackEnemy);
            Att_Stage b = (Att_Stage)testplayer.Instance.att_stage;

            StartCoroutine(CameraEffectSystem.Instance.FCameraShake(0.1f, 0.5f));
            StartCoroutine( CameraEffectSystem.Instance.FTimeScaleControl(0.1f, 0.00001f));

            if (b.jattack)
            {
                Player_Function.FJump(testplayer.Instance.gameObject, 8);
            }

            Destroy( Instantiate(enemy_hurt1, Enemy.transform.position + Vector3.up*0.5f, Quaternion.Euler(Vector3.zero)).gameObject,3f);
            Destroy( Instantiate(enemy_hurt2, Enemy.transform.position + Vector3.up * 0.5f, Quaternion.Euler(Vector3.zero)).gameObject ,3f);
            Destroy( Instantiate(enemy_hurt3, Enemy.transform.position + Vector3.up * 0.5f, Quaternion.Euler(Vector3.zero)).gameObject,3f);
            Enemy.GetComponent<Rigidbody>().velocity = Enemy.beattforce * Vector3.Normalize(new Vector3((testplayer.Instance.transform.position.x - Enemy.transform.position.x)/-Mathf.Abs( testplayer.Instance.transform.position.x - Enemy.transform.position.x), 1,0));
            if (Enemy.type=="lizarrd")
            {
                testplayer.Instance.FGetMana(testplayer.Instance.GotMana);
                enemy_lizarrd_new a = (enemy_lizarrd_new)Enemy;
                a.hurt_count -= testplayer.Instance.player_attack*testplayer.Instance.attlevel;
                a.Hp -= testplayer.Instance.player_attack * testplayer.Instance.attlevel;
                if(!a.wudi11)
                {
                    UIManager.Instance.DisplayDamageNumber((int)testplayer.Instance.player_attack * (int)testplayer.Instance.attlevel, Enemy.transform.position);
                }
 
               
                if (a.hurt_count<0&&!a.dead)
                {
                    a.enemy.SetStage(a.lizarrd_hurt_stage);
                }
                RuneManager.Instance.UseRune(RuneEvent.OnAttack);
            }
            if (Enemy.type == "fire")
            {
                testplayer.Instance.FGetMana(testplayer.Instance.GotMana);
                enemy_fire a = (enemy_fire)Enemy;
                a.hurt_count -= testplayer.Instance.player_attack * testplayer.Instance.attlevel;
                a.Hp -= testplayer.Instance.player_attack * testplayer.Instance.attlevel;
                if (!a.wudi11)
                {
                    UIManager.Instance.DisplayDamageNumber((int)testplayer.Instance.player_attack * (int)testplayer.Instance.attlevel, Enemy.transform.position);
                }
                if (a.hurt_count < 0 && !a.dead)
                {
                    a.enemy.SetStage(a.fire_hurt_stage);
                }
                RuneManager.Instance.UseRune(RuneEvent.OnAttack);
            }
            if (Enemy.type == "lancer")
            {
                testplayer.Instance.FGetMana(testplayer.Instance.GotMana);
                enemy_lancer a = (enemy_lancer)Enemy;
                a.hurt_count -= testplayer.Instance.player_attack * testplayer.Instance.attlevel;
                a.Hp -= testplayer.Instance.player_attack * testplayer.Instance.attlevel;
                if (!a.wudi11)
                {
                    UIManager.Instance.DisplayDamageNumber((int)testplayer.Instance.player_attack * (int)testplayer.Instance.attlevel, Enemy.transform.position);
                }
                if (a.hurt_count < 0 && !a.dead)
                {
                    a.enemy.SetStage(a.lancer_hurt_stage);
                }
                RuneManager.Instance.UseRune(RuneEvent.OnAttack);
            }
            if (Enemy.type == "boss")
            {
                testplayer.Instance.FGetMana(testplayer.Instance.GotMana);
                enemy_boss a = (enemy_boss)Enemy;
                a.hurt_count -= testplayer.Instance.player_attack * testplayer.Instance.attlevel;
                a.Hp -= testplayer.Instance.player_attack * testplayer.Instance.attlevel;
                if (!a.wudi11)
                {
                    UIManager.Instance.DisplayDamageNumber((int)testplayer.Instance.player_attack * (int)testplayer.Instance.attlevel, Enemy.transform.position);
                }
                if (a.hurt_count < 0 && !a.dead)
                {
                    a.enemy.SetStage(a.boss_hurt_stage);
                }
                RuneManager.Instance.UseRune(RuneEvent.OnAttack);
            }
            if (Enemy.type == "shield")
            {
                testplayer.Instance.FGetMana(testplayer.Instance.GotMana);
                enemy_shield a = (enemy_shield)Enemy;
                if (testplayer.Instance.attlevel == testplayer.Instance.Exatt && (a.transform.position.x - testplayer.Instance.transform.position.x) *a.faceto < 0)
                {
                    if(!a.dead)
                    a.enemy.SetStage(a.shield_hurt_stage);
                }
                else
                {
                    a.hurt_count -= testplayer.Instance.player_attack * testplayer.Instance.attlevel;
                    a.Hp -= testplayer.Instance.player_attack * testplayer.Instance.attlevel;
                    if (!a.wudi11)
                    {
                        UIManager.Instance.DisplayDamageNumber((int)testplayer.Instance.player_attack * (int)testplayer.Instance.attlevel, Enemy.transform.position);
                    }
                    RuneManager.Instance.UseRune(RuneEvent.OnAttack);
                }

                
               
            }
            if (Enemy.type == "assassin")
            {
                testplayer.Instance.FGetMana(testplayer.Instance.GotMana);
                enemy_assassin a = (enemy_assassin)Enemy;
                a.hurt_count -= testplayer.Instance.player_attack * testplayer.Instance.attlevel;
                a.Hp -= testplayer.Instance.player_attack * testplayer.Instance.attlevel;
                if (!a.wudi11)
                {
                    UIManager.Instance.DisplayDamageNumber((int)testplayer.Instance.player_attack * (int)testplayer.Instance.attlevel, Enemy.transform.position);
                }
                if (a.hurt_count < 0 && !a.dead)
                {
                    a.enemy.SetStage(a.assassin_hurt_stage);
                }
                RuneManager.Instance.UseRune(RuneEvent.OnAttack);
            }
            if (Enemy.type == "bird")
            {
                testplayer.Instance.FGetMana(testplayer.Instance.GotMana);
                enemy_bird a = (enemy_bird)Enemy;
                a.hurt_count -= testplayer.Instance.player_attack * testplayer.Instance.attlevel;
                a.Hp -= testplayer.Instance.player_attack * testplayer.Instance.attlevel;
                if (!a.wudi11)
                {
                    UIManager.Instance.DisplayDamageNumber((int)testplayer.Instance.player_attack * (int)testplayer.Instance.attlevel, Enemy.transform.position);
                }
                if (a.hurt_count < 0&&!a.dead)
                {
                    a.enemy.SetStage(a.bird_hurt_stage);
                }
                RuneManager.Instance.UseRune(RuneEvent.OnAttack);

            }
            if (Enemy.type == "bullet")
            {
                bullet a = (bullet)Enemy;
               
                a.Hp -= testplayer.Instance.player_attack;
                RuneManager.Instance.UseRune(RuneEvent.OnAttackFlyItem);
            }
            if (Enemy.type == "paodan")
            {
                paodan a = (paodan)Enemy;

                a.Hp -= testplayer.Instance.player_attack;
                RuneManager.Instance.UseRune(RuneEvent.OnAttackFlyItem);
            }
            StartCoroutine(CameraEffectSystem.Instance.FTimeScaleControl());
            StartCoroutine(CameraEffectSystem.Instance.FCameraShake());
            
        }
    }

    public void FPlayerSkill_Enemy(enemy_base enemy,float xishu)
    {
        
        if(!enemy.wudi11)
        {
        if (enemy.type == "lizarrd")
        {
            enemy_lizarrd_new a = (enemy_lizarrd_new)enemy;
            a.hurt_count -= testplayer.Instance.player_attack * xishu;
            a.Hp -= testplayer.Instance.player_attack* xishu;
            UIManager.Instance.DisplayDamageNumber((int)(testplayer.Instance.player_attack * testplayer.Instance.attlevel * xishu), enemy.transform.position);
            if (a.hurt_count < 0)
            {
                a.enemy.SetStage(a.lizarrd_hurt_stage);
            }
        }
            if (enemy.type == "fire")
            {
                enemy_fire a = (enemy_fire)enemy;
                a.hurt_count -= testplayer.Instance.player_attack * xishu;
                a.Hp -= testplayer.Instance.player_attack * xishu;
                UIManager.Instance.DisplayDamageNumber((int)(testplayer.Instance.player_attack * testplayer.Instance.attlevel * xishu), enemy.transform.position);
                if (a.hurt_count < 0)
                {
                    a.enemy.SetStage(a.fire_hurt_stage);
                }
            }
            if (enemy.type == "bird")
        {
            enemy_bird a = (enemy_bird)enemy;
            a.hurt_count -= testplayer.Instance.player_attack * xishu;
            a.Hp -= testplayer.Instance.player_attack * xishu;
            UIManager.Instance.DisplayDamageNumber((int)(testplayer.Instance.player_attack * testplayer.Instance.attlevel * xishu), enemy.transform.position);
            if (a.hurt_count < 0)
            {
                a.enemy.SetStage(a.bird_hurt_stage);
            }
        }
        if (enemy.type == "assassin")
        {
            enemy_assassin a = (enemy_assassin)enemy;
            a.hurt_count -= testplayer.Instance.player_attack * xishu;
            a.Hp -= testplayer.Instance.player_attack * xishu;
            UIManager.Instance.DisplayDamageNumber((int)(testplayer.Instance.player_attack * testplayer.Instance.attlevel * xishu), enemy.transform.position);
            if (a.hurt_count < 0)
            {
                a.enemy.SetStage(a.assassin_hurt_stage);
            }
        }
        if (enemy.type == "lancer")
        {
            enemy_lancer a = (enemy_lancer)enemy;
            a.hurt_count -= testplayer.Instance.player_attack * xishu;
            a.Hp -= testplayer.Instance.player_attack * xishu;
            UIManager.Instance.DisplayDamageNumber((int)(testplayer.Instance.player_attack * testplayer.Instance.attlevel * xishu), enemy.transform.position);
            if (a.hurt_count < 0)
            {
                a.enemy.SetStage(a.lancer_hurt_stage);
            }
        }
            if (enemy.type == "boss")
            {
                enemy_boss a = (enemy_boss)enemy;
                a.hurt_count -= testplayer.Instance.player_attack * xishu;
                a.Hp -= testplayer.Instance.player_attack * xishu;
                UIManager.Instance.DisplayDamageNumber((int)(testplayer.Instance.player_attack * testplayer.Instance.attlevel * xishu), enemy.transform.position);
                if (a.hurt_count < 0)
                {
                    a.enemy.SetStage(a.boss_hurt_stage);
                }
            }
            if (enemy.type == "shield")
        {
            enemy_shield a = (enemy_shield)enemy;
            a.hurt_count -= testplayer.Instance.player_attack * xishu;
            a.Hp -= testplayer.Instance.player_attack * xishu;
            UIManager.Instance.DisplayDamageNumber((int)(testplayer.Instance.player_attack * testplayer.Instance.attlevel * xishu), enemy.transform.position);
            if (a.hurt_count < 0)
            {
                a.enemy.SetStage(a.shield_hurt_stage);
            }
        }
        StartCoroutine(CameraEffectSystem.Instance.FTimeScaleControl());
        StartCoroutine(CameraEffectSystem.Instance.FCameraShake());
        }
    }

    public void FPlayerWeapon_EnemyWeapon(playerweapon PlayerWeapon)
    {
       
    }
    public void FPlayer_EnemyWeapon(testplayer Player)
    {

    }
    public void Fenemy_re(enemy_base enemy)
    {
        Destroy(Instantiate(att3, testplayer.Instance.transform.position + pianyi*(Vector3.up + testplayer.Instance.face_to * Vector3.right), Quaternion.Euler(Vector3.zero)).gameObject, 3f);
        Destroy(Instantiate(att4, testplayer.Instance.transform.position + pianyi * (Vector3.up + testplayer.Instance.face_to * Vector3.right), Quaternion.Euler(Vector3.zero)).gameObject, 3f);
        Destroy(Instantiate(att5, testplayer.Instance.transform.position + pianyi * (Vector3.up + testplayer.Instance.face_to * Vector3.right), Quaternion.Euler(Vector3.zero)).gameObject, 3f);

        if (enemy.type == "lizarrd")
        {
            enemy_lizarrd_new a = (enemy_lizarrd_new)enemy;
            a.anim.CrossFade("lizarrd_stand1", 0.2f);

        }
        if (enemy.type == "lancer")
        {
            enemy_lancer a = (enemy_lancer)enemy;
            a.enemy.SetStage(a.lancer_stand_stage);

        }
        if (enemy.type == "boss")
        {
            enemy_boss a = (enemy_boss)enemy;
            a.yingzhi = 1.2f;
            a.enemy.SetStage(a.boss_stand_stage);

        }
        //if (enemy.GetComponent<enemy_fire>())
        //{
        //    enemy.GetComponentInParent<Animator>().CrossFade("stand", 0.1f);
        //}
        //if (enemy.GetComponent<enemy_lancer>())
        //{
        //    enemy.GetComponentInParent<Animator>().CrossFade("stand", 0.1f);
        //}
    }
}
