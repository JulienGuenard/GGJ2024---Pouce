using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ObjectText", order = 1)]
public class ObjectText : ScriptableObject
{
    [TextArea] public string tooltipText;
}