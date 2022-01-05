using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionControl : MonoBehaviour
{
    #region Variables
    [SerializeField] Text pointText;

    private int point = 0;

    public bool isGameStart = true;
    #endregion

    #region Singleton
    public static CollisionControl instance;

    private void InitSingleton()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    #endregion

    private void Awake()
    {
        InitSingleton();
    }

    private void Update()
    {
        pointText.text = point.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Point")
        {
            point++;
        }
        if (collision.gameObject.tag == "Obstacle")
        {
            isGameStart = false;
        }
    }
}
