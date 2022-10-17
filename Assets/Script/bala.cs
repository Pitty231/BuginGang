using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class bala : MonoBehaviour
{
    public float speed;
    public float damage;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        rb.AddForce(transform.forward * speed, ForceMode.Force);

        {
            transform.position = new(transform.position.x, transform.position.y - 0.5f * Time.deltaTime, transform.position.z);
        }
    }


    public void DisableBillBoard()
    {

        //Adicionar método para rotacionar Y pelo valor passado
        {
        }
    }
}
