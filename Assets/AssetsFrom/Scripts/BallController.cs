using UnityEngine;

public class BallController : MonoBehaviour
{
    private bool isThrowing = false;
    public Transform target;
    public float throwDuration = 1.5f;
    public Rigidbody rb;
    public float throwHeight = 1.2f;
    private float throwTimer = 0f;
    public float smoothFactor = 9f;
    private void FixedUpdate()
    {
        if (isThrowing)
        {
            throwTimer += Time.fixedDeltaTime;

            if (throwTimer >= throwDuration)
            {
                isThrowing = false;
                ResetComponents();
            }

            SimulateThrow();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isThrowing)
        {
            isThrowing = false;
            rb.isKinematic = false;
            ResetComponents();
        }
    }

    public void ThrowToTarget(Transform throwTarget)
    {
        target = throwTarget;
        isThrowing = true;
        rb.isKinematic = true;
        throwTimer = 0f;
    }

    private void SimulateThrow()
    {
        float normalizedTime = throwTimer / throwDuration;

        Vector3 throwPoint = CalculateThrowPoint(transform.position, target.position, normalizedTime);
        Vector3 targetPosition = Vector3.Lerp(transform.position, throwPoint, Time.deltaTime * smoothFactor);
        rb.MovePosition(targetPosition);
    }

    private Vector3 CalculateThrowPoint(Vector3 startPoint, Vector3 targetPoint, float t)
    {
        Vector3 controlPoint = startPoint + (targetPoint - startPoint) * 0.5f;
        controlPoint.y += throwHeight; 

        Vector3 throwPoint = Mathf.Pow(1 - t, 2) * startPoint + 2 * (1 - t) * t * controlPoint + Mathf.Pow(t, 2) * targetPoint;

        return throwPoint;
    }

    private void ResetComponents()
    {
        throwTimer = 0f;
        rb.useGravity = true;
    }

  
}
