using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_boss_anim : MonoBehaviour
{
    public enemy_boss boss;
    public GameObject paodan;
    public Transform shootpos;
    public GameObject ci;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    void att1_move_()
    {
        StartCoroutine(att1_move());
    }
    void jump_()
    {
        StartCoroutine(jump());
    }
    void houzuoli_()
    {
        StartCoroutine(houzuoli());
        float v = Mathf.Sqrt((Mathf.Abs(shootpos.position.x - testplayer.Instance.transform.position.x) * 10 / 2));

        GameObject pao1 = Instantiate(paodan);
        pao1.transform.position = new Vector3(shootpos.position.x, shootpos.position.y, 0);     
        pao1.GetComponent<paodan>().speedx = boss.faceto * v + 0.3f*v;
        pao1.GetComponent<paodan>().speedy = v + 0.3f * v;
        GameObject pao2 = Instantiate(paodan);
        pao2.transform.position = new Vector3(shootpos.position.x, shootpos.position.y, 0);
        pao2.GetComponent<paodan>().speedx = boss.faceto * v;
        pao2.GetComponent<paodan>().speedy = v;
        GameObject pao3 = Instantiate(paodan);
        pao3.transform.position = new Vector3(shootpos.position.x, shootpos.position.y, 0);
        pao3.GetComponent<paodan>().speedx = boss.faceto * v - 0.3f * v;
        pao3.GetComponent<paodan>().speedy = v - 0.3f * v;
    }
    void shake()
    {
        StartCoroutine(CameraEffectSystem.Instance.FCameraShake(1f, 1f));
        StartCoroutine(chuci());

    }
    IEnumerator chuci()
    {
        for(int i=0;i<30;i++)
        {
            if(i>2)
            {
                GameObject ci1 = Instantiate(ci);
                ci1.transform.position = boss.transform.position + Vector3.down * 4 + Vector3.right * i * 0.6f;
                GameObject ci2 = Instantiate(ci);
                ci2.transform.position = boss.transform.position + Vector3.down * 4 - Vector3.right * i * 0.6f;
                yield return new WaitForSeconds(0.1f);
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
    void backjump1()
    {
        boss.GetComponent<Rigidbody>().velocity += new Vector3(boss.faceto * -1 * 7, 12, 0);
    }

    void backjump2andshoot()
    {
        boss.GetComponent<Rigidbody>().velocity += new Vector3(boss.faceto * -1 * 10, 0, 0);
       
        float v = (Mathf.Abs(shootpos.position.x - testplayer.Instance.transform.position.x) / Mathf.Sqrt((2 * Mathf.Abs(shootpos.position.y - testplayer.Instance.transform.position.y)) / 10));


        GameObject pao1 = Instantiate(paodan);
        pao1.transform.position = new Vector3(shootpos.position.x, shootpos.position.y, 0);
        pao1.GetComponent<paodan>().speedx = boss.faceto * v+0.3f*v;
        pao1.GetComponent<paodan>().speedy = 0;
        GameObject pao2 = Instantiate(paodan);
        pao2.transform.position = new Vector3(shootpos.position.x, shootpos.position.y, 0);
        pao2.GetComponent<paodan>().speedx = boss.faceto * v;
        pao2.GetComponent<paodan>().speedy = 0;
        GameObject pao3 = Instantiate(paodan);
        pao3.transform.position = new Vector3(shootpos.position.x, shootpos.position.y, 0);
        pao3.GetComponent<paodan>().speedx = boss.faceto * v - 0.3f * v;
        pao3.GetComponent<paodan>().speedy = 0;

    }
   
    IEnumerator att1_move()
    {
  

        float time_ding = 0.2f;
        float time_bian = 0;
        Vector3 begin = boss.transform.position;
        Vector3 target = testplayer.Instance.transform.position + Vector3.Normalize(boss.transform.position - testplayer.Instance.transform.position) * 2.5f;
        while (time_bian < time_ding)
        {
            boss.transform.position = Flerp(time_ding, time_bian, target, boss.transform.position, begin);
            time_bian += Time.deltaTime;
            yield return null;
        }
    }
    IEnumerator jump()
    {

        float time_ding = 0.5f;
        float time_bian = 0;
        Vector3 begin = boss.transform.position;
        Vector3 target = testplayer.Instance.transform.position + Vector3.up * 5f +Vector3.Normalize(boss.transform.position - testplayer.Instance.transform.position) * 1.5f;

        while (time_bian < time_ding)
        {

            boss.transform.position = Flerp(time_ding, time_bian, target, boss.transform.position, begin);
            time_bian += Time.deltaTime;
            yield return null;
        }


    }
    IEnumerator houzuoli()
    {
        float time_ding = 0.4f;
        float time_bian = 0;
        Vector3 begin = boss.transform.position;
        float dis = 3;
        if (Physics.Raycast(boss.transform.position, Vector3.left * boss.faceto, out RaycastHit info, 4, 1 << 9))
        {
            dis = Mathf.Abs(info.transform.position.x - boss.transform.position.x)-1;
            
        }
            Vector3 target = boss.transform.position + (boss.faceto*Vector3.left*dis);

        while (time_bian < time_ding)
        {
            boss.transform.position = Flerp(time_ding, time_bian, target, boss.transform.position,begin);
            time_bian += Time.deltaTime;
            yield return null;
        }


    }

    //把vec变量key在t时间内差值到目标值target
    Vector3 Flerp(float time_ding,float time_bian, Vector3 target, Vector3 key, Vector3 begin)
    {

        key = Vector3.Lerp(begin, target, time_bian / time_ding);
        return key;
    }
    void Update()
    {
       
    }
}
