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
        if(Physics.Raycast(transform.position, Vector3.up, out hit, 0.4f))
        {
            if(hit.collider.gameObject.CompareTag("Player"))
            {
                Rigidbody hitRigid = hit.collider.gameObject.GetComponent<Rigidbody>();
                hitRigid.AddForce(Vector3.up * 10f);
            }
            StartCoroutine(RayDelay());
        }
    }

    IEnumerator RayDelay()
    {
        yield return new WaitForSeconds(2.0f);
    }
}

