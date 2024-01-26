using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using UnityEngine;

public class TooltipManager : MonoBehaviour
{
    #region Variables
    [TextArea][SerializeField] private string textSeparator;

    [SerializeField] private RectTransform tooltipRect;
    [SerializeField] private TextMeshProUGUI tooltipText;
    [SerializeField] private float yAutoSizeOffset;

    private Vector2 autoSize;
    private TooltipTrigger triggerCurrent;
    private Transform rootParent;
    #region Get / Set

    public RectTransform TooltipRect
        {
            get { return tooltipRect; }
            set { tooltipRect = value; }
        }

    public TextMeshProUGUI TooltipText
        {
            get { return tooltipText; }
            set { tooltipText = value; }
        }

    public Transform RootParent
    {
        get { return rootParent; }
        set { rootParent = value; }
    }
    #endregion

    #endregion

    public static TooltipManager instance;

    private void Awake()
    {
        if (instance == null) instance = this;

        rootParent = tooltipRect.transform.parent;

}

    public void CursorEnter(TooltipTrigger trigger)
    {
        if (tooltipRect.gameObject.activeInHierarchy)   return;
        if (trigger == triggerCurrent)                  return;

        triggerCurrent = trigger;

        CursorEnter_ChangePosition();
        CursorEnter_ChangeValues(trigger.objText.tooltipText);
        StartCoroutine(ActiveDelay());
    }

    private void CursorEnter_ChangePosition()
    {
        tooltipRect.gameObject.SetActive(true);

        Vector2 falseOffset = new Vector2(200, 200);
        autoSize = new Vector2(0, 0);

        tooltipRect.anchorMin = triggerCurrent.Offset + falseOffset;
        tooltipRect.anchorMax = triggerCurrent.Offset + falseOffset + triggerCurrent.Size;
    }
    private void CursorEnter_ChangeValues(string txt)
    {
        string stringNew = txt;

        tooltipText.text = stringNew;
        // Afficher un sprite in-text : // "<size='50'>" + "<voffset=10><sprite=" + 7 + "></voffset>"
    }

    IEnumerator ActiveDelay()
    {
        yield return new WaitForSeconds(0.01f);
        if (triggerCurrent == null) yield break;

        autoSize = new Vector2(0, yAutoSizeOffset * tooltipText.textInfo.lineCount);

        if (triggerCurrent.Offset.y > 0.5f)
        {
            tooltipRect.anchorMin = triggerCurrent.Offset - autoSize - new Vector2(triggerCurrent.Size.x, 0);
            tooltipRect.anchorMax = triggerCurrent.Offset;
        }

        if (triggerCurrent.Offset.y <= 0.5f)
        {
            tooltipRect.anchorMin = triggerCurrent.Offset;
            tooltipRect.anchorMax = triggerCurrent.Offset + autoSize + new Vector2(triggerCurrent.Size.x, 0);
        }
    }

    public void CursorExit(TooltipTrigger trigger)
    {
        if (trigger != triggerCurrent) return;

        triggerCurrent = null;
        tooltipRect.gameObject.SetActive(false);
    }
}
