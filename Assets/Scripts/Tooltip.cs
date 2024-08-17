using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tooltip : MonoBehaviour
{
    public string message;

    private void OnMouseEnter()
    {
        TooltipController.instance.setToolTipText(message);
        Debug.Log("Mouse hovering");
    }

    public void OnMouseExit()
    {
        TooltipController.instance.HideToolTip();
    }
}
