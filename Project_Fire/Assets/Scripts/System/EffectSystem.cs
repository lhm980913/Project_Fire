using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Config;
using Effect;

public class EffectSystem : MonoBehaviour
{
    static public EffectSystem instance;
    private EffectConfig effectConfig;
    Dictionary<string, List<GameEffect>> effectPool = new Dictionary<string, List<GameEffect>>();
        
    //初始化Hash表
    private void FInit()
    {
        string name;
        string path;
        Object obj = Resources.Load("Config\\EffectConfig");
        effectConfig = Instantiate(obj) as EffectConfig;
        for(int i = 0; i < effectConfig.keys.Count; i++)
        {
            name = effectConfig.keys[i];
            path = effectConfig.values[i];
            for(int count = 0; count < effectConfig.Num[i]; count++)
            {
                FCreateEffect(name, path);
            }
        }
    }
    //创建一个新特效
    private GameEffect FCreateEffect(string effectName,string path)
    {
        Object obj = Resources.Load(path,typeof(GameObject));
        if (obj == null)
        {
            Debug.LogError("Can't find obejct " + path);
            return null;
        }
        else
        {
            GameObject go = (GameObject)Instantiate(obj);
            GameEffect ge = go.AddComponent<GameEffect>();
            ge.FInit();
            if (!effectPool.ContainsKey(path))
            {
                effectPool.Add(effectName, new List<GameEffect>());
            }
            effectPool[effectName].Add(ge);
            //Debug.Log(effectName);
            return ge;
        }
    }
    //在表中寻找特定特效
    private GameEffect FGetEffect(string name)
    {
        if(!effectPool.ContainsKey(name))
        {
            Debug.LogError("No Such Effect " + name);
            return null;
        }

        List<GameEffect> pool = effectPool[name];
        GameEffect restGameEffect = null;
        for(int i = 0; i < pool.Count; i++)
        {
            GameEffect ge = pool[i];
            if(ge.gameObject.activeSelf)
            {
                continue;
            }
            restGameEffect = ge;
            break;
        }

        if (!restGameEffect)
        {
            restGameEffect = FCreateEffect(name, effectConfig.Target[name]);
        }
        return restGameEffect;
    }
    //将特效释放到特定位置
    public GameEffect FAddWorldEffect(string effectName, Vector3 pos, float scale = 1)
    {
        GameEffect ge = FGetEffect(effectName);
        if(!ge)
        {
            Debug.LogError("No such Effect " + effectName);
            return null;
        }
        ge.transform.position = pos;
        ge.FPlay(scale);
        return ge;
    }
    //使特效与某个物体绑定
    public GameEffect FAddObjectEffect(string effectName, GameObject obj, Vector3 pos, float scale = 1)
    {
        if (obj == null)
            return FAddWorldEffect(effectName, pos, scale);

        GameEffect ge = FGetEffect(effectName);

        if (!ge)
        {
            Debug.LogError("No such Effect " + effectName);
            return null;
        }
        ge.FSetParent(obj);
        ge.FPlay(scale);
        return ge;
    }

    private void Awake()
    {
        if(instance == null)
            instance = this;
        FInit();
    }
}


