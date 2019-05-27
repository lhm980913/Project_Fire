using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lancetest : enemy_base
{
    public int stage = 1;
    public enemy_lancer lancer;
    public Vector3 playerpos;
    public Vector3 thispos;
    bool stop = false;
    float count = 3;
    // Start is called before the first frame update
    private void Awake()
    {
        type = "lance";
        Hp = maxhp;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       switch(stage)
        {
            case 0:
                {
                    GetComponent<BoxCollider>().enabled = true;
                    GetComponent<BoxCollider>().isTrigger = false;
                    GetComponent<Rigidbody>().isKinematic = false;
                }
                break;
            case 1:
                {
                    count = 3;
                    stop = false;
                    GetComponent<BoxCollider>().enabled = false;
                    transform.position = Flerp(0.08f, lancer.transform.position - Vector3.right * lancer.faceto*0.4f, transform.position, Vector3.zero);
                    transform.localRotation = Quaternion.Euler(0, 0, 0);
                }
                break;
            case 2:
                {
                    GetComponent<BoxCollider>().enabled = true;
                    transform.position = Flerp(0.1f, lancer.transform.position + Vector3.up * 2f, transform.position, Vector3.zero);
                    transform.localRotation = Quaternion.Euler( new Vector3(0,0, Ffocusplayer()));
                    //transform.Translate(Vector3.Normalize(transform.position - testplayer.Instance.transform.position));
                }
                break;
            case 3:
                {
                    GetComponent<BoxCollider>().enabled = true;
                    //transform.position = Flerp(0.1f, playerpos+Vector3.Normalize(playerpos- thispos) *2, transform.position, Vector3.zero);
                    transform.position += Vector3.Normalize(playerpos - thispos) * 17 * Time.deltaTime;
                    if(Vector3.Distance(transform.position, playerpos + Vector3.Normalize(playerpos - thispos) * 20)<1||stop)
                    {
                        stage = 4;
                    }
                }
                break;
            case 4:
                {
                    count -= Time.deltaTime;
                    if(count<0)
                    {
                        stage = 1;
                    }
                }
                break;


        }

        //this.transform.localRotation = Quaternion.Euler(0, 0, Ffocusplayer());

    }
    private void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        if(other.tag=="map"&&stage==3)
        {
            stop = true;
        }
    }
    public float Ffocusplayer()
    {
        float a;
        Vector3 dir = Vector3.Normalize(testplayer.Instance.transform.position - transform.position);
        if (dir.x >= 0)
        {
            if (dir.y >= 0)
            {
                a = Mathf.Atan(dir.y / dir.x) * 180 / Mathf.PI;
            }
            else
            {
                a = Mathf.Atan(dir.y / dir.x) * 180 / Mathf.PI + 360;
            }

        }
        else
        {
            a = Mathf.Atan(dir.y / dir.x) * 180 / Mathf.PI + 180;
        }
        return a-90;
    }

    //把vec变量key在t时间内差值到目标值target
    Vector3 Flerp(float time,Vector3 target,Vector3 key,Vector3 zero)
    {
        key = Vector3.SmoothDamp(key, target,ref zero, time);
        return key;
    }

}
