using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance;
    public Canvas minigame1;
    public Canvas minigame2;
    public Canvas minigame3;

    private void Awake()
    {
        if (Instance != this)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    } 

    private void Update()
    {
        switch (States.Instance.state)
        {
            case GameStates.Idle:
                IdleInput();
                break;
        }
    }

    public void IdleInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            States.Instance.state = GameStates.Play;
        }
    }
}
