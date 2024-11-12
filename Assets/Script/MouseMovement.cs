using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{

    public float mouseSensitivity = 100f; //????????"mousesensitivity"

    float xRotation = 0f; //x?????,??fps??????
    float YRotation = 0f; //y?????,??fps??????
    // Start is called before the first frame update
    void Start()
    {
        //Locking the cursor to the middle of the screen and making it invisible    ???????
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;  //?mouse x???,??sensitivity???deltatime ??mouse? x???
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;  //?mouse y???,??sensitivity???deltatime ??mouse? y???

        //control rotation around x axis (Look up and down)
        xRotation -= mouseY;  //?mouse?y axis??(??) ?xrotation(????)??

        //we clamp the rotation so we cant Over-rotate (like in real life)
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); //???(xrotation)?-90??90????,????????

        //control rotation around y axis (Look up and down)
        YRotation += mouseX;    //?mouse?x axis??(??) ?yrotation(????)??

        //applying both rotations
        transform.localRotation = Quaternion.Euler(xRotation, YRotation, 0f); //?xrotation?yrotation??transform.localratation???
    }
}
