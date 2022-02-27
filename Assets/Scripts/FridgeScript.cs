using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class FridgeScript : MonoBehaviour
{
    public GameObject MilkPrefab;
    public float AddMilkDelay = .2f;

    private bool addNewMilk = false;
    private Transform holderMilk;
    BoxScr boxScr;

    private void Start() {
        addNewMilk = false;
        StartCoroutine( AddNewMilk() );
    }

    // Update is called once per frame    
    void Update() {  

        if (Input.GetMouseButtonDown(0)) {  

            Debug.Log("Mouse Down");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);  
            RaycastHit hit;  
            if (Physics.Raycast(ray, out hit)) {  
        
                Debug.Log("Touched:" + hit.transform.ToString());
                //Select stage    
                if (hit.transform.CompareTag("Door")) {  
                    hit.transform.DOLocalRotate( new Vector3(0, -100f, 0), 1f ).SetEase( Ease.OutQuad );
                }  

                if( hit.transform.CompareTag("Box") )
                {
                    boxScr = hit.transform.GetComponent<BoxScr>(); 
                    if(boxScr.IsOpen)
                        hit.transform.DOLocalRotate( new Vector3(0,0,0), .2f).OnComplete( ()=> { hit.transform.DOLocalMoveX ( 0.119913f, 1 ); boxScr.IsOpen = false; } );
                    else
                        hit.transform.DOLocalMoveX ( -1.35f, 1 ).OnComplete( ()=> hit.transform.DOLocalRotate( new Vector3(0,0,25), .5f).OnComplete( ()=> boxScr.IsOpen = true ));
                }

                if( hit.transform.CompareTag("Holder") )
                {
                    holderMilk = hit.transform;                    
                }

            }  
        }
        else if( Input.GetMouseButton(0) )
        {
            if(holderMilk)
            {
                addNewMilk = true;
            }
        }
        else if( Input.GetMouseButtonUp(0) )
        {
            addNewMilk = false;
            holderMilk = null;
        }
    }

    IEnumerator AddNewMilk()
    {
        yield return null;
        GameObject newMilk;
        int childIdx = 0;
        while (true)
        {
            yield return null;
            if( addNewMilk && holderMilk)
            {
                if(holderMilk && holderMilk.childCount < 5)
                {
                    childIdx = holderMilk.childCount;
                    newMilk = Instantiate( MilkPrefab, holderMilk);
                    newMilk.transform.localPosition = new Vector3( childIdx *.25f, 0, 0 );
                }
                yield return new WaitForSeconds(AddMilkDelay);
            }
        }
    }
}
