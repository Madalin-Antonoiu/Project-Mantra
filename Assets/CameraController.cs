using RPG.Control;
using UnityEngine;

public class CameraController : MonoBehaviour {
   
    //Input variables
    KeyCode leftMouse = KeyCode.Mouse0, rightMouse = KeyCode.Mouse1, middleMouse = KeyCode.Mouse2;

    //Camera variables
    public float cameraHeight = 1.75f , cameraMaxDistance = 25;
    float cameraMaxTilt = 90;
    [Range(0,4)]
    public float cameraSpeed =2;
    float currentPan, currentTilt = 10, currentDistance = 5;

    //Refferences
    PlayerController player;
    public Transform tilt;
    Camera mainCam;
    

    void Start() {
        player = FindObjectOfType<PlayerController>();
        mainCam = Camera.main; 

        transform.position = player.transform.position + Vector3.up * cameraHeight;
        transform.rotation = player.transform.rotation;

        tilt.eulerAngles = new Vector3(currentTilt, transform.eulerAngles.y, transform.eulerAngles.z);
        mainCam.transform.position += tilt.forward * -currentDistance;
    }

    void LateUpdate(){
        CameraTransforms();
    }

    void CameraTransforms(){

        currentPan = player.transform.eulerAngles.y;

        transform.position = player.transform.position + Vector3.up * cameraHeight;
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, currentPan, transform.eulerAngles.z);
        tilt.eulerAngles = new Vector3(currentTilt, tilt.eulerAngles.y, tilt.eulerAngles.z);
        mainCam.transform.position = transform.position + tilt.forward * -currentDistance;
    }
}
