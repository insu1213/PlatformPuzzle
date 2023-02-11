using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BoxHolder : MonoBehaviour
{
    static int box_len;
    public TMP_Text txt;
    // Start is called before the first frame update
    void Start()
    {
        box_len = 0;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("�����1");
        if(other.gameObject.tag == "Box_moveable")
        {
            Debug.Log("�����2");
            other.gameObject.SetActive(false);
            box_len++;
            txt.text = box_len + " / 3";
            if (box_len == 3)
            {
                Debug.Log("�����3");
                txt.color = Color.yellow;
            }
            else
            {
                txt.color = Color.red;
            }
        }
    }
}
