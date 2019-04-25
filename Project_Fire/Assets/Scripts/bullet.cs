using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : UnityEngine.MonoBehaviour
{
    float speed = 10;
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = testplayer.Instance.transform;
        this.transform.LookAt(player);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += transform.forward * speed*Time.deltaTime;
    }
}
