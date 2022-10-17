using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mae : MonoBehaviour
{
    public GameObject Inimigo1;
    public int onda = 1;
    public float tempo;
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        if (onda < 10)
        {
            tempo += Time.deltaTime;
            if (tempo > 2)
            {
                tempo = 0;
                int numero = onda * 1;
                for (int i = 0; i < numero; i++)
                {
                    Instantiate(Inimigo1, transform.position, Quaternion.identity);
                }
                onda++;

            }
        }
    }
}