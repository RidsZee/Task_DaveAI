using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    const string paramWalk = "Walk";
    
    [SerializeField] Rigidbody PlayerRB;
    [SerializeField] float MovementSpeed;
    [SerializeField] float RotationSpeed;
    [SerializeField] Animator AnimController;
    [SerializeField] Transform ReferenceDirection;

    int movementForward;
    int movementSideways;

    Vector3 CamDirection;
    float RotationAddition;
    float targetEulerAngle;

    void OnEnable()
    {
        InputManager.SendInputActions += OnReceiveInputs;
    }

    void OnDisable()
    {
        InputManager.SendInputActions -= OnReceiveInputs;
    }

    void Start()
    {
        AnimController.SetInteger(paramWalk, 0);
    }

    void OnReceiveInputs(int _movementForward, int _movementSideways)
    {
        movementForward = _movementForward;
        movementSideways = _movementSideways;
    }

    void Update()
    {
        if(movementForward == 1 && movementSideways == 0)
        {
            RotationAddition = 0;
        }
        else if (movementForward == -1 && movementSideways == 0)
        {
            RotationAddition = 180;
        }
        else if (movementForward == 0 && movementSideways == 1)
        {
            RotationAddition = 90;
        }
        else if (movementForward == 0 && movementSideways == -1)
        {
            RotationAddition = -90;
        }
        else if (movementForward == 1 && movementSideways == 1)
        {
            RotationAddition = 45;
        }
        else if (movementForward == 1 && movementSideways == -1)
        {
            RotationAddition = -45;
        }
        else if (movementForward == -1 && movementSideways == 1)
        {
            RotationAddition = 135;
        }
        else if (movementForward == -1 && movementSideways == -1)
        {
            RotationAddition = -135;
        }
        
        targetEulerAngle = ReferenceDirection.eulerAngles.y + RotationAddition;
        
        CamDirection.z = 0;
        CamDirection.x = 0;
        CamDirection.y = Mathf.LerpAngle(CamDirection.y, targetEulerAngle, RotationSpeed * Time.deltaTime);

        if (movementForward != 0 || movementSideways != 0)
        {
            PlayerRB.velocity = PlayerRB.transform.forward * MovementSpeed;
            
            PlayerRB.transform.eulerAngles = CamDirection;

            AnimController.SetInteger(paramWalk, 1);
        }
        else
        {
            AnimController.SetInteger(paramWalk, 0);
        }
    }
}