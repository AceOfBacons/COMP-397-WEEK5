using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlPanelController : MonoBehaviour
{
    public RectTransform rectTransform;

    public Vector2 offscreenPosition;
    public Vector2 onscreenPosition;

    [Range(0.1f, 10.0f)]
    public float speed = 1.0f;
    public bool isOnScreen = false;
    public float timer = 0.0f;

    public CameraController playerCamera;

    public Pausable pausable;

    // Start is called before the first frame update
    void Start()
    {
        pausable = FindObjectOfType<Pausable>();
        playerCamera = FindObjectOfType<CameraController>();
        
        rectTransform = GetComponent<RectTransform>();
        rectTransform.anchoredPosition = offscreenPosition;
        timer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            

            isOnScreen = !isOnScreen;
            timer = 0.0f;

            if (isOnScreen)
            {
                Cursor.lockState = CursorLockMode.None;
                playerCamera.enabled = false;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                playerCamera.enabled = true;
            }
            
        }
        if (isOnScreen)
        {
            MoveControlPanelDown();
        }
        else
        {
            MoveControlPanelUp();
        }
    }

    void MoveControlPanelDown()
    {

        rectTransform.anchoredPosition = Vector2.Lerp(offscreenPosition, onscreenPosition, timer);
        
        if(timer < 1.0f)
        {
            timer += Time.deltaTime * speed;
        }

    }

    void MoveControlPanelUp()
    {

        rectTransform.anchoredPosition = Vector2.Lerp(onscreenPosition, offscreenPosition, timer);

        if (timer < 1.0f)
        {
            timer += Time.deltaTime * speed;
        }

        if (pausable.isPaused)
        {
            pausable.Pause();
        }
    }
}
