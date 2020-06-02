using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{

    public static GameManager manager;


    // Start is called before the first frame update
    void Start()
    {
        manager = this;
        Cursor.lockState = CursorLockMode.Locked;
        Application.targetFrameRate = 150;
 
        /*if (VirtualCamera != null)
            virtualCameraNoise = VirtualCamera.GetCinemachineComponent<Cinemachine.CinemachineBasicMultiChannelPerlin>();*/
    }
}
