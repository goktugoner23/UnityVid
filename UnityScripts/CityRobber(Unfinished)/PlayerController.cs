using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Fields
    [Header("Components")]
    [SerializeField] private Rigidbody rb;
    [SerializeField] private DynamicJoystick joystick;
    [Header("Variables")]
    [SerializeField] private float lerpValue;
    [Range(0.1f, 0.9f)]
    [SerializeField] private float movementGap;
    private float movementMagnitude;
    #endregion

    private void FixedUpdate()
    {
        switch (States.Instance.state)
        {
            case GameStates.Play:
                LookForward(rb, joystick);
                JoystickInput(rb, PlayerUpgrades.Instance.movementSpeed);
                break;
        }
    }

    private void JoystickInput(Rigidbody _rb, float _speed)
    {
        if (joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            if (movementMagnitude > 0.2f)
            {
                _rb.velocity = new Vector3(Mathf.Lerp(_rb.velocity.x, joystick.Horizontal * _speed, lerpValue),
             _rb.velocity.y, Mathf.Lerp(_rb.velocity.z, joystick.Vertical * _speed, lerpValue));

            AnimationInitiliaze.Instance.RunningAnimation();
            }
        }
        else
        {
            rb.velocity = Vector3.zero;
            AnimationInitiliaze.Instance.IdleAnimation();
            States.Instance.state = GameStates.Idle;
        }
    }

    private void LookForward(Rigidbody _rb, Joystick _joystick)
    {
        movementMagnitude = new Vector3(_joystick.Horizontal, rb.velocity.y, _joystick.Vertical).magnitude;

        if (movementMagnitude > 0.05f)
        {
            transform.rotation = Quaternion.LookRotation(_rb.velocity);
        }
    }
}
