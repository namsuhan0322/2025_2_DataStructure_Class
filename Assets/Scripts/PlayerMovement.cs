using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;

    private Stack<Vector3> savePos = new Stack<Vector3>();

    void Update()
    {
        float moveZ = 0f;
        float moveX = 0f;

        if (Input.GetKeyDown(KeyCode.W))
        {
            moveZ += 1f;
            savePos.Push(gameObject.transform.position);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            moveZ -= 1f;
            savePos.Push(gameObject.transform.position);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            moveX -= 1f;
            savePos.Push(gameObject.transform.position);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            moveX += 1f;
            savePos.Push(gameObject.transform.position);
        }

        if (Input.GetKeyDown(KeyCode.B) && savePos.Count > 0)
        {
            gameObject.transform.position = savePos.Pop();
        }

        transform.Translate(new Vector3(moveX, 0f, moveZ) * speed);
    }

}
