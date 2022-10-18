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
    public GameObject BalaG;
    public GameObject Peido;
    public bool PoderUsado = false;
    public float TempoPeido;


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
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Instantiate(BalaG, Spawn.transform.position, Spawn.transform.rotation);

        }if (PoderUsado == false)
        {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Peido.SetActive(true);
            PoderUsado = true;  
            
        }
            
        }
        else
        {
            TempoPeido += Time.deltaTime;
            if (TempoPeido >= 4)
            {
                Peido.SetActive(false);
            }
            if (TempoPeido >= 10)
            {
                TempoPeido = 0;
                PoderUsado = false;
            }
        }
    }
}
