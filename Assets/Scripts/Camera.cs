using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private Transform player;
    private Vector3 tempPos;

    [SerializeField]
    private float minX, maxX;  //so that you can set the minx and maxX in the inspector 

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform; // look for a object with tag player,and get its transform position
        //Debug.Log("The game object index is" + GameManager.instance.CharIndex);

    }

    // Update is called once per frame
    void LateUpdate()  //Lateupdate is called after all calculation in update is finished, the object is moved in update funtion 
    {
        if (player == null)
        {
            return; //if player is dead, then it will return nothing and get out of the functions
        }
        tempPos = transform.position; //currect position of the camera
        tempPos.x = player.position.x; //set the x value to the currect object position

        if (tempPos.x < minX) // test where is the camera position out of bound 
        {
            tempPos.x = minX;
        }
        if (tempPos.x > maxX)
        {
            tempPos.x = maxX;
        }
        transform.position = tempPos; //assign back to the camera position

    }
}
