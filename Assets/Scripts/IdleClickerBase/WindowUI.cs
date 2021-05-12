using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowUI : MonoBehaviour
{
    #region public methods
    public void Show()
    {
        this.gameObject.SetActive(true);
    }

    public void Hide()
    {
        this.gameObject.SetActive(false);
    }
    #endregion

    #region public variables
    public string ID
    {
        get { return _id; }
        private set { _id = value; }
    }
    #endregion

    #region private methods
    #endregion

    #region private variables
    [SerializeField]
    private string _id;
    #endregion
}
