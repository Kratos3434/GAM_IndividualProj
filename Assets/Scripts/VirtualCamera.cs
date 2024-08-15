using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class VirtualCamera : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera vc;
    // Start is called before the first frame update
    
    public void ModifyHeight(float height)
    {
        vc.GetCinemachineComponent<CinemachineFramingTransposer>().m_ScreenY = height;   
    }
}
