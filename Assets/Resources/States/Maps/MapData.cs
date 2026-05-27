using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class MapData 
{
    public int Id { get; set; }
    public List<EntitySaveData> Entities { get; set; }
}
