using UnityEngine;
using R3;

public abstract class Entity 
{
    public EntityData EntityData { get; }
    

    public Entity(EntityData data)
    {
        EntityData = data;
                
    }
}
