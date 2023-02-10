using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameObject.Find("Player").GetComponent<CharactorMove>().STAR++;
            transform.gameObject.SetActive(false);
            GameObject.Find("Player").GetComponent<CharactorMove>().StarStatus();
        }
        
    }
}
