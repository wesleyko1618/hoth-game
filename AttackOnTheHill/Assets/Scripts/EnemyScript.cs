using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    Vector3 distanceToPlayer;
    public GameObject player;
    public float distance;
    public float minDistance = 35;
    public float speed = 10f;
    private void Start()
    {
        player = GameObject.Find("PlayerController");
       
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = player.transform.position;
        distanceToPlayer = playerPos - transform.position;

        distance = Mathf.Sqrt(distanceToPlayer.x * distanceToPlayer.x + distanceToPlayer.y * distanceToPlayer.y + distanceToPlayer.z * distanceToPlayer.z);

        if(distance < minDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, playerPos, speed * Time.deltaTime);
            transform.LookAt(playerPos);
        }

    }
}
