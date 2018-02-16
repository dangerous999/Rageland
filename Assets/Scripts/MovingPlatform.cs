using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {

    public GameObject platform;
    public float movespeed;
    public Transform CurrentPoint;
    public Transform[] points;
    public int pointSelection;
    private Player player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        CurrentPoint = points[pointSelection];
    }
    void Update()
    {
        platform.transform.position = Vector3.MoveTowards(platform.transform.position, CurrentPoint.position, movespeed * Time.deltaTime);

        if (platform.transform.position == CurrentPoint.position)
        {
            pointSelection++;

            if(pointSelection== points.Length)
            {
                pointSelection = 0;
            }
            CurrentPoint = points[pointSelection];

        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        
        if(other.transform.tag == "Player" )
        {
            player.transform.SetParent(this.transform);
        }
    }
}
