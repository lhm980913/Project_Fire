using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_ci : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.localRotation = Quaternion.Euler(new Vector3(0, 0, Random.Range(-15, 15)));
        StartCoroutine(begin());

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator begin()
    {
        float time_ding = 0.4f;
        float time_bian = 0;
        Vector3 begin = transform.position;
        Vector3 target = transform.position + Vector3.up * 5;

        while(time_bian<time_ding)
        {
            transform.position = Flerp(time_ding,time_bian, target, transform.position, begin);
            time_bian += Time.deltaTime;
            yield return null;
        }
        yield return new WaitForSeconds(0.5f);
        time_ding = 0.3f;
        time_bian = 0;
        begin = transform.position;
        target = transform.position - Vector3.up * 7;

        while (time_bian < time_ding)
        {
            transform.position = Flerp(time_ding, time_bian, target, transform.position, begin);
            time_bian += Time.deltaTime;
            yield return null;
        }

        Destroy(this.gameObject, 1f);
    }
    Vector3 Flerp(float time, Vector3 target, Vector3 key, Vector3 zero)
    {
        key = Vector3.SmoothDamp(key, target, ref zero, time);
        return key;
    }
    //把vec变量key在t时间内差值到目标值target
    Vector3 Flerp(float time_ding, float time_bian, Vector3 target, Vector3 key, Vector3 begin)
    {

        key = Vector3.Lerp(begin, target, time_bian / time_ding);
        return key;
    }
}
