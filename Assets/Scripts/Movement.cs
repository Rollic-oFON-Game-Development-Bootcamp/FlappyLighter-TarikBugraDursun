using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    #region Variables
    Rigidbody2D rb;
    bool isInput;
    #endregion
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (Input.GetMouseButton(0) && CollisionControl.instance.isGameStart)
        {
            isInput = true;
        }
        else 
        {
            isInput = false;
        }
    }
    private void FixedUpdate()
    {
        if (isInput)
        {
            rb.velocity = new Vector2(0, 0);
            rb.AddForce(new Vector2(0, 300));
        }
    }
}
