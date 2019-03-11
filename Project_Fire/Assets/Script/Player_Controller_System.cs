using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller_System : MonoBehaviour
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
        Horizontal_Left = FCheck_Axis("Horizontal_Left");
        Vertical_Left = FCheck_Axis("Vertical_Left");
        Horizontal_Right = FCheck_Axis("Horizontal_Right");
        Vertical_Right = FCheck_Axis("Vertical_Right");
        Xbox_X = FCheck_Axis("Xbox_X");
        Xbox_Y = FCheck_Axis("Xbox_Y");
        LT = FCheck_Axis("LT");
        RT = FCheck_Axis("RT");
        Button_A = FCheck_Button_Stage("Button_A");
        Button_B = FCheck_Button_Stage("Button_B");
        Button_X = FCheck_Button_Stage("Button_X");
        Button_Y = FCheck_Button_Stage("Button_Y");
        Button_LB = FCheck_Button_Stage("Button_LB");
        Button_RB = FCheck_Button_Stage("Button_RB");
        Button_Start = FCheck_Button_Stage("Button_Start");
        Button_Back = FCheck_Button_Stage("Button_Back");
        Left_Down = FCheck_Button_Stage("Left_Down");
        Right_Down = FCheck_Button_Stage("Right_Down");
    }  //获得输入值
    Button_Stage FCheck_Button_Stage(string button_name)
    {
        Button_Stage a= Button_Stage.off;
        if (Input.GetButtonDown(button_name))
        {
            a = Button_Stage.down;
        }
        else if (Input.GetButton(button_name))
        {
            a = Button_Stage.stay;
        }
        else if (Input.GetButtonUp(button_name))
        {
            a = Button_Stage.up;
        }
        else
        {
            a = Button_Stage.off;
        }
        return a;
    } //按钮
    float FCheck_Axis(string axis_name)
    {
        return Input.GetAxis(axis_name);
    } //摇杆

    //void check()
    //{
    //    print(LT+"lt");
    //    print(RT + "rt");
    //}
}
