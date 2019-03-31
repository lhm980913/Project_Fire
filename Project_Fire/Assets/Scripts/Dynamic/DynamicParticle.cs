using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicParticle
{
    public Vector3 curPos;
    public Vector3 oldPos;

    public DynamicParticle(Transform transform)
    {
        curPos = transform.position;
        oldPos = transform.position;
    }
}
