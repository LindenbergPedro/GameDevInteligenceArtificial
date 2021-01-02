using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Acoes : ScriptableObject
{
    public abstract void Agir(AgenteIA agent);
}
