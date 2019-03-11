using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class testplayer : MonoBehaviour
{
    static public testplayer Instance;

    public float speed;
    public GameObject playergameobj;
    // Start is called before the first frame update
    static public Player _player;

    public Player_Base_Stage stand_stage;
    public Player_Base_Stage run_stage;
    private void Awake()
    {
        _player = new Player();
        stand_stage = new Stand_Stage();
        run_stage = new Run_Stage();




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
        
        _player.Update();
    }
}
