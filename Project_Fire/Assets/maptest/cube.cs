using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cube : UnityEngine.MonoBehaviour
{
    public int[] suround=new int[9];
    // Start is called before the first frame update

    [SerializeField]
    public List<GameObject> instance;

    private void Awake()
    {
        
    }
    void Start()
    {
        destory(suround);


    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void destory(int[] suround)
    {
        for (int i = 0; i < 9; i++)
        {

            if (suround[i] == 0)
            {
                Destroy(instance[i]);
            }
            if (suround[0] == 1 && (suround[1] == 0 || suround[3] == 0))
            {
                Destroy(instance[0]);
            }
            if (suround[2] == 1 && (suround[1] == 0 || suround[5] == 0))
            {
                Destroy(instance[2]);
            }
            if (suround[6] == 1 && (suround[3] == 0 || suround[7] == 0))
            {
                Destroy(instance[6]);
            }
            if (suround[8] == 1 && (suround[5] == 0 || suround[7] == 0))
            {
                Destroy(instance[8]);
            }

        }
    }
}
