using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Object", order = 1)]
public class Object : ScriptableObject
{
    public StructEventTooltip   infos;
    public StructResource       resources;
}