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

    public ParticleSystem daoguang;
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
    public bool canhurt =true;
    // Start is called before the first frame update


    static public Player _player;
    public AnimationCurve ac;
    public Animator anim;
    public GameObject moudle_player;

   

    public Player_Base_Stage stand_stage;
    public Player_Base_Stage run_stage;
    public Player_Base_Stage jump_stage;
    public Player_Base_Stage flash_stage;
    public Player_Base_Stage rape_stage;
    public Player_Base_Stage att_stage;
    public Player_Base_Stage hurt_stage;

    private void Awake()
    {
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
        a = Physics.Raycast(transform.position, -transform.up, 0.8f, lm);
        //Gizmos.DrawCube(transform.position , Vector3.one);
        return a;
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
        moudle_player.transform.rotation = Quaternion.Euler(0, face_to * 90, 0);
        daoguang.transform.position = new Vector3(daoguang.transform.position.x, daoguang.transform.position.y, 0.37f*face_to);
        daoguang.startRotation3D = new Vector3(daoguang.startRotation3D.x, 1.57f+face_to*1.57f ,daoguang.startRotation3D.z);
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

    private void OnTriggerStay(Collider other)
    {
        if((other.tag =="enemy_att"&&canhurt)|| (other.tag == "enemy" && canhurt))
        {
            enemypos = other.transform.position;
            _player.SetStage(hurt_stage);
        }
    }
}
