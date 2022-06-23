using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    [SerializeField] private float _speed; 
    [SerializeField] private Joystick _joystick; 

    private Transform _myTransform;
    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
        _myTransform = transform;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var direction = GetDirection();
        Move(direction);
    }

    void Move(Vector2 direction)
    {
        _myTransform.Translate(direction * (_speed * Time.deltaTime));
        ClampFinalPosition();
    }

    private void ClampFinalPosition()
    {
        var viewportpoint = _camera.WorldToViewportPoint(_myTransform.position);
        viewportpoint.x = Mathf.Clamp(viewportpoint.x, 0.03f, 0.97f);
        viewportpoint.y = Mathf.Clamp(viewportpoint.y, 0.03f, 0.97f);
        _myTransform.position = _camera.ViewportToWorldPoint(viewportpoint);
    }

    private Vector2 GetDirection()
    {

        return new Vector2(_joystick.Horizontal,_joystick.Vertical);
        //var horizontalDir = Input.GetAxis("Horizontal");
        //var verticalDir = Input.GetAxis("Vertical");
        //return new Vector2(horizontalDir,verticalDir);
  
    }
}
