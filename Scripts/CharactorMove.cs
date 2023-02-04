using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactorMove : MonoBehaviour
{
    Vector3 fixXYZ;
    float movingX;
    float movingZ;
    Rigidbody rb;
    private RaycastHit hit;
    Vector3 playerDir;
    // Start is called before the first frame update
    void Start()
    {
        fixXYZ = transform.position;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow) && RayCheck(Vector3.right))
        {
            playerDir = Vector3.right;
            fixXYZ = transform.position;
            movingX = 0.4f;
            movingZ = 0;
            StartCoroutine(PrepareDelay());
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) && RayCheck(Vector3.left))
        {
            playerDir = Vector3.left;
            fixXYZ = transform.position;
            movingX = -0.4f;
            movingZ = 0;
            StartCoroutine(PrepareDelay());
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && RayCheck(Vector3.back))
        {
            playerDir = Vector3.back;
            fixXYZ = transform.position;
            movingX = 0;
            movingZ = -0.4f;
            StartCoroutine(PrepareDelay());
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && RayCheck(Vector3.forward))
        {
            playerDir = Vector3.forward;
            fixXYZ = transform.position;
            movingX = 0;
            movingZ = 0.4f;
            StartCoroutine(PrepareDelay());
        }

        transform.position = Vector3.MoveTowards(
                transform.position,
                new Vector3(fixXYZ.x + movingX, fixXYZ.y, fixXYZ.z + movingZ),
                1.5f * Time.deltaTime
                );
        Debug.DrawRay(transform.position, playerDir, Color.red);
    }
    
    IEnumerator PrepareDelay()
    {
        yield return new WaitForSeconds(1.3f);
    }

    bool RayCheck(Vector3 direction)
    {
        
        RaycastHit[] hits;
        hits = Physics.RaycastAll(transform.position, direction, 0.3f);
        
        if(hits.Length <= 0)
        {
            return true;
        }
        RaycastHit hit = hits[0];

        if (hit.collider.gameObject.CompareTag("Wall") ||
            hit.collider.gameObject.CompareTag("Box"))
        {
            return false;
        }


        else if (hit.collider.gameObject.CompareTag("Box_moveable"))
        {
            hits = Physics.RaycastAll(transform.position, direction, 0.7f);
            if (hits.Length >= 2)
            {
                if (hits[1].collider.gameObject.CompareTag("Box"))
                {
                    return false;
                } else
                {
                    return true;
                }
            }
        }
        Debug.Log(hit.collider.gameObject.name);
        return true;
    }

    // @�Ϸ�� ��
    // ĳ���� �̵�
    // ���� �ý��� ���� ���� �Ϸ�

    // @�߰� �ؾ� �� ��.
    // 1. RayCast�� �ٴ� ���� Ȯ�� �� ������ ����, ���� ó��
    // 2. Box_Moveable ���� �����ϱ�
    // 2-1. ĳ���� ������ �� RayCast�� 4���� ���� Ȯ�� �� �̵� �Ұ��� ���
    // �̵� ���� �ʵ��� �ϱ�.(�̵� ������ ĳ���� ��ġ�� �̻�����.)
    // 3. ��Ÿ �Դ� ��� �����
    // 4. �������� �Ϸ� �����(���ھ�, ü��)
    // 5. Ÿ��Ʋ ȭ�� �����
    // 6. �߰� �������� �����

}
