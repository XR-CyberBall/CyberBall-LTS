using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform[] characters;
    private Transform[] targets ;
    public Vector3[] initialTargetPositions;

    private int _currentTarget = 0;

    public static GameManager Instance; // A static reference to the GameManager instance

    void Awake()
    {
        if (Instance == null) // If there is no instance already
        {
            Instance = this;
        }
        else if (Instance != this) // If there is already an instance and it's not `this` instance
        {
            Destroy(gameObject); // Destroy the GameObject, this component is attached to
        }

        targets = new Transform[3];

        for(int i=0; i < 3; i++)
        {
            foreach (Transform child in characters[i].GetComponentsInChildren<Transform>())
            {
                if (child.CompareTag("target")) 
                    targets.SetValue(child,i);
            }
        }

        initialTargetPositions = new Vector3[targets.Length];
        for(int i=0; i < targets.Length; i++)
        {
            initialTargetPositions[i] = targets[i].position;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetCurrentTargetIndex()
    {
        return _currentTarget;
    }

    public Vector3 GetInitialTargetPosition()
    {
        return initialTargetPositions[_currentTarget];
    }

    public Transform GetCurrentTarget()
    {
        return targets[_currentTarget];
    }

    public Transform GetLeftTarget()
    {
        _currentTarget = MathMod(_currentTarget - 1, targets.Length);
        return targets[_currentTarget];
    }

    public Transform GetRightTarget()
    {
        _currentTarget = MathMod(_currentTarget + 1, targets.Length);
        return targets[_currentTarget];
    }

    static int MathMod(int a, int b)
    {
        return (Mathf.Abs(a * b) + a) % b;
    }
}
