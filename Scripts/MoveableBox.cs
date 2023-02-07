using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveableBox : MonoBehaviour
{
    public bool moveable;
    
    void Start()
    {
        moveable = true;
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }
}
