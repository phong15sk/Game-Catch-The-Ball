using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    public float moveSpeed = 10;
    float xdirection;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        xdirection = Input.GetAxisRaw("Horizontal");
        float moveStep = xdirection * moveSpeed * Time.deltaTime;
        if ((transform.position.x <= -9 && xdirection == -1) || (transform.position.x >= 9 && xdirection == 1))
        {
            return;
        }

        transform.position += new Vector3(moveStep, 0);
    }
}
