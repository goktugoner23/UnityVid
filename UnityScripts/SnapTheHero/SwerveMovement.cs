using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//2 boyutlu swerve movement, karışmasın diye input alan ayrı bir script yazdım (swerveinput.cs)
public class SwerveMovement : MonoBehaviour
{
    private SwerveInput swerveInput;
    [SerializeField] private float swerveSpeed = 0.5f;
    [SerializeField] private float maxSwerveAmount = 2f;

    private void Awake() {
        swerveInput = GetComponent<SwerveInput>();
    }

    private void Update() {
        float swerveAmountX = Time.deltaTime * swerveSpeed * swerveInput.moveFactorX;
        float swerveAmountY = Time.deltaTime * swerveSpeed * swerveInput.moveFactorY;
        swerveAmountX = Mathf.Clamp(swerveAmountX, -maxSwerveAmount, maxSwerveAmount);
        swerveAmountY = Mathf.Clamp(swerveAmountY, -maxSwerveAmount, maxSwerveAmount);
        transform.Translate(swerveAmountX, swerveAmountY, 0);
    }
}
