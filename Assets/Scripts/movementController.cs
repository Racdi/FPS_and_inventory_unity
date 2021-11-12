using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public float Speed = 5f;
    public GameObject playerController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movementInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        // Ability to "run" pressing left shift (aka Fire3)
        float sprint = Input.GetAxis("Fire3");
        //Make sure character won't move faster in diagonal
        movementInput.Normalize();

        Vector3 movementController = movementInput.y * transform.forward + movementInput.x * transform.right;

        playerController.Move(movementController * Speed * Time.deltaTime * (sprint +1));
    }
}
