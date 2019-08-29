using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public static Action InteractButtonPressed;
    [SerializeField] private Mover mover;

    private void Update()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");

        float moveVertical = Input.GetAxisRaw("Vertical");

        Vector3 newPos = new Vector3(moveHorizontal, moveVertical, 0);
        mover.Move(newPos);

        if(Input.GetKeyUp(KeyCode.E))
        {
            InteractButtonPressed();
        }

    }
}