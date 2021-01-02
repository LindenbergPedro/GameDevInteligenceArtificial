using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Estado")]
public class EstaodoFSM : ScriptableObject
{
    public Acoes[] acoess;  
    public Transicao[] transicoes;

    public void AtualizarEstado(AgenteIA Agent)
    {
        FazAcoes(Agent);
        VerificarTransicoes(Agent);
    }

    public void FazAcoes(AgenteIA Agent)
    {
        for(int i = 0; i < acoess.Length; i++)
        {
            acoess[i].Agir(Agent);
        }
    }
    
    public void VerificarTransicoes(AgenteIA Agent)
    {
        for(int i = 0; i < transicoes.Length; i++)
        {
            bool transita = transicoes[i].ChecaCondicao(Agent);

            if(transita) Agent.estadoAtual = transicoes[i].estadoCasoTrue;
            else Agent.estadoAtual = transicoes[i].estadoCasoFalse;
        }
    }
    
}
