using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Constrain
{
    void Solve();
}

public class VectorConstrain : Constrain
{
    DynamicParticle particleA;
    DynamicParticle particleB;
    Vector3 InitalVector;
    float Elasticity;

    public VectorConstrain(DynamicParticle pA, DynamicParticle pB, float e = 0.25f)
    {
        particleA = pA;
        particleB = pB;
        InitalVector = pB.curPos - pA.curPos;
        Elasticity = e;
    }

    public void Solve()
    {
        Vector3 curVector = particleB.curPos - particleA.curPos;
        particleB.curPos += (InitalVector - curVector) * Elasticity;
    }
}
