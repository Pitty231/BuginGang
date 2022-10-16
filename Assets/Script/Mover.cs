using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mover : MonoBehaviour
{
    public NavMeshAgent agente;
    public Transform posicaoDest;
    public float rotateSpeedMovement = 0.075f;
    float rotateVelocity;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        raycastMover();
    }
    void raycastMover()
    {
        if (Input.GetMouseButton(1))
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity))
            {
                // Movimento
                agente.SetDestination(hit.point);
                posicaoDest.position = hit.point;

                // Rotacao
                Quaternion rotationToLookAt = Quaternion.LookRotation(hit.point - transform.position);
                float rotationY = Mathf.SmoothDampAngle(transform.eulerAngles.y, rotationToLookAt.eulerAngles.y, ref rotateVelocity, rotateSpeedMovement * (Time.deltaTime * 5));

                transform.eulerAngles = new Vector3(0, rotationY, 0);
                {
                }
            }
        }
        void controlAnim()
        {
            if (Vector3.Distance(this.gameObject.transform.position, posicaoDest.position) <= 2)
            {

            }
        }
    }
}
