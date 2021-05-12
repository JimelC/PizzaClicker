using Lean.Touch;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectableImage : MonoBehaviour
{
    public LeanSelectable mySelectable;

    public Image myImage;
    public Color selectedColor = Color.red;
    public Color deselectedColor = Color.white;

    public System.Action<SelectableImage> OnSelectEvent;

    public void HandleSelectEvent(LeanFinger finger)
    {
        myImage.color = selectedColor;

        if (OnSelectEvent != null)
        {
            OnSelectEvent.Invoke(this);
        }
    }

    public void HandleSelectUpEvent(LeanFinger finger)
    {
    }

    public void HandleDeselectEvent()
    {
        myImage.color = deselectedColor;
    }
}
