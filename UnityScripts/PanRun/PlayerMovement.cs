using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static float speed = 12;
    public Rigidbody _rb;
    public Animator anim;

    float horizontalInput;
    public float horizontalMultiplier = 2;
    public static bool dead;

    private void Start()
    {
        speed = 12;
        dead = false; //player is alive
    }

    private void FixedUpdate()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("RunWithPan")) 
        {
            Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
            Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalMultiplier;
            _rb.MovePosition(_rb.position + forwardMove + horizontalMove);
        }   
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        SwerveClamp(gameObject.transform, -8.3f, 8.3f);
        StartCoroutine(SpeedCheck());
    }

    private void SwerveClamp(Transform player, float min, float max) 
    {
        var xClamp = Mathf.Clamp(player.position.x, min, max);
        player.position = new Vector3(xClamp, player.position.y, player.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "NPC")
        {
            if (RagdollDeath.swingFromRight)
            {
                anim.SetTrigger("HitFromRight");
                anim.SetTrigger("RunWithPan");
            }
            else
            {
                anim.SetTrigger("HitFromLeft");
                anim.SetTrigger("RunWithPan");
            }
        }
        else if (other.gameObject.tag == "Obstacle_V" || other.gameObject.tag == "Obstacle_H") //obstacle - horizontal or vertical
        {
            anim.SetTrigger("Fall");
            speed = 0;
            _rb.constraints = RigidbodyConstraints.FreezePositionZ; //player stops when he dies
            Debug.Log("U Ded");
            dead = true;
        }
    }

    IEnumerator SpeedCheck() //decrease speed by 1 every second if higher than 12
    {
        while (speed > 12f || anim.speed > 1.5f)
        {
            speed -= 1f * Time.deltaTime;
            anim.speed -= 0.2f * Time.deltaTime;
            yield return new WaitForSeconds(0.5f);
        }
    }
}
