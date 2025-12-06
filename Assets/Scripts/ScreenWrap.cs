using UnityEngine;

public class ScreenWrap : MonoBehaviour
{
    private float leftBound;
    private float rightBound;
    private float topBound;
    private float bottomBound;

    void Start()
    {
        Camera cam = Camera.main;

        float height = 2f * cam.orthographicSize;
        float width = height * cam.aspect;

        leftBound   = -width / 2;
        rightBound  =  width / 2;
        topBound    =  height / 2;
        bottomBound = -height / 2;
    }

    void LateUpdate()
    {
        Vector3 pos = transform.position;

        if (pos.x > rightBound)
            pos.x = leftBound;
        else if (pos.x < leftBound)
            pos.x = rightBound;

        if (pos.y > topBound)
            pos.y = bottomBound;
        else if (pos.y < bottomBound)
            pos.y = topBound;

        transform.position = pos;
    }
}
