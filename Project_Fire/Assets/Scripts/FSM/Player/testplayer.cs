using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class testplayer : MonoBehaviour
{
    static public testplayer Instance;

    public float speed;
    public float jump_speed;
    public float little_jump_speed;
    public float maxflashspeed;

    public float rapelength;   
    public float rapespeed;
    public float ymaxspeed;
    public float player_att_speed;
    public float canthurtcount;
    public float hurtforce;
    public GameObject playerwapon;


    public ParticleSystem daoguang;
    public ParticleSystem slide_dust;
    public ParticleSystem slide_dust1;
    public ParticleSystem att_up_effect;
    public ParticleSystem att_down_effect;
    public GameObject weapon;

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
    public bool canhurt = true;
    [HideInInspector]
    public bool atting = false;
    [HideInInspector]
    public Vector3 velocity;
    [HideInInspector]
    public Vector3 physic_velocity;
    // Start is called before the first frame update


    static public Player _player;
    public AnimationCurve ac;
    public Animator anim;
    public GameObject moudle_player;
    public bool canjump;


    public Player_Base_Stage stand_stage;
    public Player_Base_Stage run_stage;
    public Player_Base_Stage jump_stage;
    public Player_Base_Stage flash_stage;
    public Player_Base_Stage rape_stage;
    public Player_Base_Stage att_stage;
    public Player_Base_Stage hurt_stage;

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

        if (Instance==null)
        {
            Instance = this;

        }
        playergameobj = this.gameObject;
        aa = player_att_speed;
        canhurt = true;
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
        
        grounded = FCheckground();

        FYspeedclamp();

        _player.Update();

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
        daoguang.transform.position = new Vector3(daoguang.transform.position.x, daoguang.transform.position.y, 0.37f*face_to);
        daoguang.startRotation3D = new Vector3(daoguang.startRotation3D.x, 1.57f+face_to*1.57f ,daoguang.startRotation3D.z);
        //slide_dust.transform.position = new Vector3(slide_dust.transform.position.x , slide_dust.transform.position.y, transform.position.z + face_to * 0.5f);
        slide_dust.startRotation3D = new Vector3(slide_dust.startRotation3D.x, 1.57f + face_to * 1.57f, slide_dust.startRotation3D.z);
        slide_dust1.startRotation3D = new Vector3(slide_dust1.startRotation3D.x, 1.57f + face_to * 1.57f, slide_dust1.startRotation3D.z);
        //slide_dust.shape.position = new Vector3(0.5f*face_to, 0.5f, 0.3f);
        // slide_dust.shape.position.Set(0.5f * face_to, -0.5f, 0.3f);
        att_up_effect.startRotation3D = new Vector3(att_up_effect.startRotation3D.x, 1.57f + -1*face_to * 1.57f, att_up_effect.startRotation3D.z);
        att_down_effect.startRotation3D = new Vector3(att_down_effect.startRotation3D.x, 1.57f + -1 * face_to * 1.57f, att_down_effect.startRotation3D.z);
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
        anim.SetBool("atting", atting);
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
            if(aa<0)
            {
                canatt = true;
            }


        }
    }

    private void FActiveRune()
    {
        RuneManager.Instance.UseRune(RuneEvent.Active);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "enemy_weapon" && atting)
        {
            //print(1110);
            StartCoroutine(CameraEffectSystem.Instance.FTimeScaleControl(0.3f, 0.00001f));
            StartCoroutine(wudi(0.2f));
            //StartCoroutine(CameraEffectSystem.Instance.FCameraShake(0.05f,0.2f));
            anim.CrossFade("att_pindao",0);
            ProcessSystem.Instance.Fenemy_re(other.gameObject);
            
        }
        if ((other.tag =="enemy_att"&&canhurt)|| (other.tag == "enemy" && canhurt))
        {
            //print("tmd死");
            enemypos = other.transform.position;
            atting = false;
            _player.SetStage(hurt_stage);
        }
       
    }
   public IEnumerator wudi(float time)
    {
        canhurt = false;
        yield return new WaitForSeconds(time);
        canhurt = true;
    }
}
