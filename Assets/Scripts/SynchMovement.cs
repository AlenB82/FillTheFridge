using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SynchMovement : MonoBehaviour
{
    public Transform lastCollisionTrans;
    public float lerpTime = 10;
    public float offsetZ = 1.5f;


    private Vector3 newPos = Vector3.zero;
    private Rigidbody localRgb;

    private void Start() {
        localRgb = GetComponent<Rigidbody>();

        if(!localRgb) Debug.LogError("Add the Rigibody Component to the GO");
    }
    
    private void FixedUpdate() {
        
        if(lastCollisionTrans)
        {
            newPos.x = Mathf.Lerp( newPos.x, lastCollisionTrans.position.x, lerpTime * Time.deltaTime); 
            newPos.y = lastCollisionTrans.position.y;
            newPos.z = lastCollisionTrans.position.z + offsetZ; 

            localRgb.MovePosition( newPos ); 
        }

    }


/*     // Update is called once per frame
    void Update()
    {
        if(lastCollisionTrans)
        {
            newPos.x = Mathf.Lerp( newPos.x, lastCollisionTrans.position.x, lerpTime * Time.deltaTime); 
            newPos.y = lastCollisionTrans.position.y;
            newPos.z = lastCollisionTrans.position.z + offsetZ; 

            transform.position = newPos;
        }
    } */
}
