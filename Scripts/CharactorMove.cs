using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactorMove : MonoBehaviour
{
    Vector3 fixXYZ;
    float movingX;
    float movingZ;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        fixXYZ = transform.position;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            fixXYZ = transform.position;
            movingX = 0.4f;
            movingZ = 0;
            StartCoroutine(PrepareDelay());
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            fixXYZ = transform.position;
            movingX = -0.4f;
            movingZ = 0;
            StartCoroutine(PrepareDelay());
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            fixXYZ = transform.position;
            movingZ = -0.4f;
            movingX = 0;
            StartCoroutine(PrepareDelay());
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            fixXYZ = transform.position;
            movingZ = 0.4f;
            movingX = 0;
            StartCoroutine(PrepareDelay());
        }

            transform.position = Vector3.MoveTowards(
                    transform.position,
                    new Vector3(fixXYZ.x + movingX, fixXYZ.y, fixXYZ.z + movingZ),
                    0.002f
                    );
    }
    IEnumerator PrepareDelay()
    {
        yield return new WaitForSeconds(1.0f);
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
