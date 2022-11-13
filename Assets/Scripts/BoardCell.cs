using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardCell : MonoBehaviour
{
    public CardSCOB card;
    public GameObject obj, tmp;
    bool isMine;

    public void SetisMine( bool isMine ){ this.isMine = isMine; }

    public void ResetCell()
    {
        if(tmp)
            Destroy(tmp);

        obj = tmp;
    }

    void OnMouseDown() 
    {
        if(!tmp || !isMine)
            return;
            
        obj = tmp;
        tmp.GetComponent<Collider>().enabled = true;
    }

    void OnMouseEnter() 
    {
        if (obj || !isMine)
            return;

        tmp = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        tmp.GetComponent<Collider>().enabled = false;

        tmp.transform.SetParent(transform);
        tmp.transform.position = transform.position + Vector3.up;
    }
    
    private void OnMouseExit() 
    {
        if(obj || !isMine)
            return;
        
        Destroy(tmp);
    }
}
