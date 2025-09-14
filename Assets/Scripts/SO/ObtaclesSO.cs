using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Obtacles", menuName = "SO/Obtacles")]
public class ObtaclesSO : ScriptableObject
{
    public enum TypePos 
    {
       HIGH_POS ,
       LOW_POS ,
    }

    
    public int id;
    public string nameObtacles;
    public TypePos typePos;
}


