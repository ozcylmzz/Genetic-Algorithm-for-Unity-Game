using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class init : MonoBehaviour
{
    public PlayerMovement[] movement;
    public Rigidbody[] rb;
    public Rigidbody q;
    public float forwardForce;  // Variable that determines the forward force
    public float sidewaysForce;  // Variable that determines the sideways force
    public int count = 0, player_size = 20;
    public static int k = 0;
    public string[] array = new string[20];
    public int j = 0, i, counta = 0, countb = 0;
    public int move_count = 274;


    // Start is called before the first frame update
    void Start()
    {

        GameObject name;

        //rb ilklendir
        for (i = 0; i < player_size; i++)
        {
            name = GameObject.Find("Player (" + i + ")");

            rb[i] = name.GetComponent<Rigidbody>();
            movement[i] = name.GetComponent<PlayerMovement>();
            //print(rb[i].name);
            if (rb[i] == null)
                print("null");
        }

        array = FindObjectOfType<Genetic>().createPath();
        j = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (j < move_count)
        {

            if (count < 1)
            {
                count++;
            }
            else
            {
                count = 0;
                for (i = 0; i < player_size; i++)
                {

                    rb[i].AddForce(0, 0, forwardForce * Time.deltaTime * 10);
                    if (FindObjectOfType<Genetic>().isAlive[i] == true)
                    {
                        FindObjectOfType<Genetic>().score[i,0] = (int)rb[i].transform.localPosition.z;
                    }
                    
                    if (FindObjectOfType<Genetic>().isAlive[i] == false)
                    {
                        count++;
                    }
                    if (count == FindObjectOfType<init>().player_size)
                    {

                        FindObjectOfType<Genetic>().iteration++;
                        print("Iteration:"+FindObjectOfType<Genetic>().iteration);
                        FindObjectOfType<Genetic>().isAlive = FindObjectOfType<Genetic>().checkPath();
                        FindObjectOfType<Genetic>().array = FindObjectOfType<Genetic>().selection();
                        FindObjectOfType<Genetic>().array = FindObjectOfType<Genetic>().crossover();
                        FindObjectOfType<Genetic>().array = FindObjectOfType<Genetic>().mutation();
                        FindObjectOfType<GameManager>().EndGame();

                        if(FindObjectOfType<Genetic>().iteration == FindObjectOfType<Genetic>().max_iteration)
                        {
                            //destroy
                            Application.Quit();
                        }
                    }
                    if (array[i][j] == 'd')  // If the player is pressing the "d" key
                    {
                        // Add a force to the right
                        rb[i].AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
                        counta++;
                    }

                    if (array[i][j] == 'a') // If the player is pressing the "a" key
                    {
                        // Add a force to the left
                        rb[i].AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
                        countb++;
                    }

                    if (array[i][j] == 'w') // If the player is pressing the "a" key
                    {
                        rb[i].angularVelocity = Vector3.zero;

                    }

                    if (rb[i].transform.localPosition.y < 1f)
                    {
                        movement[i].enabled = false;
                        FindObjectOfType<Genetic>().isAlive[i] = false;

                    }

                }
                j++;


            }
        }

    }
}
