using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementController : MonoBehaviour
{
    public float Speed = 5f;
    public CharacterController playerController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movementInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        //Make sure character won't move faster in diagonal
        movementInput.Normalize();

        Vector3 movementController = movementInput.y * transform.forward + movementInput.x * transform.right;

        // Ability to "run" pressing left shift (aka Fire3)
        if(Input.GetAxis("Fire3") != 0){
            movementController = movementController * 2;
        }
        playerController.Move(movementController * Speed * Time.deltaTime);
    }
}
