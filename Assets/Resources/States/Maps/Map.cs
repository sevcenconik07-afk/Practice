using UnityEngine;
using ObservableCollections;
using R3;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class Map 
{
    public int Id => mapData.Id;
    public ObservableList<Entity> Entities { get; }
    public MapData mapData { get; }

    public Map(MapData mapData)
    {
        this.mapData = mapData;
        Entities = new ObservableList<Entity>();
        AddEntities(mapData.Entities);

        Entities.ObserveAdd().Subscribe(e => AddEntityData(e.Value));

        Entities.ObserveRemove().Subscribe(e => RemoveEntityData(e.Value));
    }

    private void AddEntities(List<EntitySaveData> entitiesData)
    {
        foreach (var entityData in entitiesData)
        {
            Entities.Add(EntitiesFactory.CreateEntity(new EntityData(entityData)));
        }
    }
    private void AddEntityData(Entity entity)
    {
        mapData.Entities.Add(entity.EntityData.EntitySaveData);
    }

    private void RemoveEntityData(Entity entity)
    {
        if (mapData.Entities.Contains(entity.EntityData.EntitySaveData))
        {
            mapData.Entities.Remove(entity.EntityData.EntitySaveData);
        }
    }
}
