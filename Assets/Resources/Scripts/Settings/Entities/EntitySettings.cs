using System.Collections.Generic;
using UnityEngine;

public class EntitySettings : ScriptableObject
{
    [field: SerializeField] public EntityType EntityType { get; private set; }
    [field: SerializeField] public string TypeId { get; private set; }
    [field: SerializeField] public string PrefabPath { get; private set; }
}
