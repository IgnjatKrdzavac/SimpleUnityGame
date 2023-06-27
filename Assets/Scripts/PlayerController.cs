using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
     public float forwardSpeed;
    public float horizontalSpeed;

    private int desiredLane = 1; // 0: levo, 1: pravo, 2: desno
    public float laneDistance = 4; // distanca između dve linije

    private Vector3 targetPosition;

    void Start()
    {
        targetPosition = transform.position;
    }

    void Update(){
    // Kretanje loptice unaprijed
    Vector3 forwardMovement = transform.forward * forwardSpeed * Time.fixedDeltaTime;
    transform.position += forwardMovement;

    // Kalkulacija skretanja
    if (Input.GetKeyUp(KeyCode.RightArrow))
    {
        if (desiredLane == 0)
        {
            desiredLane = 1; // Skreće u desnu traku
        }
        else if (desiredLane == 1)
        {
            desiredLane = 2; // Skreće u najdešnju traku
        }
    }
    else if (Input.GetKeyUp(KeyCode.LeftArrow))
    {
        if (desiredLane == 1)
        {
            desiredLane = 0; // Skreće u najlevlju traku
        }
        else if (desiredLane == 2)
        {
            desiredLane = 1; // Skreće u levu traku
        }
    }

    // Određivanje ciljne pozicije na osnovu trenutne trake
    float targetLaneX = (desiredLane - 1) * laneDistance;
    targetPosition = new Vector3(targetLaneX, transform.position.y, transform.position.z);

    // Provera da li je lopta već na ciljnoj poziciji
    if (transform.position != targetPosition)
    {
        // Kretanje ka ciljnoj poziciji
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, horizontalSpeed * Time.fixedDeltaTime);
    }

    
}


 void OnTriggerEnter(Collider other)
    {

        
        if (other.CompareTag("Barrier"))
        {
            
            PlayerManager.gameOver = true;
        }
    }

}

