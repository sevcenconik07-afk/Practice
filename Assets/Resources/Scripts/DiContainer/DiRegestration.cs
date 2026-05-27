using System;
using UnityEngine;

public class DiRegestration
{
    public Func<DiContainer,object> Factory{get;set;}
    public bool IsSingleton { get; set; }
    public object Instance { get; set; }
}
