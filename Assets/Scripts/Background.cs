using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public float speed;
    public int startIndex;
    public int endIndex;
    public Transform[] sprites;

    float viewHeight;
    float width;

    private void Awake()
    {
        viewHeight = Camera.main.orthographicSize * 2;
        width = viewHeight * Camera.main.aspect;
    }

    void Update()
    {
        Move();
        Scrolling();
    }

    void Move()
    {
        Vector3 curPos = transform.position;
        Vector3 nextPos = Vector3.left * speed * Time.deltaTime;
        transform.position = curPos + nextPos;
    }

    void Scrolling()
    {
        if (sprites[endIndex].position.x < width * (-1))
        {
            Vector3 backSpritePos = sprites[startIndex].localPosition;
            sprites[endIndex].transform.localPosition = backSpritePos + Vector3.right * width;

            int startIndexSave = startIndex;
            startIndex = endIndex;
            endIndex = (startIndexSave - 1 == -1) ? sprites.Length - 1 : startIndexSave - 1;
        }
    }
}
