using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using UnityEngine;

public class TooltipTrigger : MonoBehaviour
{
    #region Variables
    public Vector2 offset;
    public Vector2 size;

    public ObjectText objText;

    #region Get / Set

    public Vector2 Offset
    {
        get { return offset; }
        set { offset = value; }
    }

    public Vector2 Size
    {
        get { return size; }
        set { size = value; }
    }
    #endregion

    #endregion

    public void OnMouseEnter()
    {
        TooltipManager.instance.CursorEnter(this);
    }

    public void OnMouseExit()
    {
        TooltipManager.instance.CursorExit(this);
    }
}
