using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    public float noteSpeed;
    public void Update()
    {
        Vector3 translate=new Vector3(0, noteSpeed*Time.deltaTime,0);
        transform.position += translate;
    }
    public void SetVel(float f)
    {
        noteSpeed = (f/60f);
    }
}
