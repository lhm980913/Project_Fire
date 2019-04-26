using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageUI : MonoBehaviour
{
    public TextMesh textMesh;

    public void Enter(int damage)
    {
        gameObject.SetActive(true);
        textMesh.text = damage.ToString();
    }

    public void Exit()
    {
        gameObject.SetActive(false);
    }
}
