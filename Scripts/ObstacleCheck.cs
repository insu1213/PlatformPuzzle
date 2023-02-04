using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCheck : MonoBehaviour
{
    public bool moveable;

    void Start()
    {
        moveable = true;
    }

    void Update()
    {
        
    }

    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("들어왔습니다");
        if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Box"))
        {
            moveable = false;
        } else
        {
            moveable = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("나갔습니다");
        moveable = true;
    }
}
