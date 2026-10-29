using System;
using Unity.VisualScripting;
using UnityEngine;

public class ThrowGranade : MonoBehaviour
{
    [SerializeField] GameObject granadeObject;
    [SerializeField] int throwSpeed;
    [SerializeField] private AnimationCurve trajectoryAnimationCurve;
    [SerializeField] float maxHeight;
    
    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = -Camera.main.transform.position.z;
        Vector3 targetWorldPos = Camera.main.ScreenToWorldPoint(mousePos);
        targetWorldPos.z = 0f;

        if (Input.GetKeyDown(KeyCode.E))
        {
            Granade granade = Instantiate(granadeObject, transform.position, Quaternion.identity).GetComponent<Granade>();
            if (granade != null)
            {
            granade.InitializeProjectile(targetWorldPos, throwSpeed, maxHeight);
            granade.InitializeAnimationCurve(trajectoryAnimationCurve);
            }
        }
        
    }
}
