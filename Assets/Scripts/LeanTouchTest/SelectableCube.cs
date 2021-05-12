using Lean.Touch;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectableCube : MonoBehaviour
{
    public Renderer myRenderer;
    public Material unselectedMaterial;
    public Material selectedMaterial;

    public void HandleSelectEvent(LeanFinger finger)
    {
        myRenderer.material = selectedMaterial;
    }

    public void HandleSelectUpEvent(LeanFinger finger)
    {

    }

    public void HandleDeselectEvent()
    {
        myRenderer.material = unselectedMaterial;
    }
}
