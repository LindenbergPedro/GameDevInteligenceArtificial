using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Inimigo : MonoBehaviour
{
    public NavMeshAgent agente; // Serve Para pegar o Agent Nav Mesh
    public Transform player; // Pega a posiçao do player
    public Transform[] waypoints; // Define alguns pontos a serem marcados/pecorridos
    public int flagWaypoint = 0; // Saber qual ponto A IA se localiza
    public Transform localBase; // Define o Local da base 
    public float HP; // Define o tanto de Vida que A Ia tem
    public Estado estadoAtual; // Define o Estado que se encontra
    public Transform eye; // O olho do agente IA
    public float alcance; // O alcance dessa visao
    public float velocityrotate; // Velocidade de uma rotaçao, quando ele para.
    public float temporotacao; // Tempo Parado em rotaçao.
    public float distancia; // Distancia que A agente Ia tera do Player
    // ----------------------------------------------------------------------------------------
    // No Start, definie o HP, O estado inicial. o Alcance e a velocidade da rotaçao
    void Start()
    {

        HP = 100;
        agente = GetComponent<NavMeshAgent>();
        //player = GetComponent<Transform>();
        estadoAtual = Estado.Patrulhando;
        alcance = 30;
        velocityrotate = 100;
    }
    //---------------------------------------------------------------------------------------------
    // No Update, Calculo a Distancia do Agente Ia sobre o Player
    // Utilizo um Switch para definir os Estados que se encontram e quais Açoes devem tomar
    void Update()
    {
        distancia = Vector3.Distance(agente.transform.position, player.transform.position);
        print(distancia + " do Player");
        switch(estadoAtual)
        {
            // ELE VAI DO WEYPOINT 0 a 1 ou mais.
            case Estado.Patrulhando:
                patrulha();
                visao();
                ChecaVida();
                break;
                // HP FOR MENOR QUE < 40
            case Estado.CorrendoParaBase:
                correbase();
                visao();
                ChecaVida();
                break;
            case Estado.perseguindo:
                Perseguindo();
                break;
            case Estado.gira:
                girando();
                visao();
                break;

        }
        
    }
    //-------------------------------------------------------------------------------------
    // ENUMERANDO OS ESTADOS QUE SE ENCONTRAM PRESENTE.
    public enum Estado
    {
        Patrulhando,
        CorrendoParaBase,
        perseguindo,
        gira
    }
    //-------------------------------------------------------------------------------------
    // AÇAO / METODO para que desenvolva uma Patrulha, ele ira pegar os Waypoints e ira fazer com que a
    // IA va para cada destino, com isso fiz uma condiçao que faz com que os waypoints pecorridos se alterem
    void patrulha()
    {
        if(agente.remainingDistance <= agente.stoppingDistance && !agente.pathPending)
            {
            
                if(flagWaypoint + 2 > waypoints.Length)
                {
                    flagWaypoint = 0;
                }
                else
                {
                    flagWaypoint++;
                    
                }
                estadoAtual = Estado.gira;
            }
            agente.SetDestination(waypoints[flagWaypoint].position);
    }
    //-------------------------------------------------------------------------------------
    // A açao que manda a Agente Ia para Base
    void correbase()
    {
        agente.SetDestination(localBase.position);
    }
    //-------------------------------------------------------------------------------------
    // METODO QUE FAZ COM QUE O AGENTE IA LOCALIZE COISAS COM SUA VISAO.
    // UTILIZEI UM RAYCAST, NA QUAL, SEMPRE TA MIRANDO PRA FRENTE E CASO, O PLAYER TOQUE
    // NESSA VISAO, O AGENTE IA MUDARA O ESTADO PARA PERSEGUINDO
    void visao()
    {
        Debug.DrawRay(eye.position, eye.forward * alcance, Color.yellow);
        RaycastHit hit;
        if(Physics.Raycast(eye.position, eye.forward, out hit, alcance))    
        {
            if(hit.collider.CompareTag("Player"))
            {
                estadoAtual = Estado.perseguindo;
            }
            
        }

    }
    //-------------------------------------------------------------------------------------
    void girando()
    {
        transform.Rotate(0,velocityrotate * Time.deltaTime,0);
        temporotacao += Time.deltaTime;
        if(temporotacao > 5)
        {
            temporotacao = 0;
            estadoAtual = Estado.Patrulhando;
        }
    }
    //-------------------------------------------------------------------------------------
    // Metodo que checa a Vida do Agente IA e faz com que, ele muda o ESTADO DE ACORDO COM A VIDA
    // SE A VIDA FOR MENOR QUE 25 ELE IRA CORRER PARA A BASE.
    void ChecaVida()
    {
        if(HP > 25)
        {
            if(estadoAtual == Estado.Patrulhando)
            {
                estadoAtual = Estado.Patrulhando;
            }
            else 
            {
                estadoAtual = Estado.perseguindo;
            }
            
        }
        else estadoAtual = Estado.CorrendoParaBase;
    }
    //-------------------------------------------------------------------------------------
    // Açao que faz com que o Agente IA persiga o Player, se ele for visto pela IA
    // Foi definido uma distancia minima para que, quando ele for Visto, a Ia va em destino ao Player
    // Se a distancia for menor 40, ele volta a patrulha e desiste da perseguiçao.
    void Perseguindo()
    {
        if(distancia > 40) estadoAtual = Estado.Patrulhando;
        else agente.SetDestination(player.position);
    }
}
