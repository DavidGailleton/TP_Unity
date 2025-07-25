using UnityEngine;

public class PlayerMouvement : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float jumpHeight = 10f;
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private float sensivity = 1f;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject camera;
    
    public Animator animator;

    
    
  
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X");
        float mouseY = Input.GetAxisRaw("Mouse Y");
        HandleMouseLook(mouseX, mouseY);
        PlayerMovement();
        AnimateBody();
    }

    private void HandleMouseLook(float mouseX, float mouseY)
    {
        Vector3 currentRotation = player.transform.localEulerAngles;
        currentRotation.y += mouseX * sensivity;
        
        player.transform.localRotation = Quaternion.AngleAxis(currentRotation.y, Vector3.up);
        
        Vector3 currentCameraRotation = camera.gameObject.transform.localEulerAngles;
        currentCameraRotation.x -= mouseY * sensivity;
        
        camera.gameObject.transform.localRotation = Quaternion.AngleAxis(currentCameraRotation.x, Vector3.right);
    }

    private void PlayerMovement()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            player.transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        } 
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            player.transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            player.transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            player.transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }
    }

    private void AnimateBody()
    {
        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) && Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            animator.SetInteger("speedIndex", 1);
            animator.SetInteger("playerDirection", 7);
        }
        else if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) && Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            animator.SetInteger("speedIndex", 1);
            animator.SetInteger("playerDirection", 1);

        }
        else if ((Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) && Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            animator.SetInteger("speedIndex", 1);
            animator.SetInteger("playerDirection", 5);

        }
        else if ((Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) && Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            animator.SetInteger("speedIndex", 1);
            animator.SetInteger("playerDirection", 3);

        }
        else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            animator.SetInteger("speedIndex", 1);
            animator.SetInteger("playerDirection", 0);
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            animator.SetInteger("speedIndex", 1);
            animator.SetInteger("playerDirection", 4);
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            animator.SetInteger("speedIndex", 1);
            animator.SetInteger("playerDirection", 6);
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            animator.SetInteger("speedIndex", 1);
            animator.SetInteger("playerDirection", 2);
        }
        else
        {
            animator.SetInteger("speedIndex", 0);
        }
    }
}
