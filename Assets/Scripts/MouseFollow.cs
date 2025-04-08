using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollow : MonoBehaviour
{
    bool isMove = false;
    Camera mCamera;

    void Start()
    {
        mCamera = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            // 마우스 위치 받아서 Queue에 좌표 넣는 코드
            RaycastHit hit;
            if (Physics.Raycast(mCamera.ScreenPointToRay(Input.mousePosition), out hit))
            {
                if (!isMove)
                {
                    StartCoroutine(MoveToPosition(hit.point + new Vector3(0, 0.5f, 0)));
                }

            }
        }
    }
    IEnumerator MoveToPosition(Vector3 position)
    {
        while ((transform.position - position).magnitude > 0.1f)
        {
            isMove = true;
            transform.position = Vector3.MoveTowards(transform.position, position, Time.deltaTime * 2);
            yield return null;
        }
        isMove = false;
    }
}
