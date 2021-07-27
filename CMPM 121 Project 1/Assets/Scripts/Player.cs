using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //position for the planet botique
    private Vector3 _startPos;
    public GameObject _posRotate;
    public GameObject _posScale;
    public GameObject _posColor;
    private bool _isEditing = false;

    //variables for speed
    public float _rotSpeed = 1;

    // Start is called before the first frame update
    void Start()
    {
        _startPos = transform.position;    
    }

    // Update is called once per frame
    void Update()
    {
        //learned how to rotate here
        //https://docs.unity3d.com/2018.1/Documentation/ScriptReference/Transform.Rotate.html
        transform.Rotate(Vector3.up * Time.deltaTime * _rotSpeed);

        //learned about KeyCodes here
        //https://docs.unity3d.com/ScriptReference/Input.GetKeyDown.html
        if (_isEditing)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                transform.position = _startPos;
                _isEditing = false;
            }

        }
        else
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                transform.position = _posRotate.transform.position;
                _isEditing = true;
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                transform.position = _posScale.transform.position;
                _isEditing = true;
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                transform.position = _posColor.transform.position;
                _isEditing = true;
            }
        }
        
    }
}
