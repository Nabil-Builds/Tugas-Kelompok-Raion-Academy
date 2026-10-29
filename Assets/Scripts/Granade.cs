using Unity.VisualScripting;
using UnityEngine;

public class Granade : MonoBehaviour
{
    private Vector3 targetPosition;
    private int moveSpeed;
    [SerializeField] float lifeSpan;
    private Vector3 projectileStartPoint;
    private float elapsedTime = 0f;
    private float flightDuration;
    [SerializeField] GameObject explosion;

    float maxHeight;
    private AnimationCurve trajectoryAnimationCurve;

    private void Start() {
        projectileStartPoint = transform.position;
    }
    void Update()
    {
        UpdateProjectilePosition();

        if (lifeSpan > 0)
        {
            lifeSpan -= Time.deltaTime;
        } else
        {
            Explode();
        }
    }

    private void UpdateProjectilePosition()
    {
        if (flightDuration <= 0f || trajectoryAnimationCurve == null) return;

        // Progress 't' goes from 0.0 (start) to 1.0 (destination)
        elapsedTime += Time.deltaTime;
        float t = Mathf.Clamp01(elapsedTime / flightDuration);

        // 1. Interpolate straight-line position (handles left/right, up/down)
        Vector3 currentLinearPos = Vector3.Lerp(projectileStartPoint, targetPosition, t);

        // 2. Add arc height offset from the curve
        float heightOffset = trajectoryAnimationCurve.Evaluate(t) * maxHeight;

        // 3. Apply position
        transform.position = new Vector3(currentLinearPos.x, currentLinearPos.y + heightOffset, 0f);
    }

    void Explode()
    {
        if (explosion != null)
    {
        
        GameObject fx = Instantiate(explosion, transform.position, Quaternion.identity);
        
        Destroy(fx, 0.5f); 
    }
        Destroy(gameObject);
    }

    public void InitializeProjectile(Vector3 targetPos, int moveSpeed, float maxHeight)
    {
        this.targetPosition = targetPos;
        this.moveSpeed = moveSpeed;
        this.maxHeight = maxHeight;

        // Capture start position and calculate total flight duration
        this.projectileStartPoint = transform.position;
        float distance = Vector3.Distance(projectileStartPoint, targetPosition);
        this.flightDuration = distance / moveSpeed;
    }

    public void InitializeAnimationCurve(AnimationCurve trajectoryAnimationCurve)
    {
        this.trajectoryAnimationCurve = trajectoryAnimationCurve;
    }

    
}
