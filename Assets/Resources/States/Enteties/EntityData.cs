using R3;
using System;
using UnityEngine;



public class EntityData 
{
    public EntitySaveData EntitySaveData { get; }
    public int EntityId => EntitySaveData.EntityId;
    public string TypeId => EntitySaveData.TypeId;
    public EntityType Type => EntitySaveData.Type;

    public readonly ReactiveProperty<Vector2> Position;

    public EntityData(EntitySaveData data)
    {
        EntitySaveData = data;

        Position = new ReactiveProperty<Vector2>(data.Position);
        Position.Subscribe(newPosition => { data.Position = newPosition; });
    }
}
