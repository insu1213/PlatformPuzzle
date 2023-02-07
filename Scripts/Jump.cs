using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //if(Physics.Raycast(transform.position, Vector3.up, out hit, 1.0f))
        //{
        //    if(hit.collider.gameObject.CompareTag("Player"))
        //    {
        //        Transform hitTransform = hit.collider.gameObject.GetComponent<Transform>();
        //        hitTransform.transform.position = Vector3.MoveTowards(
        //            hitTransform.transform.position,
        //            Vector3.up * 10,
        //            1.5f * Time.deltaTime
        //            );
        //    }
        //    StartCoroutine(RayDelay());
        //}
    }

    IEnumerator RayDelay()
    {
        yield return new WaitForSeconds(2.0f);
    }
}

