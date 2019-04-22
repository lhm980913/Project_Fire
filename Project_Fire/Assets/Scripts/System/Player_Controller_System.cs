using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller_System : UnityEngine.MonoBehaviour
{
    static public Player_Controller_System Instance; //单例模式

    public enum Button_Stage
    {
        off,
        down,
        stay,
        up
    };
    [HideInInspector]
    public float Horizontal_Left;
    [HideInInspector]
    public float Vertical_Left;
    [HideInInspector]
    public float Horizontal_Right;
    [HideInInspector]
    public float Vertical_Right;
    [HideInInspector]
    public float Xbox_X;
    [HideInInspector]
    public float Xbox_Y;
    [HideInInspector]
    public float LT;
    [HideInInspector]
    public float RT;
    [HideInInspector]
    public Button_Stage Button_A;
    [HideInInspector]
    public Button_Stage Button_B;
    [HideInInspector]
    public Button_Stage Button_X;
    [HideInInspector]
    public Button_Stage Button_Y;
    [HideInInspector]
    public Button_Stage Button_LB;
    [HideInInspector]
    public Button_Stage Button_RB;
    [HideInInspector]
    public Button_Stage Button_Back;
    [HideInInspector]
    public Button_Stage Button_Start;
    [HideInInspector]
    public Button_Stage Left_Down;
    [HideInInspector]
    public Button_Stage Right_Down;



    public KeyCode Key_Button_A;
    public KeyCode Key_Button_B;
    public KeyCode Key_Button_X;
    public KeyCode Key_Button_Y;
    public KeyCode Key_Button_LB;
    public KeyCode Key_Button_RB;
    public KeyCode Key_Button_Back;
    public KeyCode Key_Button_Start;
    public KeyCode Key_Left_Down;
    public KeyCode Key_Right_Down;

    public KeyCode Key_Horizontal_Left;
    public KeyCode Key_Vertical_Left;
    public KeyCode Key_Horizontal_Right;
    public KeyCode Key_Vertical_Right;
    public KeyCode Key_Xbox_X;
    public KeyCode Key_Xbox_Y;
    public KeyCode Key_Horizontal_Left_fu;
    public KeyCode Key_Vertical_Left_fu;
    public KeyCode Key_Horizontal_Right_fu;
    public KeyCode Key_Vertical_Right_fu;
    public KeyCode Key_Xbox_X_fu;
    public KeyCode Key_Xbox_Y_fu;

    public KeyCode Key_LT;
    public KeyCode Key_RT;
    // Start is called before the first frame update
    private void Awake()
    {
        if(Instance==null)
        {
            Instance = this;
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {  
        FGet_Input_value(); 


    }

    void FGet_Input_value()
    {
        Horizontal_Left = FCheck_Axis("Horizontal_Left",Key_Horizontal_Left, Key_Horizontal_Left_fu);
        Vertical_Left = FCheck_Axis("Vertical_Left",Key_Vertical_Left, Key_Vertical_Left_fu);
        Horizontal_Right = FCheck_Axis("Horizontal_Right",Key_Horizontal_Right, Key_Horizontal_Right_fu);
        Vertical_Right = FCheck_Axis("Vertical_Right",Key_Vertical_Right, Key_Vertical_Right_fu);
        Xbox_X = FCheck_Axis("Xbox_X",Key_Xbox_X, Key_Xbox_X_fu);
        Xbox_Y = FCheck_Axis("Xbox_Y",Key_Xbox_Y, Key_Xbox_Y_fu);
        LT = FCheck_Axis("LT",Key_LT);
        RT = FCheck_Axis("RT", Key_RT);
        Button_A = FCheck_Button_Stage("Button_A",Key_Button_A);
        Button_B = FCheck_Button_Stage("Button_B",Key_Button_B);
        Button_X = FCheck_Button_Stage("Button_X",Key_Button_X);
        Button_Y = FCheck_Button_Stage("Button_Y",Key_Button_Y);
        Button_LB = FCheck_Button_Stage("Button_LB",Key_Button_LB);
        Button_RB = FCheck_Button_Stage("Button_RB",Key_Button_RB);
        Button_Start = FCheck_Button_Stage("Button_Start",Key_Button_Start);
        Button_Back = FCheck_Button_Stage("Button_Back",Key_Button_Back);
        Left_Down = FCheck_Button_Stage("Left_Down",Key_Left_Down);
        Right_Down = FCheck_Button_Stage("Right_Down",Key_Right_Down);
    }  //获得输入值
    Button_Stage FCheck_Button_Stage(string button_name , KeyCode keyCode)
    {
        Button_Stage a= Button_Stage.off;
        if (Input.GetButtonDown(button_name)||Input.GetKeyDown(keyCode))
        {
            a = Button_Stage.down;
        }
        else if (Input.GetButton(button_name)|| Input.GetKey(keyCode))
        {
            a = Button_Stage.stay;
        }
        else if (Input.GetButtonUp(button_name)|| Input.GetKeyUp(keyCode))
        {
            a = Button_Stage.up;
        }
        else
        {
            a = Button_Stage.off;
        }
        return a;
    } //按钮
    float FCheck_Axis(string axis_name,KeyCode key_zheng,KeyCode key_fu)
    {
        int a = 0;
        if (Input.GetKey(key_zheng))
        {
            a = 1;
        }
        else if(Input.GetKey(key_fu))
        {
            a = -1;
        }
        else
        {
            a = 0;
        }
        return Mathf.Clamp(Input.GetAxis(axis_name)+a,-1,1);
    } //摇杆

    float FCheck_Axis(string axis_name, KeyCode key)
    {
        int a = 0;
        if (Input.GetKey(key))
        {
            a = 1;
        }
        
        else
        {
            a = 0;
        }
        return Mathf.Clamp(Input.GetAxis(axis_name) + a, 0, 1);
    } //摇杆
    //void check()
    //{
    //    print(LT+"lt");
    //    print(RT + "rt");
    //}
}
