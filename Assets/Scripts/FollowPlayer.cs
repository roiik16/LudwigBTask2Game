using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    public Transform player;
    public Vector3 offset;

	// Update is called once per frame
	void Update ()
    {

        /*
         * Vector3 pos = camera position;
         * pos = player.position + offset;
         * pos.x = 0
         * transform.position = pos;
         */

        transform.position = player.position + offset;
        
	}
}
