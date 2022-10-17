using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mover : MonoBehaviour
{
    public NavMeshAgent agente;
    public Vector3 posicaoDest;
    public float rotateSpeedMovement = 0.075f;
    float rotateVelocity;
    public Animator animator;
    public GameObject bala;
    public GameObject Spawn;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        raycastMover();
        controlAnim();
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
                posicaoDest = hit.point;
            }
        }

    }
    void controlAnim()
    {
        if (Vector3.Distance(this.gameObject.transform.position, posicaoDest) <= 0.5f)
        {
            animator.SetBool("Corre", false);
        }
        else
        {
            animator.SetBool("Corre", true);
        }
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity))
            {
                transform.LookAt(hit.point);
                Instantiate(bala,Spawn.transform.position, Spawn.transform.rotation);
            }
        }
    }
}
