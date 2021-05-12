using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class WindowSystem : MonoBehaviour
{
    #region public methods
    public void ShowWindow(string windowId)
    {
        WindowUI targetWindow = GetWindow(windowId);
        ShowWindow(targetWindow);
    }

    public void ShowWindow(WindowUI window)
    {
        window.Show();
    }

    public void HideWindow(string windowId)
    {
        WindowUI targetWindow = GetWindow(windowId);
        HideWindow(targetWindow);
    }

    public void HideWindow(WindowUI window)
    {
        window.Hide();
    }

    //Buscar una ventana dentro de la lista, que tenga el ID buscado
    public WindowUI GetWindow(string windowId)
    {
        return System.Array.Find(_windowList, window => window.ID == windowId);
    }
    #endregion

    #region public variables
    #endregion

    #region private methods
    #endregion

    #region private variables
    //Lista de todas las ventanas del juego
    [SerializeField]
    private WindowUI[] _windowList;
    #endregion
}
