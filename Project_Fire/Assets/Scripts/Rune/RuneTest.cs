﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        RuneManager.Instance.GenerateRune(transform.position);    
    }

    
}