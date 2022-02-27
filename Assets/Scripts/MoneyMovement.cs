using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyMovement : MonoBehaviour
{
    [Header("Settings")]
    public float mSpeed = 500f;


    #region PRIVAT VARS
    Rigidbody localRgb;
    Transform localTrans;
    Vector3 force = Vector3.forward; 
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        localRgb = GetComponent<Rigidbody>();
        localTrans = GetComponent<Transform>();
    }

    private void FixedUpdate() {

        if( Input.GetMouseButton(0) ) //Holding down Finger or Mouse..
        {
            float mouseDelta = Input.GetAxis("Mouse X"); 

            if(mouseDelta < 0)
            {
                force = new Vector3(-1f, 0, 1f); 
            }
            else if( mouseDelta > 0 )
            {
                force = new Vector3(1f, 0, 1f); 
            }

            force = Mathf.Abs(mouseDelta) * force; 
            force.z = 1f; //Always move forward..
        }
        else if( Input.GetMouseButtonUp(0) ) //If the Finger or Mouse is released, we stop moveing left/right.. only forward..
        {
            force = Vector3.forward; 
        }

        localRgb.AddForce( mSpeed * force * Time.fixedDeltaTime ); 
    }

}
