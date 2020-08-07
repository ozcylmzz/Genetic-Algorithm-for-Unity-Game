using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    public PlayerMovement[] movement;
    public int player_size = 20, i;

    void OnCollisionEnter(Collision collisionInfo)
    {

        // We check if the object we collided with has a tag called "Obstacle".
        if (collisionInfo.collider.tag == "Player")
        {
            string s = collisionInfo.collider.name;
            s = s.Split('(')[1];
            name = s.Split(')')[0];
            int index = int.Parse(name);
            movement[index].enabled = false;
            FindObjectOfType<Genetic>().isAlive[index] = false;
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        GameObject name;

        //rb ilklendir
        for (i = 0; i < player_size; i++)
        {
            name = GameObject.Find("Player (" + i + ")");
            movement[i] = name.GetComponent<PlayerMovement>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
