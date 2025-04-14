using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveQueue : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Queue<Vector3> moveQueue = new Queue<Vector3>();
    private bool isMoving = false;

    void Update()
    {
        // 마우스 우클릭으로 바닥 클릭 위치 큐에 저장
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                moveQueue.Enqueue(hit.point);
            }
        }

        // 이동 중이 아니고 큐에 위치가 있을 때 이동 시작
        if (!isMoving && moveQueue.Count > 0)
        {
            Vector3 nextPos = moveQueue.Dequeue();
            StartCoroutine(MoveToPosition(nextPos));
        }
    }

    IEnumerator MoveToPosition(Vector3 targetPos)
    {
        isMoving = true;
        // y 값은 현재 위치로 고정 (바닥면 이동용)
        targetPos.y = transform.position.y;

        while (Vector3.Distance(transform.position, targetPos) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            yield return null;
        }

        transform.position = targetPos;
        isMoving = false;
    }
}
