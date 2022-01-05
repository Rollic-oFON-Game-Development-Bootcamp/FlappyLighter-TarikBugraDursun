using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSpawner : MonoBehaviour
{
    #region Variables
    [SerializeField] private GameObject map1;
    [SerializeField] private GameObject map2;
    [SerializeField] private GameObject obstacle;

    [SerializeField] private Rigidbody2D rb1;
    [SerializeField] private Rigidbody2D rb2;

    [SerializeField] private float backgroundSpeed;

    [SerializeField] private int obstaclesCount;

    private GameObject[] obstacles;

    private float length;

    private float time = 0;
    private int timer = 0;
    #endregion
    void Start()
    {
        rb1.velocity = new Vector2(backgroundSpeed, 0);
        rb2.velocity = new Vector2(backgroundSpeed, 0);

        length = 2 * map1.GetComponent<BoxCollider2D>().size.x;

        obstacles = new GameObject[obstaclesCount];

        for (int i = 0; i < obstacles.Length; i++)
        {
            obstacles[i] = Instantiate(obstacle, new Vector2(-50,-50), Quaternion.identity);
            obstacles[i].GetComponent<Rigidbody2D>().velocity = new Vector2(backgroundSpeed, 0);
        }
    }


    void Update()
    {
        if (map1.transform.position.x <= -length)
        {
            map1.transform.position += new Vector3(length * 2, 0, 0);
        }
        if (map2.transform.position.x <= -length)
        {
            map2.transform.position += new Vector3(length * 2, 0, 0);
        }
        ObstacleSpawner();
        if (!CollisionControl.instance.isGameStart)
        {
            GameFinished();
        }
    }

    private void ObstacleSpawner()
    {
        time += Time.deltaTime;
        if (time>2f)
        {
            time = 0;
            float axisYValue = Random.Range(2.62f, 3.15f);
            obstacles[timer].transform.position = new Vector3(3, axisYValue);
            timer++;
            if (timer>=obstacles.Length)
            {
                timer = 0;
            }
        }
    }

    private void GameFinished() 
    {
        for (int i = 0; i < obstacles.Length; i++)
        {
            obstacles[i].GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            rb1.velocity = Vector2.zero;
            rb2.velocity = Vector2.zero;
        }
    }
}
