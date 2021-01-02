using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PingPongGO : MonoBehaviour
{
    private Transform obstaculo;
    void Start()
    {
        obstaculo = GetComponent<Transform>();
    }

    // Calculando no update, que a todo momento
    // O objeto Transform chamado obstaculo, ira se movimentar a ta time, em 20 m
    // Ou seja, utilizei o PingPong que pega o tempo e a distancia e coloquei dentro de um vetor e fiz
    // para que modifique a posiçao desse obstaculo de acordo com a formula.
    void Update()
    {
        obstaculo.position = new Vector3(Mathf.PingPong(Time.time, 20)+40,obstaculo.position.y,obstaculo.position.z);
    }
}
