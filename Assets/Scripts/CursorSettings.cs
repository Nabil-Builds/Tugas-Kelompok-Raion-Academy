using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class CursorSettings : MonoBehaviour
{
    [SerializeField] private RectTransform customCursor;

    void Start()
    {
        Cursor.visible = false;
        
        Cursor.lockState = CursorLockMode.Confined; 
    }

    void Update()
    {
        customCursor.position = Input.mousePosition;
    }
}
