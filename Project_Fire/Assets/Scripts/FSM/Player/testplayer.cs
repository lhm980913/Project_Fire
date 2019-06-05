using System.Collections;
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
    [SerializeField]
    private float gotMana;

    [HideInInspector]
    public SkinnedMeshRenderer[] skins;
    public GameObject heal;

    public float player_attack;
    public float tanfan_time;

    public float Hpmax;
    public float Manamax;
    private float _hp;
    private float _mana;

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
    public float mana
    {
        set
        {
            this._mana = Mathf.Clamp(value, 0, Manamax);
        }
        get
        {
            return this._mana;
        }
    }

    public float GotMana
    {
        get
        {
            return gotMana;
        }
    }


    [HideInInspector]
    public Vector3 enemypos;
    [HideInInspector]
    public float flashtime;
    [HideInInspector]
    public int skillid=0;
    [HideInInspector]
    public GameObject playergameobj;
    [HideInInspector]
    public bool canatt = true;
    [HideInInspector]
    public bool grounded;
    [HideInInspector]
    public float flashcd;
    [HideInInspector]
    public int attanim = 1;
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
    [HideInInspector]
    public float attlevel = 1;
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
    public Player_Base_Stage initiative_stage;
    public Player_Base_Stage interaction_stage;
    private void Awake()
    {
        UIManager.Instance.PushPanel(UIBaseType.MainPanel);
        _player = new Player();
        initiative_stage = new Initiative_Stage();
        interaction_stage = new Interaction_Stage();
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
        hp = Hpmax;
        mana = Manamax;
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

        if (Input.GetKeyDown(KeyCode.I)|| Player_Controller_System.Instance.LTDown)
        {
            
            skillid = 1;
        }
        if (Input.GetKeyDown(KeyCode.L) || Player_Controller_System.Instance.RTDown)
        {
            
            skillid = 2;
        }
        
    }
    private void FixedUpdate()
    {
        
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

    public void FActiveRuneOne()
    {
        RuneManager.Instance.UseRune(RuneEvent.ActiveOne);
    }

    public void FActiveRuneTwo()
    {
        RuneManager.Instance.UseRune(RuneEvent.ActiveTwo);
    }
    private void OnTriggerStay(Collider other)
    {


        if ((other.tag == "enemy" && canhurt))
        {

            enemy_base b = other.gameObject.GetComponent<enemy_base>();
            bool c = b;
            if (c)
            {
                hurtforce = 5;
                if (b.type == "lizarrd")
                {
                    enemy_lizarrd_new a = (enemy_lizarrd_new)b;
                    if (a.candamage)
                    {
                        CameraEffectSystem.Instance.FHitEffect();
                        enemypos = other.transform.position;
                        atting = false;
                        FLoseHp(a.ATK);
                        _player.SetStage(hurt_stage);
                    }

                }
                if (b.type == "shield")
                {
                    enemy_shield a = (enemy_shield)b;
                    if (a.candamage)
                    {
                        CameraEffectSystem.Instance.FHitEffect();
                        enemypos = other.transform.position;
                        atting = false;
                        _player.SetStage(hurt_stage);
                        FLoseHp(a.ATK);
                    }

                }
                if (b.type == "assassin")
                {
                    enemy_assassin a = (enemy_assassin)b;
                    if (a.candamage)
                    {
                        CameraEffectSystem.Instance.FHitEffect();
                        enemypos = other.transform.position;
                        atting = false;
                        FLoseHp(a.ATK);
                        _player.SetStage(hurt_stage);
                    }

                }
                if (b.type == "bird")
                {

                    enemy_bird a = (enemy_bird)b;
                    if (a.candamage)
                    {
                        CameraEffectSystem.Instance.FHitEffect();
                        enemypos = other.transform.position;
                        atting = false;
                        FLoseHp(a.ATK);
                        _player.SetStage(hurt_stage);
                    }

                }
                if (b.type == "lancer")
                {
                    enemy_lancer a = (enemy_lancer)b;
                    if (a.candamage)
                    {
                        CameraEffectSystem.Instance.FHitEffect();
                        enemypos = other.transform.position;
                        atting = false;
                        FLoseHp(a.ATK);
                        _player.SetStage(hurt_stage);
                    }

                }
                if (b.type == "fire")
                {

                    enemy_fire a = (enemy_fire)b;
                    if (a.candamage)
                    {
                        CameraEffectSystem.Instance.FHitEffect();
                        enemypos = other.transform.position;
                        atting = false;
                        FLoseHp(a.ATK);
                        _player.SetStage(hurt_stage);
                    }

                }
                if (b.type == "bullet")
                {
                    bullet a = (bullet)b;
                    if (a.candamage)
                    {
                        CameraEffectSystem.Instance.FHitEffect();
                        enemypos = other.transform.position;
                        atting = false;
                        FLoseHp(a.ATK);
                        _player.SetStage(hurt_stage);
                    }

                }
                if (b.type == "lance")
                {
                    lancetest a = (lancetest)b;
                    if (a.candamage)
                    {
                        CameraEffectSystem.Instance.FHitEffect();
                        enemypos = other.transform.position;
                        atting = false;
                        _player.SetStage(hurt_stage);
                        FLoseHp(a.ATK);

                    }

                }
            }
            else
            {
                CameraEffectSystem.Instance.FHitEffect();
                enemypos = other.transform.position;
                atting = false;
                hurtforce = 0;
                _player.SetStage(hurt_stage);
                FLoseHp(20);

            }

        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "enemy_weapon" && atting&&grounded && (transform.position.x - other.GetComponentInParent<enemy_base>().transform.position.x) * face_to < 0)
        {
            ProcessSystem.Instance.Fenemy_re(other.GetComponentInParent<enemy_base>());
            StartCoroutine(CameraEffectSystem.Instance.FTimeScaleControl(0.2f, 0.00001000f));
            StartCoroutine(wudi(0.2f));
            //StartCoroutine(CameraEffectSystem.Instance.FCameraShake(0.05f,0.2f));
            //anim.CrossFade("att_pindao",0);
            _player.SetStage(tanfan_stage);
            canhurt = false;
            RuneManager.Instance.UseRune(RuneEvent.OnDefence);
        }

        if ((other.tag =="enemy_att"&&canhurt))
        {
            CameraEffectSystem.Instance.FHitEffect();
            FLoseHp(other.GetComponentInParent<enemy_base>().ATK);
            enemypos = other.GetComponentInParent<enemy_base>().transform.position;
            atting = false;
            _player.SetStage(hurt_stage);
        }




    }

    public void FGetMana(float num)
    {
        mana += num;
        if(mana == Manamax)
        {
            RuneManager.Instance.UseRune(RuneEvent.OnManaFull);
        }
        MainPanel.Instance.UpdateMp();
    }

    public bool FLoseMana(float num)
    {
        if(mana-num < 0)
        {
            return false;
        }
        else
        {
            mana -= num;
            MainPanel.Instance.UpdateMp();
            RuneManager.Instance.UseRune(RuneEvent.OnManaFull);
            return true;
        }
        
    }

    public void FGetHp(float num)
    {
        hp += num;
        MainPanel.Instance.UpdateHp();
    }

    public void FLoseHp(float num)
    {
        hp -= num;

        MainPanel.Instance.UpdateHp();
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

    void attint(ref float count)
    {
        if(attanim==2)
        {
            count += Time.deltaTime;
            if(count>1)
            {
                attanim = 1;
            }
        }
    }

}
