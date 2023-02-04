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

    // @완료된 것
    // 캐릭터 이동
    // 게임 시스템 구상 거의 완료

    // @추가 해야 할 것.
    // 1. RayCast로 바닥 정보 확인 후 데미지 감소, 점프 처리
    // 2. Box_Moveable 버그 수정하기
    // 2-1. 캐릭터 움직일 때 RayCast로 4방향 정보 확인 후 이동 불가할 경우
    // 이동 되지 않도록 하기.(미동 때문에 캐릭터 위치가 이상해짐.)
    // 3. 스타 먹는 모션 만들기
    // 4. 스테이지 완료 만들기(스코어, 체력)
    // 5. 타이틀 화면 만들기
    // 6. 추가 스테이지 만들기

}
