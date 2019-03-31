using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicBone : MonoBehaviour
{
    public Transform Root;
    [Range(0,2)]
    public float Inert;
    [Range(0,1)]
    public float Damping;
    [Range(0,1)]
    public float Elasticity;
    
    private Dictionary<DynamicParticle, Transform> particles;

    private List<Constrain> constrains;
    // Start is called before the first frame update
    private void LateUpdate()
    {
        foreach (var p in particles.Keys)
        {
            InertProcess(p);
            VerletProcess(p);
        }
        foreach (var constrain in constrains)
        {
            constrain.Solve();
        }
    }

    public void UpdateData()
    {
        if(Root != null)
        {
            AddList(Root);
        }
    }

    private void AddList(Transform root)
    {
        Transform temp;
        DynamicParticle pA = new DynamicParticle(root);
        for (int i = 0; i < root.childCount; i++)
        {
            temp = root.GetChild(i);
            DynamicParticle pB = new DynamicParticle(temp);
            particles.Add(pB, temp);
            constrains.Add(new VectorConstrain(pA, pB,Elasticity));
            AddList(temp);
        }
    }

    private void UpdatePositon()
    {

    }

    private void VerletProcess(DynamicParticle p)
    {
        Vector3 nextPos = p.curPos + (p.curPos - p.oldPos) * Damping;
        p.oldPos = p.curPos;
        p.curPos = nextPos;
    }

    private void InertProcess(DynamicParticle p)
    {
        Vector3 deltaVec = p.curPos - p.oldPos;
        p.oldPos += Inert * deltaVec;
        p.curPos += Inert * deltaVec;
    }
    
}

