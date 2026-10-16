using UnityEngine;
using UnityEngine.InputSystem;

public class Control : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Vector3 targetPosition;
    private bool isMoving = false;

    void Start()
    {
        targetPosition = transform.position;
    }

    void Update()
    {
        //беремо клацання ЛКМ/ПКМ
        bool isClickPressed = Mouse.current.leftButton.wasPressedThisFrame || 
                             Mouse.current.rightButton.wasPressedThisFrame;

        if (isClickPressed)
        {
            //де курсор
            Vector2 mousePosition = Mouse.current.position.ReadValue();
            
            Ray ray = Camera.main.ScreenPointToRay(mousePosition);
            Plane groundPlane = new Plane(Vector3.up, transform.position);

            if (groundPlane.Raycast(ray, out float rayDistance))
            {
                targetPosition = ray.GetPoint(rayDistance);
                isMoving = true;
            }
        }

        //зміна позіції та поворот
        if (isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            Vector3 direction = (targetPosition - transform.position);
            direction.y = 0; 
            if (direction != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(direction);
            }

            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                isMoving = false;
            }
        }
    }
}
