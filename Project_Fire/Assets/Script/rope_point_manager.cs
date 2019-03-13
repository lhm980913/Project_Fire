using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class rope_point_manager : MonoBehaviour
{
   // public List<GameObject> rape_point_list;
    LayerMask rape_point;
    Collider[] rp;
    float player_dir;
    List<float> dir_cha;
    int target;
    
    private void Awake()
    {
        float[] a = new float[10];
        rape_point = 1 << 10;
        dir_cha = new List<float>(a);
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       rp =  Physics.OverlapSphere(testplayer.Instance.transform.position, testplayer.Instance.rapelength, rape_point);


        Fcheckdir(ref player_dir);

       // float a =FCheckdir(testplayer.Instance.transform.position, rp[0].transform.position);
       // float a =FCheckdir(testplayer.Instance.transform.position, rp[0].transform.position);
        float min = 180;
        for(int i=0;i<rp.Length;i++)
        {
            //Debug.Log(dir_cha[i]);
            
            dir_cha[i] = Mathf.Abs( FCheckdir(testplayer.Instance.transform.position, rp[i].transform.position)-player_dir);
            if(dir_cha[i]<min)
            {
                min = dir_cha[i];
                target = i;
            }

           
        }
        
        if(target<rp.Length)
        {
           testplayer.Instance.target_pos = rp[target].transform.position;
        }
        if(rp.Length==0)
        {
           testplayer.Instance.canrape = false;
        }
        else
        {
            testplayer.Instance.canrape = true;
        }
       // Debug.Log(rp[target].transform.position);
        //for (int i = 0; i < rp.Length; i++)
        //{
          
        //}


        //  Debug.Log(dir);
    }
    float FCheckdir(Vector3 player_pos,Vector3 point_pos)
    {
        float a;
        Vector3 dir = Vector3.Normalize( point_pos - player_pos);
        if (dir.x >= 0)
        {
            if(dir.y>=0)
            {
                a = Mathf.Atan(dir.y / dir.x) * 180 / Mathf.PI;
            }
            else
            {
                a = Mathf.Atan(dir.y / dir.x) * 180 / Mathf.PI +360;
            }
           
        }
        else
        {
            a = Mathf.Atan(dir.y / dir.x) * 180 / Mathf.PI +180;
        }
      

        // 角度 = 弧度*180.0f/PI
        return a;
    }
    void Fcheckdir(ref float dir)
    {
        if (Player_Controller_System.Instance.Horizontal_Left == 0 && Player_Controller_System.Instance.Vertical_Left == 0)
        {

        }
        else
        {
            player_dir = FCheckdir(Vector2.zero, new Vector2(Player_Controller_System.Instance.Horizontal_Left, Player_Controller_System.Instance.Vertical_Left));
        }
        if (Player_Controller_System.Instance.Horizontal_Right == 0 && Player_Controller_System.Instance.Vertical_Right == 0)
        {

        }
        else
        {
            player_dir = FCheckdir(Vector2.zero, new Vector2(Player_Controller_System.Instance.Horizontal_Right, Player_Controller_System.Instance.Vertical_Right));
        }
    }
}
