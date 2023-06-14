using UnityEngine;
using UnityEngine.Animations.Rigging;

public class ReduceTwoBoneIKWeight : MonoBehaviour
{
    public Transform ball;
    public Transform target;
    private float maxDistance = 1f;
    private float reductionFactor = 0.05f;
    private bool _holdingBall;
    
    private Rig _rig;
    private TwoBoneIKConstraint[] _ikConstraints;

    public Transform[] handRefs;
    
    private void Start()
    {
        _rig = transform.GetComponent<Rig>();
        _ikConstraints = GetComponentsInChildren<TwoBoneIKConstraint>();
        if (_rig.weight > 0)
        {
            _holdingBall = true;
        }
    }

    private void Update()
    {
        ReduceWeightAmount();
        
        if (_rig.weight == 0f && _holdingBall)
        {
            // SetParent(target);
            _holdingBall = false;
        }
        
        if (_rig.weight == 1 && !_holdingBall)
        {
            // SetParent(ball);
            _holdingBall = true;
        }
    }

    private void ReduceWeightAmount()
    {
        float weightReduction = 0;
        foreach (TwoBoneIKConstraint ikConstraint in _ikConstraints)
        {
            float distance = Vector3.Distance(ikConstraint.data.tip.transform.position, ball.transform.position);
            weightReduction += Mathf.Clamp01(distance*0.2f /  maxDistance);
        }
        _rig.weight = 1.1f- weightReduction <= 0 ? 0 : 1.1f- weightReduction;
    }
    
    void SetParent(Transform parent)
    {
        foreach (Transform handRef in handRefs)
        {
            if (handRef.parent != parent)
            {
                Vector3 localPosition = handRef.localPosition;
                Quaternion localRotation = handRef.localRotation;
                Vector3 localScale = handRef.localScale;

                handRef.SetParent(parent);

                handRef.localPosition = localPosition;
                handRef.localRotation = localRotation;
                handRef.localScale = localScale;
            }
        }
    }
    
}

