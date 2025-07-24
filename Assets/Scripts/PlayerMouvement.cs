using UnityEngine;

public class PlayerMouvement : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float jumpHeight = 10f;
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private float sensivity = 10f;
    [SerializeField] private GameObject body;
    [SerializeField] private GameObject camera;
    
    
  
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X");
        float mouseY = Input.GetAxisRaw("Mouse Y");
        HandleMouseLook(mouseX, mouseY);
    }

    private void HandleMouseLook(float mouseX, float mouseY)
    {
        Vector3 currentRotation = body.transform.localEulerAngles;
        currentRotation.y += mouseX;
        
        body.transform.localRotation = Quaternion.AngleAxis(currentRotation.y, Vector3.up);
        
        Vector3 currentCameraRotation = camera.gameObject.transform.localEulerAngles;
        currentCameraRotation.x -= mouseY;
        
        camera.gameObject.transform.localRotation = Quaternion.AngleAxis(currentCameraRotation.x, Vector3.right);
    }
}
