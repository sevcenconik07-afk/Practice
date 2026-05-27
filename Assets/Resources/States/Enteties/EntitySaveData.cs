using System;
using UnityEngine;

[Serializable]
public class EntitySaveData 
{
    public int EntityId { get; set; }
    public string TypeId { get; set; }
    public EntityType Type { get; set; }

    public string PrefabPath { get;  set; }

    public Vector2 Position { get; set; }
}
