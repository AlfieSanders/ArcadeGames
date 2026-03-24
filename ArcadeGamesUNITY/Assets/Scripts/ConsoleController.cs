using UnityEngine;
using UnityEngine.InputSystem;

public class ConsoleController : MonoBehaviour
{
    // Create variables of controled console children, but set on 'Awake'.

    private GameObject joystick;
    private GameObject b1;
    private GameObject b2;
    private GameObject b3;
    private GameObject b4;


    // Create color variables for buttons when pressed/released. Tried 'Color' rather than 'Color32' but gave odd results.

    private Color32 b1Off = new Color32(43, 0, 89, 255);
    private Color32 b2Off = new Color32(89, 0, 0, 255);
    private Color32 b3Off = new Color32(89, 0, 81, 255);
    private Color32 b4Off = new Color32(0, 89, 76, 255);

    private Color32 b1On = new Color32(88, 23, 159, 255);
    private Color32 b2On = new Color32(159, 59, 59, 255);
    private Color32 b3On = new Color32(185, 78, 176, 255);
    private Color32 b4On = new Color32(26, 154, 138, 255);


    // Create variable for default 'Joystick' location. To be set on 'Awake'.

    private Vector3 joystickLocation;


    // 'Awake' is run before the first frame; Getting references and setting these variables should be done here.

    private void Awake()
    {
        // Gets an array of children of the console, then sets each GameObject by the intiger in the array.
        // Interestingly 'Transform' must be used as it contains the information for each GameObject within the 'Transform' variable.
        // This could have been done as a seperate method, and called from here.

        Transform[] controlerChildren = transform.GetComponentsInChildren<Transform>();
        
        joystick = controlerChildren[3].gameObject;
        b1 = controlerChildren[12].gameObject;
        b2 = controlerChildren[13].gameObject;
        b3 = controlerChildren[14].gameObject;
        b4 = controlerChildren[15].gameObject;

        //Sets the default location of the Joystick GameObject.

        joystickLocation = joystick.transform.position;
    }


    // Unity events for each Input Action set in the 'Player Input' component.

    public void OnJoystickEvent(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Vector2 joystickVector = context.ReadValue<Vector2>();
            joystick.transform.position = joystickLocation + new Vector3(joystickVector.x, joystickVector.y, 0);
        }
        if (context.canceled)
        {
            Vector2 joystickVector = context.ReadValue<Vector2>();
            joystick.transform.position = joystickLocation;
        }

    }

    public void OnButton1Event(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            b1.GetComponent<SpriteRenderer>().color = b1On;
        }
        if (context.canceled)
        {
            b1.GetComponent<SpriteRenderer>().color = b1Off;
        }
    }

    public void OnButton2Event(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            b2.GetComponent<SpriteRenderer>().color = b2On;
        }
        if (context.canceled)
        {
            b2.GetComponent<SpriteRenderer>().color = b2Off;
        }
    }

    public void OnButton3Event(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            b3.GetComponent<SpriteRenderer>().color = b3On;
        }
        if (context.canceled)
        {
            b3.GetComponent<SpriteRenderer>().color = b3Off;
        }
    }

    public void OnButton4Event(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            b4.GetComponent<SpriteRenderer>().color = b4On;
        }
        if (context.canceled)
        {
            b4.GetComponent<SpriteRenderer>().color = b4Off;
        }
    }

}
