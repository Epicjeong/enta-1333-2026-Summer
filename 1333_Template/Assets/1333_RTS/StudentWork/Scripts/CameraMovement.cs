using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private float _xbounds;
    [SerializeField] private float _ybounds;
    [SerializeField] private Vector2 _panDirection;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 move = Vector2.zero;

        if (_panDirection.x < _xbounds) move.x = -1;
        else if (_panDirection.x > 1920 - _xbounds) move.x = 1;
        else move.x = 0;

        if (_panDirection.y < _ybounds) move.y = -1;
        else if (_panDirection.y > 1080 - _ybounds) move.y = 1;
        else move.y = 0;

        move = Quaternion.Euler(0f, transform.eulerAngles.y, 0f) * move.normalized;
        transform.Translate(Time.deltaTime * 10 * move);
    }

    public void MousePosition(InputAction.CallbackContext context)
    {
        _panDirection = context.ReadValue<Vector2>();
    }

    //public void WASDControls(InputAction.CallbackContext context)
    //{
    //    Vector2 input = context.ReadValue<Vector2>();
    //    _panDirection.x = 1920 * input.x;
    //    _panDirection.y = 1080 * input.y;
    //    if (context.canceled) _panDirection = Vector2.zero;
    //}

    public void ScrollZoom(InputAction.CallbackContext context)
    {
        _camera.fieldOfView = _camera.fieldOfView - context.ReadValue<Vector2>().y;
    }
}
