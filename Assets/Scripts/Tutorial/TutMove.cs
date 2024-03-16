using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class TutMove : MonoBehaviour
{ 
[SerializeField] private float rotateSpeed;
private PlayerInput inputActions;
private CharacterController characterController;
private Animator animator;
private Vector2 movementInput;
private Vector3 currentMovement;
private Quaternion rotateDir;
private bool isRun;
private bool isWalk;
[SerializeField] private CameraController cameraController;

public void Awake()
{

    characterController = GetComponent<CharacterController>();
    animator = GetComponent<Animator>();
    inputActions = new PlayerInput();
    inputActions.CharacterControls.Move.started += OnMovementActions;
    inputActions.CharacterControls.Move.performed += OnMovementActions;
    inputActions.CharacterControls.Move.canceled += OnMovementActions;
    
    inputActions.CharacterControls.Attack.started += OnAttackActions;


}


private void OnEnable()
{
    inputActions.CharacterControls.Enable();
}

private void OnDisable()
{
    inputActions.CharacterControls.Disable();
}

private void Update()
{
 
    AnimateControl();
    PlayerRotate();
}

private void FixedUpdate()
{
    characterController.Move(currentMovement * Time.fixedDeltaTime);
}

private void OnMovementActions(InputAction.CallbackContext context)
{
    movementInput = context.ReadValue<Vector2>();
    currentMovement.x = movementInput.x;
    currentMovement.z = movementInput.y;
    isWalk = movementInput.x != 0 || movementInput.y != 0;
}



private void OnAttackActions(InputAction.CallbackContext obj)
{
    animator.Play($"Attack{UnityEngine.Random.Range(1, 5)}");
}

private void PlayerRotate()
{
    if (isWalk)
    {
        rotateDir = Quaternion.Lerp(transform.rotation,
            Quaternion.LookRotation(currentMovement),
            Time.deltaTime * rotateSpeed);
        transform.rotation = rotateDir;
    }
}
private void AnimateControl()
{
    animator.SetBool("isWalking", isWalk);
}

public void Respawn()
{
    characterController.enabled = false;
    transform.position = Vector3.up;
    characterController.enabled = true;
}
}