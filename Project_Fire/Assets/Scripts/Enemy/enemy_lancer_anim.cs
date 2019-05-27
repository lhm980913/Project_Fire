using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_lancer_anim : MonoBehaviour
{
    lancetest lance;
    // Start is called before the first frame update
    void Start()
    {
        lance = GetComponentInParent<enemy_lancer>().weapon;
    }

    // Update is called once per frame
    void throw_lance()
    {
        lance.stage = 3;
        lance.playerpos = testplayer.Instance.transform.position;
        lance.thispos = lance.transform.position;
    }
}
