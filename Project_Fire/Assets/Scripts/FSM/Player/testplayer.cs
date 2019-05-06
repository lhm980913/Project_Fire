﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class testplayer : UnityEngine.MonoBehaviour
{
    static public testplayer Instance;

    public float speed;
    public float jump_speed;
    public float doublejump_speed;
    public float little_jump_speed;
    public float maxflashspeed;

    public float rapelength;   
    public float rapespeed;
    public float ymaxspeed;
    public float player_att_speed;
    public float canthurtcount;
    public float hurtforce;
    public GameObject playerwapon;

    [HideInInspector]
    public SkinnedMeshRenderer[] skins;


    public float player_attack;
    public float tanfan_time;

    public float Hpmax;
    public float Manamax;
    public float _hp;
    public float _mana;

    public float hp
    {
        set
        {
            this._hp = Mathf.Clamp(value, 0, Hpmax);
        }
        get
        {
            return this._hp;
        }
    }
    private float mana
    {
        set
        {
            this._mana = Mathf.Clamp(value, 0, Hpmax);
        }
        get
        {
            return this._mana;
        }
    }


    [HideInInspector]
    public Vector3 enemypos;
    [HideInInspector]
    public float flashtime;

    [HideInInspector]
    public GameObject playergameobj;
    [HideInInspector]
    public bool canatt = true;
    [HideInInspector]
    public bool grounded;
    [HideInInspector]
    public float flashcd;
    [HideInInspector]
    public int face_to = 1;
    [HideInInspector]
    public bool canflash = true;
    [HideInInspector]
    public Vector3 target_pos;
    [HideInInspector]
    public bool canrape;
    [HideInInspector]
    public float aa;
 
    [HideInInspector]
    public float aaex;
    [HideInInspector]
    public bool canhurt = true;
    [HideInInspector]
    public bool atting = false;
    [HideInInspector]
    public Vector3 velocity;
    [HideInInspector]
    public Vector3 physic_velocity;
    // Start is called before the first frame update
    public bool doublejump = true;
    [HideInInspector]

    static public Player _player;
    public AnimationCurve ac;
    public Animator anim;
    public GameObject moudle_player;
    public bool canjump;

   // 

    public Player_Base_Stage stand_stage;
    public Player_Base_Stage run_stage;
    public Player_Base_Stage jump_stage;
    public Player_Base_Stage flash_stage;
    public Player_Base_Stage rape_stage;
    public Player_Base_Stage att_stage;
    public Player_Base_Stage hurt_stage;
    public Player_Base_Stage doublejump_stage;
    public Player_Base_Stage attex_stage;
    public Player_Base_Stage tanfan_stage;
    private void Awake()
    {
        UIManager.Instance.PushPanel(UIBaseType.MainPanel);
        _player = new Player();

        stand_stage = new Stand_Stage();
        run_stage = new Run_Stage();
        jump_stage = new Jump_Stage();
        flash_stage = new Flash_Stage();
        rape_stage = new Rape_Stage();
        att_stage = new Att_Stage();
        hurt_stage = new Hurt_Stage();
        doublejump_stage = new DoubleJump_Stage();
        attex_stage = new AttEx_Stage();
        tanfan_stage = new Tanfan_stage();
        if (Instance==null)
        {
            Instance = this;

        }
        playergameobj = this.gameObject;
        aa = player_att_speed;
        canhurt = true;

        skins = GetComponentsInChildren<SkinnedMeshRenderer>();
    }

    void Start()
    {
       


    }

    // Update is called once per frame
    void Update()
    {
        attcount();
        FFilp();

        FCountFlash();
        FAnimation();
        

        if(grounded!=FCheckground())
        {
            grounded = FCheckground();
           
        }
        
        if(grounded)
        {
            doublejump = true;
        }

        FYspeedclamp();

        _player.Update();

        if (Input.GetKeyDown(KeyCode.I)||Player_Controller_System.Instance.Right_Down== Player_Controller_System.Button_Stage.down)
        {
            FActiveRuneOne();
        }
    }
    bool FCheckground()
    {
        LayerMask lm = 1 << 9;
        //Collider[] a = Physics.OverlapSphere(playergameobj.transform.position - new Vector3(0,0.5f,0), 0.02f,lm);
        bool a;// = Physics.Raycast(transform.position, transform.forward, 1f, 1 << 9);
        //a = Physics.BoxCast(transform.position, Vector3.one, -transform.up, Quaternion.identity, 0.2f, 1 << 9);
        a = Physics.Raycast(transform.position-Vector3.left*0.2f, -transform.up, 0.8f, lm);
        bool b = Physics.Raycast(transform.position + Vector3.left * 0.2f, -transform.up, 0.8f, lm);
        //Gizmos.DrawCube(transform.position , Vector3.one);
        return a||b;
        //if (a.Length == 0)
        //{
        //    return false;
        //}
        //else return true;
    }
    void FCountFlash()
    {

        flashcd -= Time.deltaTime;
    }
    void FFilp()
    {
        moudle_player.transform.rotation = Quaternion.Euler(0, face_to * 120, 0);

        //slide_dust.shape.position = new Vector3(0.5f*face_to, 0.5f, 0.3f);
        // slide_dust.shape.position.Set(0.5f * face_to, -0.5f, 0.3f);
        
        playerwapon.transform.localRotation = Quaternion.Euler(0, -face_to*30, 0);

    }
    void FYspeedclamp()
    {
        if(playergameobj.GetComponent<Rigidbody>().velocity.y<ymaxspeed)
        {
            playergameobj.GetComponent<Rigidbody>().velocity = new Vector3(playergameobj.GetComponent<Rigidbody>().velocity.x, ymaxspeed, 0);
        }
    }
    void FAnimation()
    {
       // anim.SetBool("atting", atting);
        anim.SetFloat("jumpSpeed", playergameobj.GetComponent<Rigidbody>().velocity.y);
        if (Mathf.Abs(playergameobj.GetComponent<Rigidbody>().velocity.x) > 0.001)
        {
            anim.SetBool("OnRunning", true);
        }
        else
        {
            anim.SetBool("OnRunning", false);
        }
        anim.SetBool("ground", grounded);
    }
    void attcount()
    {

        
        if(!canatt)
        {

            aa -= Time.deltaTime;
          //  aaex -= Time.deltaTime;
            if (aa<0)
            {
                canatt = true;
            }


        }
    }

    private void FActiveRuneOne()
    {
        RuneManager.Instance.UseRune(RuneEvent.ActiveOne);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "enemy_weapon" && atting)
        {
            ProcessSystem.Instance.Fenemy_re(other.gameObject);
           
            StartCoroutine(CameraEffectSystem.Instance.FTimeScaleControl(0.2f, 0.00001000f));
            StartCoroutine(wudi(0.2f));
            //StartCoroutine(CameraEffectSystem.Instance.FCameraShake(0.05f,0.2f));
            //anim.CrossFade("att_pindao",0);
            _player.SetStage(tanfan_stage);

           
         
            
        }
        if ((other.tag =="enemy_att"&&canhurt))
        {
  
            enemypos = other.transform.position;
            atting = false;
            _player.SetStage(hurt_stage);
        }
        if ((other.tag == "enemy" && canhurt))
        {

            enemy_base b = other.gameObject.GetComponent<enemy_base>();
            bool c = b;
            if(c)
            {
                if (b.type == "lizarrd")
                {
                    enemy_lizarrd_new a = (enemy_lizarrd_new)b;
                    if (a.candamage)
                    {
                        enemypos = other.transform.position;
                        atting = false;
                        _player.SetStage(hurt_stage);
                    }

                }
                if (b.type == "bird")
                {
                    enemy_bird a = (enemy_bird)b;
                    if (a.candamage)
                    {
                        enemypos = other.transform.position;
                        atting = false;
                        _player.SetStage(hurt_stage);
                    }

                }
            }
            else
            {
                enemypos = other.transform.position;
                atting = false;
                _player.SetStage(hurt_stage);
            }
        
        }


    }

    public void FGetMana(float num)
    {
        mana += num;
    }

    public void FSubMana(float num)
    {
        mana -= num;
    }

   public IEnumerator wudi(float time)
    {
        canhurt = false;
        yield return new WaitForSeconds(time);
        canhurt = true;
    }

    public void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position + Vector3.right * face_to * 2.0f * 0.6f, new Vector3(2.0f, 1.0f, 1.0f));
    }
}
