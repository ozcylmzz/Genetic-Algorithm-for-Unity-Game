using UnityEngine;

public class FollowPlayer : MonoBehaviour {

	public Transform player;    // A variable that stores a reference to our Player

    public Vector3 offset,temp;      // A variable that allows us to offset the position (x, y, z)
                                //forwardForce * Time.deltaTime*3
                                // Update is, called once per frame
    public float forwardForce;

    private void Start()
    {
        temp = new Vector3(0, 0 ,24f * Time.deltaTime);
        
    }
    void Update () {
        // Set our position to the players position and offset it
        //transform.position = player.position + offset;
        transform.position += temp;
        
    }
}
