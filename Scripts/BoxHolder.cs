using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BoxHolder : MonoBehaviour
{
    static int box_len;
    public TMP_Text txt;
    public GameObject op_star;
    // Start is called before the first frame update
    void Start()
    {
        box_len = 0;
        op_star.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("½ÇÇàµÊ1");
        Debug.Log(other.gameObject.tag);
        if(other.gameObject.tag == "Box_moveable")
        {
            Debug.Log("½ÇÇàµÊ2");
            other.gameObject.SetActive(false);
            box_len++;
            txt.text = box_len + " / 3";
            if (box_len == 3)
            {
                Debug.Log("½ÇÇàµÊ3");
                txt.color = Color.yellow;
                op_star.SetActive(true);
            }
            else
            {
                txt.color = Color.red;
            }
        }
    }

}
