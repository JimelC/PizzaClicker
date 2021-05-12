using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectableButtonsController : MonoBehaviour
{
    public SelectableImage[] allSelectableImages;

    private void Start()
    {
        for (int i=0;i<allSelectableImages.Length;i++)
        {
            allSelectableImages[i].OnSelectEvent += OnSelectSelectableImage;
        }
    }

    private void OnSelectSelectableImage(SelectableImage selectableImage)
    {
        for (int i=0;i<allSelectableImages.Length;i++)
        {
            if (allSelectableImages[i] != selectableImage)
            {
                allSelectableImages[i].mySelectable.Deselect();
            }
        }
    }
}
