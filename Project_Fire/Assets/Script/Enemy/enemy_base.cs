using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Enemy_Stage
{
    stand,
    att,
    move
}
public abstract class enemy_base : MonoBehaviour
{
    public float maxhp;
    Enemy_Stage _stage;
    public Enemy_Stage Stage
    {
        get
        {
            return this._stage;
        }
        set
        {
            this._stage = value;
        }
     
    }
    float _hp;
    public float Hp
    {
        set
        {
            this._hp = Mathf.Clamp(value, 0f, maxhp);
                
        }
        get
        {
            return this._hp;
        }
    }

    public abstract void FSM(Enemy_Stage stage);

}
