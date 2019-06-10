using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YinZhenEntity : MonoBehaviour
{
    public float speed = 12.0f;
    public float Distance = 20;

    private Vector3 dir;
    private float distance;
    private void Awake()
    {
        dir = testplayer.Instance.transform.right*testplayer.Instance.face_to;
        distance = 0;
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
        if (distance >= Distance)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "enemy"&&other.GetComponent<enemy_base>())
            ProcessSystem.Instance.FPlayerSkill_Enemy(other.gameObject.GetComponent<enemy_base>(),0.34f);
    }
}
