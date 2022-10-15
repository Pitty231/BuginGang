using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerAnimator : MonoBehaviour
{
    NavMeshAgent agente;
    public Animator anim;

    float motionSmoothTime = 1f;

    // Start is called before the first frame update
    void Start()
    {
        agente = gameObject.GetComponent<NavMeshAgent>();      
    }

    // Update is called once per frame
    void Update()
    {
        float speed = agente.velocity.magnitude / agente.speed;
        anim.SetFloat("Speed", speed, motionSmoothTime, Time.deltaTime);
    }
}
