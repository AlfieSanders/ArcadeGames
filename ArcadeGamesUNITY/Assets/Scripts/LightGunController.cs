using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class LightGunController : MonoBehaviour
{
    LayerMask layerMask;
    public void OnLeftMouseEvent(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); // Convert to world coordinates
            RaycastHit hit;
            if(Physics.Raycast(mousePosition, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
            {
                Debug.DrawRay(mousePosition, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);
            }
            if (hit.collider != null) 
            {
                Debug.Log("Hit Object: " + hit.collider.name);

                if (hit.collider.CompareTag("Target"))
                {
                    Target script = hit.collider.gameObject.GetComponent<Target>();
                    script.F_Hit();
                    Debug.Log("You clicked on an interactable object!");
                }
            }
        }
    }

    private void Awake()
    {
        layerMask = LayerMask.GetMask("Character");
    }
}


