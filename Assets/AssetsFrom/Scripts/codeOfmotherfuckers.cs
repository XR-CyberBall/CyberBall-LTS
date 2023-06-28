using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class codeOfmotherfuckers : MonoBehaviour
{
    // Start is called before the first frame update
    private float _torqueForce = 2f;
    private float _throwAngle = 30f;
    private Transform _holdingPoint;

    private Rigidbody _rigidbody;
    private GameManager _gameManager;
    private float currentGravity;

    private float timer = 0f;
    private float movementDuration = 0.5f;

    private bool _isMoving;
    private Vector3 initialPosition;

    private void Start()
    {
        _gameManager = GameManager.Instance;
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.useGravity = false;
        currentGravity = Physics.gravity.magnitude;
    }

    private void Update()
    {
    
    }

    private void MoveTarget()
    {
        if (_isMoving)
        {
            timer += Time.deltaTime;

            // Move the object towards the target object
            _holdingPoint.position = transform.position;

            if (timer >= movementDuration)
            {
                // Return the object to its initial position
                _holdingPoint.position = initialPosition;

                // Reset variables
                _isMoving = false;
                timer = 0f;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        _holdingPoint = other.transform;
        transform.position = _holdingPoint.position;
        _rigidbody.constraints = RigidbodyConstraints.FreezeAll;
        _rigidbody.useGravity = false;

        transform.SetParent(_holdingPoint.parent);
    }

    private void Throw(Transform target)
    {
        Vector3 p = target.position;

        // Selected angle in radians
        float angle = _throwAngle * Mathf.Deg2Rad;

        // Positions of this object and the target on the same plane
        Vector3 planarTarget = new Vector3(p.x, 0, p.z);
        Vector3 planarPostion = new Vector3(transform.position.x, 0, transform.position.z);
        // Debug.Log("X: " + transform.position.x + " Y: " + transform.position.y + " Z: " + transform.position.z);

        // Planar distance between objects
        float distance = Vector3.Distance(planarTarget, planarPostion);
        // Distance along the y axis between objects
        float yOffset = transform.position.y - p.y;

        float initialVelocity = (1 / Mathf.Cos(angle)) * Mathf.Sqrt((0.5f * currentGravity * Mathf.Pow(distance, 2)) / (distance * Mathf.Tan(angle) + yOffset));

        Vector3 velocity = new Vector3(0, initialVelocity * Mathf.Sin(angle), initialVelocity * Mathf.Cos(angle));

        // Rotate our velocity to match the direction between the two objects
        float angleBetweenObjects = Vector3.Angle(Vector3.forward, planarTarget - planarPostion) * (p.x > transform.position.x ? 1 : -1);
        Vector3 finalVelocity = Quaternion.AngleAxis(angleBetweenObjects, Vector3.up) * velocity;

        // Fire!
        _rigidbody.angularVelocity = Vector3.zero;
        _rigidbody.velocity = finalVelocity;
        _rigidbody.AddTorque(new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f)) * _torqueForce, ForceMode.Impulse);
        _rigidbody.useGravity = true;

        // Alternative way:
        // rigid.AddForce(finalVelocity * rigid.mass, ForceMode.Impulse);
        _isMoving = true;
    }
}
