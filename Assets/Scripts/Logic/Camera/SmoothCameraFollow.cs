using UnityEngine;

public class SmoothCameraFollow : MonoBehaviour
{
    [SerializeField] private Vector3 _offset;
    [SerializeField] private float _smoothTime = 0.5f;
    [SerializeField] private bool _ignoreX = false;

    private Transform _target;

    private Vector3 _vel = Vector3.zero;

    private void LateUpdate() => 
        FollowTarget();

    private void FollowTarget()
    {
        if (_target != null)
        {
            Vector3 targetPosition = SetNewPosition();

            MoveCameraTo(targetPosition);
        }
    }
    private Vector3 SetNewPosition()
    {
        Vector3 targetPosition = _target.position + _offset;
        targetPosition.z = transform.localPosition.z;

        if (_ignoreX)
        {
            targetPosition.x = 0;
        }

        return targetPosition;
    }

    private void MoveCameraTo(Vector3 targetPosition) => 
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _vel, _smoothTime);

    public void SetTarget(Transform target)
    {
        _target = target;
    }
}
