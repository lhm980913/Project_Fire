using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class testplayer : MonoBehaviour
{
    static public testplayer Instance;

    public float speed;
    public float jump_speed;
    public float little_jump_speed;
    public GameObject playergameobj;
    public bool grounded;
    public float maxflashspeed;
    public float flashtime;
    public float flashcd;
    public int face_to = 1;
    public bool canflash = true;
    public float rapelength;
    public Vector3 target_pos;
    public bool canrape;
    public float rapespeed;
    public float ymaxspeed;
    // Start is called before the first frame update


    static public Player _player;
    public AnimationCurve ac;
    public Animator animation;
    public GameObject moudle_player;

    public Player_Base_Stage stand_stage;
    public Player_Base_Stage run_stage;
    public Player_Base_Stage jump_stage;
    public Player_Base_Stage flash_stage;
    public Player_Base_Stage rape_stage;


    private void Awake()
    {
        _player = new Player();
        stand_stage = new Stand_Stage();
        run_stage = new Run_Stage();
        jump_stage = new Jump_Stage();
        flash_stage = new Flash_Stage();
        rape_stage = new Rape_Stage();
        if (Instance==null)
        {
            Instance = this;
        }
        playergameobj = this.gameObject;

       
    }

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        moudle_player.transform.rotation = Quaternion.Euler(0, face_to * 90, 0);


        FAnimation();
        
        grounded = FCheckground();
        flashcd -= Time.deltaTime;
        FYspeedclamp();
        _player.Update();
    }
    bool FCheckground()
    {
        LayerMask lm = 1 << 9;
        Collider[] a = Physics.OverlapSphere(playergameobj.transform.position - new Vector3(0,0.5f,0), 0.02f,lm);
      
        if (a.Length == 0)
        {
            return false;
        }
        else return true;
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
        animation.SetFloat("speed", playergameobj.GetComponent<Rigidbody>().velocity.y);

        animation.SetBool("ground", grounded);
    }
}
