using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    [SerializeField] private float deadZone = 0.1f;
    [SerializeField] private float gamePadRotateSmooth = 1000f;
    [SerializeField] private Camera cam;

    private InputManager inputManager;

    private Vector2 aim;

    private void Start()
    {
        inputManager = InputManager.GetInstance();
    }


    private void Update()
    {
        aim = inputManager.playerControls.Controls.Aim.ReadValue<Vector2>();
        HandleRotation();
    }

    private void HandleRotation()
    {
        if (inputManager.isGamePad)
        {
            //RotatePlayer
            if (Mathf.Abs(aim.x) > deadZone || Mathf.Abs(aim.y) > deadZone)
            {
                Vector3 playerDirection = Vector3.right * aim.x + Vector3.forward * aim.y;
                if (playerDirection.sqrMagnitude > 0.0f)
                {
                    Quaternion newRotation = Quaternion.LookRotation(playerDirection, Vector3.up);
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, newRotation,
                        gamePadRotateSmooth * Time.deltaTime);
                }
            }
        }
        else
        {
            if (cam is not null)
            {
                Vector3 mousePos = Input.mousePosition;
                mousePos.z = 5.23f;

                Vector3 objectPos = cam.WorldToScreenPoint(transform.position);
        
                mousePos.x = mousePos.x - objectPos.x;
                mousePos.y = mousePos.y - objectPos.y;

                float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
            }
        }
    }


    private void LookAt(Vector3 lookPoint)
    {
        Vector3 heightCorrectedPoint = new Vector3(lookPoint.x, transform.position.y, lookPoint.z);
        transform.LookAt(heightCorrectedPoint);
    }
}