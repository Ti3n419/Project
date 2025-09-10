using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TI3NMono : MonoBehaviour
{
    protected virtual void Reset() 
    {
        this.LoadComponents();
            
    }
    protected virtual void LoadComponents() 
    {

    }
    protected virtual void Awake() 
    {
        this.LoadComponents();
    }
    
    
}
