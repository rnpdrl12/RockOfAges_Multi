using System.Collections.Generic;
using UnityEngine;

public class DefaultRock : RockBase
{


    void Start()
    {
        Init();
    }

    private void FixedUpdate()
    {
        if (playerInput.magnitude > 0)
        {
            Move(playerInput);
        }
    }

    private void Update()
    {
        GetInput();
        ChangeRockState();
        CheckGroundRay();
        ChangeDrag();


        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            Jump(DEFAULT_JUMP_FORCE);
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (IsMove(2))
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer("Obstacles")) 
            {
                Attack(collision);
            }
            if (IsMove(10))
            {
                Hit(10);
            }
        }
    }

}