using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clear : MonoBehaviour
{
    public GameObject UIManager;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            other.gameObject.SetActive(false); // 플레이어가 클리어한 후 움직이지 못하게함.
            UIManager.GetComponent<UIManager>().Invisible_Main();
            UIManager.GetComponent<UIManager>().Show_Clear();
        }
    }
}
