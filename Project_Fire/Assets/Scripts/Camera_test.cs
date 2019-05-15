using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Camera_test : UnityEngine.MonoBehaviour
{
    public enum CurrentFOV
    {
        Normal,
        Zoom
    }

    Vector3 a = Vector3.zero;
    public float NormalFOV;
    public float ZoomFOV;
    public CinemachineVirtualCamera Vcam;
    public Transform cameraTarget;

    private CurrentFOV fovStage;
    CinemachineBrain brain;
    

    bool aix;
    // Start is called before the first frame update
    void Start()
    {
        brain = GetComponent<CinemachineBrain>();
        aix = true;
    }

    // Update is called once per frame
    void Update()
    {
        //this.transform.position = new Vector3(testplayer.Instance.transform.position.x, testplayer.Instance.transform.position.y, z);

        if(Input.GetKeyDown(KeyCode.O)||Player_Controller_System.Instance.Xbox_Y==-1)
        {
            if(aix)
            {
                if (fovStage == CurrentFOV.Normal)
                {
                    Vcam.m_Lens.FieldOfView = ZoomFOV;
                    fovStage = CurrentFOV.Zoom;
                }
                else
                {
                    Vcam.m_Lens.FieldOfView = NormalFOV;
                    fovStage = CurrentFOV.Normal;
                }
            }
            aix = false;
           // transform.position=transform.position+Vector3.forward;
        }else
        {
            aix = true;
        }
    
        if(Player_Controller_System.Instance.Vertical_Left < 0.0 && testplayer.Instance.grounded)
        {
            cameraTarget.localPosition = new Vector3(0, -2.5f, 0);
        }
        else
        {
            cameraTarget.localPosition = Vector3.zero;
        }
    }
}
