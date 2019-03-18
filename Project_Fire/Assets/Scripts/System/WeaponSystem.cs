using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSystem : MonoBehaviour
{
    static int activeEffectMaxCount = 2;
    static int passiveEffectMaxCount = 4;
    public static WeaponSystem instance;
    List<WeaponEffect> weaponEffects;

    private void Awake()
    {
        if (!instance)
            instance = this;
        weaponEffects = new List<WeaponEffect>();
    }

    public void FAddEffect(WeaponEffect effect)
    {
        weaponEffects.Add(effect);
    }

    public void FAddEffect(WeaponEffect effect, int index)
    {
        weaponEffects.RemoveAt(index);
        weaponEffects.Insert(index, effect);
    }

    public void UseWeaponEffect(CallType callType)
    {
        foreach(var effect in weaponEffects)
        {
            if(effect.callType == callType)
            {
                effect.Execute();
            }
        }
    }

    public WeaponEffect CreateWeaponEffect()
    {
        return null;
    }
}

public enum CallType
{
    active,
    onFlash,
    onRape,
    onDefence,
    onAttackEnemy,
    onAttackBullte,
    onPick
}

abstract public class WeaponEffect
{
    public CallType callType;
    public string Name;
    public string Description;
    abstract public void Execute();
    protected LayerMask enemy_layermask = 1 << 11;
}

public class activeEffect:WeaponEffect
{
    public override void Execute(){ }
}

public class passiveEffect:WeaponEffect
{
    public override void Execute(){ }
}
