using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour
{
    public NavMeshAgent agent;

    public float rotateSpeedMovement = 0.075f;
    public float rotateVelocity;

    Stats statsScripts;

    float tempoDano;
    bool takeDamage;

    // Start is called before the first frame update
    void Start()
    {
        statsScripts = GetComponent<Stats>();  
        agent = gameObject.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Mover();
        
    }

    void Mover()
    {
        //When pressing the left mouse button
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;

            //Checking if the raycast shot hits something that uses the navmesh system.
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity))
            {
                if (hit.collider.tag == "Floor")
                {
                    //MOVEMENT
                    agent.SetDestination(hit.point);                   
                    agent.stoppingDistance = 0;

                    //ROTATION
                    Quaternion rotationToLookAt = Quaternion.LookRotation(hit.point - transform.position);
                    float rotationY = Mathf.SmoothDampAngle(transform.eulerAngles.y,
                        rotationToLookAt.eulerAngles.y,
                        ref rotateVelocity,
                        rotateSpeedMovement * (Time.deltaTime * 5));

                    transform.eulerAngles = new Vector3(0, rotationY, 0);
                }

            }

        }
    }
   
}
