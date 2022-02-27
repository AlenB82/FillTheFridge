using UnityEngine;

public class MyCursor : MonoBehaviour 
{
    public float zOffset = 0f;
    public LayerMask layerMask;

    Vector3 mousePos = Vector3.zero;
    Ray ray;
    RaycastHit hit;


    void Update () 
	{
        if (this.gameObject.activeInHierarchy)
        {
            mousePos = Input.mousePosition;
            mousePos.y += zOffset;

            ray = Camera.main.ScreenPointToRay(mousePos);
            
            if (Physics.Raycast(ray, out hit, float.MaxValue, layerMask))
            {
                transform.position = hit.point;
                transform.rotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
            }
        }
	}
}
