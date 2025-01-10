using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlayerMovement;

public class HeadBob : MonoBehaviour
{

    private float timer = 0.0f;
    float bobbingSpeed = 0.07f;
    float bobbingAmount = 0.1f;
    float midpoint = 2.0f;
    [SerializeField]
    GameObject player;
    PlayerMovement playerMovement;
    void Update()
    {
        playerMovement = FindAnyObjectByType<PlayerMovement>();
        float waveslice = 0.0f;
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 cSharpConversion = transform.localPosition;

        //när den springer, öka headbob
        if (playerMovement.state == MovementState.sprinting)
        {
            bobbingAmount = 0.17f;
        }
        else
        {
            bobbingAmount = 0.07f;
        }

        if (Mathf.Abs(horizontal) == 0 && Mathf.Abs(vertical) == 0)
        {
            timer = 0.0f;
        }
        else
        {
            waveslice = Mathf.Sin(timer);
            timer = timer + bobbingSpeed;
            if (timer > Mathf.PI * 2)
            {
                timer = timer - (Mathf.PI * 2);
            }
        }
        if (waveslice != 0)
        {
            float translateChange = waveslice * bobbingAmount;
            float totalAxes = Mathf.Abs(horizontal) + Mathf.Abs(vertical);
            totalAxes = Mathf.Clamp(totalAxes, 0.0f, 1.0f);
            translateChange = totalAxes * translateChange;
            cSharpConversion.y = midpoint + translateChange;
        }
        else
        {
            cSharpConversion.y = midpoint;
        }

        transform.localPosition = cSharpConversion;
    }



}

