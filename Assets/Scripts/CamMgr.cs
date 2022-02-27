using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMgr : MonoBehaviour
{
    public GameObject   CameraFridgeView;
    
    // Start is called before the first frame update
    void Start()
    {
        if(CameraFridgeView) CameraFridgeView.SetActive(true);
    }


}
