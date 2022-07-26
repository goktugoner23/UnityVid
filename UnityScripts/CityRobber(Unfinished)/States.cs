using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class States : MonoBehaviour
{
    #region Fields
    [Header("Singleton")]
    public static States Instance;
    [Header("Variables")]
    public GameStates state;
    #endregion
    private void Awake() {
        if (Instance != this)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
}

public enum GameStates
{
    Idle,
    Play,
    Upgrade,
    Rob,
    End
}
