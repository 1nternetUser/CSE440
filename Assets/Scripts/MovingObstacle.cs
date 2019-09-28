using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
    public float speedMultiplier = 5.0f;
    public float length = 15.0f;
    public float pointX;

    private Rigidbody2D rb;

 
    private bool PathFinderL = false;

    //Start is called before the first frame update

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       Vector3 point = new Vector3 (pointX + Mathf.PingPong(speedMultiplier * Time.time, length), 0, 0);
       transform.position = point;
    }
}
