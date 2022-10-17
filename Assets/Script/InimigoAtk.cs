using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


public class InimigoAtk : MonoBehaviour
{
    private GameObject Heroi;
    private NavMeshAgent Agente;
    public int vida = 10;
    public int vidaMax = 10;
    public Image BarraHP;
    /* public GameObject AreaDeAtk;*/

    void Start()
    {
        Agente = GetComponent<NavMeshAgent>();
        Heroi = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        Agente.SetDestination(Heroi.transform.position);
    }
    private void OnTriggerEnter(Collider colisao)
    {
        if (colisao.gameObject.tag == "AreaAtkHeroi")
        {
            Destroy(colisao.gameObject);
            vida = vida - 6;
            BarraHP.fillAmount = 1/(vidaMax/vida);
            if (vida <= 0)
            {
                Destroy(this.gameObject);
            }
        }
        if (colisao.gameObject.tag == "BalaG")
        {
            vida = vida - 6;
            BarraHP.fillAmount = 1 / (vidaMax / vida);
            if (vida <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
    


  /*  public void AtivarAtk()
    {
        AreaDeAtk.SetActive(true);
    }

    public void DesativarAtk()
    {
        AreaDeAtk.SetActive(false);
    }
}*/