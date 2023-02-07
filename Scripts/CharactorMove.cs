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
    public bool isPressed;
    public int HP;
    GameObject[] HpUI;
    public GameObject gameover;
    [Space]
    [SerializeField] private float speed;
    [SerializeField] private float boxSpeed;
    // Start is called before the first frame update
    void Start()
    {
        fixXYZ = transform.position;
        rb = GetComponent<Rigidbody>();
        isPressed = false;
        HP = 4;
        HpUI = GameObject.FindGameObjectsWithTag("Heart");
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPressed)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow) && RayCheck(Vector3.right))
            {
                isPressed = true;
                playerDir = Vector3.right;
                fixXYZ = transform.position;
                movingX = 0.4f;
                movingZ = 0;
                StartCoroutine(PrepareDelay());

            }
            else if (Input.GetKeyDown(KeyCode.UpArrow) && RayCheck(Vector3.left))
            {
                isPressed = true;
                playerDir = Vector3.left;
                fixXYZ = transform.position;
                movingX = -0.4f;
                movingZ = 0;
                StartCoroutine(PrepareDelay());

            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow) && RayCheck(Vector3.back))
            {
                isPressed = true;
                playerDir = Vector3.back;
                fixXYZ = transform.position;
                movingX = 0;
                movingZ = -0.4f;
                StartCoroutine(PrepareDelay());

            }
            else if (Input.GetKeyDown(KeyCode.RightArrow) && RayCheck(Vector3.forward))
            {
                isPressed = true;
                playerDir = Vector3.forward;
                fixXYZ = transform.position;
                movingX = 0;
                movingZ = 0.4f;
                StartCoroutine(PrepareDelay());
            }
        }


        transform.position = Vector3.MoveTowards(
                transform.position,
                new Vector3(fixXYZ.x + movingX, fixXYZ.y, fixXYZ.z + movingZ),
                speed * Time.deltaTime
                );
        Debug.DrawRay(transform.position, playerDir, Color.red);
    }

    IEnumerator PrepareDelay()
    {
        yield return new WaitForSeconds(0.7f);
        isPressed = false;
    }
    IEnumerator JumpDelay()
    {
        yield return new WaitForSeconds(1.0f);
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Jump"))
        {

            rb.AddForce(Vector3.up * 400);
            Debug.Log("Collision ����");
            StartCoroutine(JumpDelay());
        }

        if (collision.gameObject.CompareTag("Thron"))
        {
            HP--;
            HpStatus();
        }
    }

    bool RayCheck(Vector3 direction)
    {

        RaycastHit[] hits;
        hits = Physics.RaycastAll(transform.position, direction, 0.3f);

        if (hits.Length <= 0)
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
            Debug.Log("1");
            hits = Physics.RaycastAll(transform.position, direction, 0.7f);

            if (hits.Length >= 2)
            {
                if (hits[1].collider.gameObject.CompareTag("Box"))
                {
                    return false;
                }
            }
            else
            {
                Debug.Log("2");
                Vector3 BoxXYZ = hit.collider.transform.position;
                Debug.Log(hit.transform.name + " / " + Time.deltaTime);
                
                hit.collider.gameObject.transform.position = Vector3.MoveTowards(
                    hit.collider.gameObject.transform.position,
                    new Vector3(BoxXYZ.x + movingX, BoxXYZ.y, BoxXYZ.z + movingZ),
                    boxSpeed * Time.deltaTime
                    );
                
                return true;
            }

        }
        Debug.Log(hit.collider.gameObject.name);
        return true;
    }

    void HpStatus()
    {
        if (HP == 1)
        {
            gameover.GetComponent<Gameover>().Show();
        }
        HpUI[HP - 1].SetActive(false);


    }
    // @�Ϸ�� ��
    // ĳ���� �̵�
    // ���� �ý��� ���� ���� �Ϸ�

    // @�߰� �ؾ� �� ��.
    // 1. RayCast�� �ٴ� ���� Ȯ�� �� ü�� ����(�Ϻ� �Ϸ�), ���� ó��
    // 1-1. ���ÿ� ����� �� ĳ���� ü�� ���� ���
    // 2. Box_Moveable ���� �����ϱ�
    // 3. ��Ÿ �Դ� ��� �����
    // 4. �������� �Ϸ� �����(���ھ�, ü��)
    // 5. Ÿ��Ʋ ȭ�� �����
    // 6. �߰� �������� �����

}
