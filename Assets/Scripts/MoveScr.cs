using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScr : MonoBehaviour
{
    public float Speed = 100f;
    Rigidbody PlayerRGB;
    Vector3 force = Vector3.forward;

    // Start is called before the first frame update
    void Start()
    {
        PlayerRGB = GetComponent<Rigidbody>();   
    }

    void FixedUpdate()
    {
        if(Input.GetMouseButton(0))
        {
            //Get the Ball current ScreeX Pos
            float mouseDelta =  Input.GetAxis("Mouse X");

            if(mouseDelta < 0)
            {
                force = new Vector3(-1f,0, 1);
            }
            else if(mouseDelta > 0)
            {
                force = new Vector3(1f, 0, 1);
            }

            force = Mathf.Abs( mouseDelta ) * force;
            force.z = 1;
        }
        else if( Input.GetMouseButtonUp(0) )
        {
            force = Vector3.forward;
        }

        PlayerRGB.AddForce( Speed * force * Time.fixedDeltaTime );
    }
}
