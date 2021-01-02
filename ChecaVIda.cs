using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "TransicaoPoucaVida")]
public class ChecaVIda : Transicao
{
   public override bool ChecaCondicao(AgenteIA agent)
   {
        if (agent.HP <= 25) return true; // VERIFICA SE O HP DO AGENTE é IGUAL 25 E COM ISSO RETORNA TRUE
        else return false;
        
   }

}
