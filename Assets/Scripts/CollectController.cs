using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectController : MonoBehaviour
{

    SynchMovement synchMove;
    private void OnTriggerEnter(Collider other) {

        if( other.CompareTag("Money") )
        {
            other.gameObject.TryGetComponent( out synchMove ); 
            if(synchMove)
            {
                synchMove.lastCollisionTrans = transform; 
                other.GetComponent<Collider>().isTrigger = false; 
                other.GetComponent<Rigidbody>().isKinematic = false; 
                other.gameObject.AddComponent<CollectController>();
                other.tag = "Untagged";

                transform.GetComponent<CollectController>().enabled = false; //disable the current one..
            }
        }

    }
}
