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
    public int STAR;
    GameObject[] HpUI;
    GameObject[] StarUI;
    public GameObject UIManager;
    
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
        STAR = 0;
        HpUI = GameObject.FindGameObjectsWithTag("Heart");
        StarUI = GameObject.FindGameObjectsWithTag("Star");
        for(int i = 0; i < StarUI.Length; i++)
        {
            StarUI[i].SetActive(false);
        }
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
        yield return new WaitForSeconds(0.3f);
        fixXYZ = transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Jump"))
        {
            rb.AddForce(Vector3.up * 410);
            rb.AddForce(Vector3.forward * 30);
            Debug.Log("Collision 진입");
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
                if (hits[1].collider.gameObject.CompareTag("Box") || hits[1].collider.gameObject.CompareTag("Box_moveable"))
                {
                    return false;
                }
            }
            else
            {
                if(direction ==  Vector3.right)
                {
                    movingX = 0.4f;
                    movingZ = 0;
                } else if (direction == Vector3.left)
                {
                    movingX = -0.4f;
                    movingZ = 0;
                } else if (direction == Vector3.back)
                {
                    movingX = 0;
                    movingZ = -0.4f;
                } else if (direction == Vector3.forward)
                {
                    movingX = 0;
                    movingZ = 0.4f;
                }


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
            UIManager.GetComponent<UIManager>().Show_GameOver();
        }
        HpUI[HP-1].SetActive(false);


    }

    public void StarStatus()
    {
        StarUI[STAR-1].SetActive(true);              
    }
    // @완료된 것
    // 캐릭터 이동
    // 게임 시스템 구상 거의 완료
    // 3. 스타 먹는 모션 만들기

    // @추가 해야 할 것.
    // 1. RayCast로 바닥 정보 확인 후 체력 감소(일부 완료), 점프 처리
    // 1-1. 가시에 닿았을 때 캐릭터 체력 감소 모션
    // 2. Box_Moveable 버그 수정하기

    // 4. 스테이지 완료 만들기(스코어, 체력)
    // 5. 타이틀 화면 만들기
    // 6. 추가 스테이지 만들기

}
