using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    //obejcts and vectors
    public GameObject _camera;
    public GameObject _sun;

    //variables for speed
    public float _rotSpeed = 1;
    public float _moveSpeed = 1;

    //max and minimum for scale
    private Vector3 _maxScale = new Vector3(15f, 15f, 15f);
    private Vector3 _minScale = new Vector3(0.2f, 0.2f, 0.2f);
    private bool _cameraMove = true;

    //rgb variables
    private float _red = 0;
    private float _green = 0;
    private float _blue = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //learned how to rotate here
        //https://docs.unity3d.com/2018.1/Documentation/ScriptReference/Transform.Rotate.html
        transform.Rotate(Vector3.up * _rotSpeed * Time.deltaTime);

        Vector3 currentScale = transform.localScale;
        if (currentScale.x >= _maxScale.x)
        {
            transform.localScale = _maxScale;
            _cameraMove = false;
        }
        else if (currentScale.x <= _minScale.x)
        {
            transform.localScale = _minScale;
            _cameraMove = false;
        }

        //learned RotateAround here
        //https://docs.unity3d.com/ScriptReference/Transform.RotateAround.html
        transform.RotateAround(_sun.transform.position, Vector3.down, _moveSpeed * Time.deltaTime);

        GetComponent<MeshRenderer>().material.color = new Color(_red, _green, _blue);

    }

    public void RotateCube(float magnitude)
    {
        transform.Rotate(Vector3.right * magnitude);
    }

    public void ScaleCube(float magnitude)
    {
        Vector3 currentScale = transform.localScale;
        transform.localScale = transform.localScale * magnitude;
        
        if (currentScale.x >= _maxScale.x && magnitude < 1)
        {
            _cameraMove = true;
        }
        if (currentScale.x <= _minScale.x && magnitude > 1)
        {
            _cameraMove = true;
        }

        //learned how to call methods from other scripts here
        //https://gamedevbeginner.com/how-to-get-a-variable-from-another-script-in-unity-the-right-way/
        //learned GetComponent<>() here
        //https://docs.unity3d.com/ScriptReference/GameObject.GetComponent.html
        CameraBehavior camera = _camera.GetComponent<CameraBehavior>();
        if (_cameraMove)
        {
            camera.ChangeOffset(magnitude);
        }
    }

    public void ChangeSpeed(float value)
    {
        _rotSpeed = value;
    }

    public void ChangeRed(float value)
    {
        _red = value;
    }

    public void ChangeGreen(float value)
    {
        _green = value; 
    }

    public void ChangeBlue(float value)
    {
        _blue = value;
    }

    public void SavePlanet()
    {
        PlayerPrefs.SetFloat("speed", _rotSpeed);
        PlayerPrefs.SetFloat("red", _red);
        PlayerPrefs.SetFloat("green", _green);
        PlayerPrefs.SetFloat("blue", _blue);
    }

    public void LoadPlanet()
    {
        _rotSpeed = PlayerPrefs.GetFloat("speed");
        _red = PlayerPrefs.GetFloat("red");
        _green = PlayerPrefs.GetFloat("green");
        _blue = PlayerPrefs.GetFloat("blue");
    }
}
