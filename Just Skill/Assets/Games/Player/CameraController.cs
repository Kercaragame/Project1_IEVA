using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [Header("reference")]
    public Transform player;
    public Transform playerCharacter;
    public Transform orientation;
    public Transform targetLookAt;
    public Rigidbody rigidBody;

    public float rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {

        //rotate orientation
        Vector3 viewDir = player.position - new Vector3(this.transform.position.x, player.position.y, this.transform.position.z);
        orientation.forward = viewDir.normalized;

        //rotate Player
        playerCharacter.LookAt(targetLookAt);

    }
}

//rotate Player
/*float horizontalInput = Input.GetAxis("Horizontal");
float verticalInpout = Input.GetAxis("Vertical");
Vector3 inputDir = orientation.forward * verticalInpout + orientation.right * horizontalInput;
if(inputDir != Vector3.zero)
{
    playerCharacter.forward = Vector3.Slerp(playerCharacter.forward, inputDir.normalized, Time.deltaTime * rotationSpeed);
}*/
