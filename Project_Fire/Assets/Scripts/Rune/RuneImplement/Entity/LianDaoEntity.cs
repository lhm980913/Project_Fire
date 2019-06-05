using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class LianDaoEntity : MonoBehaviour
{
    public float speed = 12.0f;
    [HideInInspector]
    public Vector3 dir;

    public float Distance = 20;
    private float distance;
    private bool BeBack;
    private void Awake()
    {
        distance = 0;
        BeBack = false;
        if (!GetComponent<Collider>().isTrigger)
        {
            GetComponent<Collider>().isTrigger = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(dir * speed * Time.deltaTime, Space.World);
        distance += speed * Time.deltaTime;
        if(distance >= Distance)
        {
            BeBack = true;
            dir = (testplayer.Instance.transform.position - transform.position).normalized;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "enemy")
            ProcessSystem.Instance.FPlayerSkill_Enemy(other.gameObject.GetComponent<enemy_base>(),0.3f);
        if (BeBack == true)
        {
            if (other.tag == "Player")
                Destroy(gameObject);
        }
    }
}
