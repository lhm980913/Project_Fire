using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class point_switch : MonoBehaviour
{
    public GameObject door;
    Transform rape_manager;
    // Start is called before the first frame update
    void Start()
    {
        rape_manager = GameObject.FindGameObjectWithTag("rape_manager").transform;
        GameObject go = Instantiate(door, this.transform.position, Quaternion.identity) as GameObject;
        go.transform.SetParent(rape_manager);
        //chuancan(go, i, j);
        go.layer = LayerMask.NameToLayer("Rape_Point");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
