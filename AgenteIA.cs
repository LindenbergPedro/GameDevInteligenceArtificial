using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class AgenteIA : MonoBehaviour
{
    [Header("-------------------Locais------------------")]
    public NavMeshAgent agente;
    public Transform player;
    public Transform Municao;
    public Transform localBase;
    [Header("-------------------Movimentação-----------------")]
    public Transform[] waypoints;
    public int flagWaypoint = 0;
    [Header("-------------Quantidades-----------")]
    public float HP;
    public float QtMunicao;
    [Header("--------------Estados-------------")]
    public EstaodoFSM estadoAtual;
    public Transform eye;
    public float alcance;
    public float velocityrotate;
    public float temporotacao;
    [Header("----------------Distancias sobre os locais------------------")]
    public float distancia;
    public float distanciabase;
    public float distanciamunicao;
    public bool taperto;
    [Header("--------------------------ARMA----------------")]
    public bool podeatirar;
    public GameObject bala;
    public GameObject municaoinstanciada;
    public Transform posicao;
    public Transform posicaomunicao;
    public float VelocidadeDisparo;
    public float TimerArma;
    private bool podeDisparar;
    public bool Municaodestruida;

    void Start()
    {
        podeDisparar = false;
        HP = 100;
        QtMunicao = 2;
        agente = GetComponent<NavMeshAgent>();
        alcance = 10;
        velocityrotate = 100;
        Municaodestruida = false;
    }

    
    void Update()
    {
        // CALCULO EUCARISTICA PARA SABER A DISTANCIA DE UM PONTA A AO B
        distancia = Vector3.Distance(agente.transform.position, player.transform.position);
        // DISTANCIA DO PLAYER E DO AGENTE
        distanciabase = Vector3.Distance(agente.transform.position, localBase.transform.position);
        // DISTANCIA DO AGENTE E DO BASE
        distanciamunicao = Vector3.Distance(agente.transform.position, Municao.transform.position);
        // DISTANCIA DO AGENTE E DO MUNIÇAO
        

        print(distancia + " do Player");

        estadoAtual.AtualizarEstado(this); //ATUALIZAÇAO DOS ESTADO A CADA FRAME

        if(distanciabase <= 5) // VERIFICA A DISTANCIA DO AGENTE COM A BASE
        {
            HP = 100; // FAZ COM QUE O HP SEJA RECUPERADO
        }
        if(distanciamunicao <= 2)
        {
            QtMunicao = 2;
            Municaodestruida = true;
            Destroy(Municao.gameObject); // UTILIZEI A DISTANCIA PARA FAZER COM QUE RECARREGE A MUNIÇAO E SEJA DESTROIDO
        }

        // CONTADOR DE TEMPO
        TimerArma += Time.deltaTime;
        if(TimerArma >= 2)
        {
            podeDisparar = true;
        } else podeDisparar = false;

        if(Municaodestruida) // Essa condiçao faz com que a muniçao seja Intanciada
        {
            GameObject instaciamunicao;
            instaciamunicao = Instantiate(municaoinstanciada,posicaomunicao.position, Quaternion.identity) as GameObject;
            Municaodestruida = false;
            Municao = instaciamunicao.transform;
        }

    }
    public void Atirar() // METODO QUE FAZ O AGENTE ATIRAR
    {
        if(podeDisparar) // A CADA 2 SEG FAZ O PODE ATIRAR FICAR VERDADEIRO
        {
            GameObject disparo; // PEGA O GAME OBJECT E DISPARA
            disparo = Instantiate(bala, posicao.position, Quaternion.identity) as GameObject; // SOLTA O PREFAB NA SCENA
            disparo.GetComponent<Rigidbody>().AddForce(posicao.forward*VelocidadeDisparo); // ADD UMA FORÇA NO PREFAB
            Destroy(disparo,2); // DESTROI O PREFAB DEPOIS DE 2 SEGUNDOS
            TimerArma = 0; // RESTART O TIMER
            QtMunicao--; // DIMINUI A MUNIÇAO A CADA TIRO.
        }
    }
  
}
