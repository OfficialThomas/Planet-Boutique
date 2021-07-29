using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    public GameObject _player;
    public Vector3 _cameraOffset = new Vector3(0, 5, -10);
    public float _offsetScale = 1;
    public float _moveSpeed = 0.5f;
    private float _offsetMax = 7.5f;
    private float _offsetMin = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 startPos = _player.transform.position + _cameraOffset*_offsetScale;
        transform.position = startPos;
    }

    // Update is called once per frame
    void Update()
    {
        if (_offsetScale > _offsetMax)
        {
            _offsetScale = _offsetMax;
        }
        if (_offsetScale < _offsetMin)
        {
            _offsetScale = _offsetMin;
        }

        Vector3 startPos = transform.position;
        Vector3 endPos = _player.transform.position + _cameraOffset * _offsetScale;

        //relearned Vector3.Lerp() here
        //https://docs.unity3d.com/ScriptReference/Vector3.Lerp.html
        Vector3 movingPos = Vector3.Lerp(startPos, endPos, _moveSpeed * Time.deltaTime);
        transform.position = movingPos;

        //learned LookAt from Unity here
        //https://docs.unity3d.com/ScriptReference/Transform.LookAt.html
        transform.LookAt(_player.transform);        
    }

    public void ChangeOffset(float magnitude)
    {
        _offsetScale = _offsetScale * magnitude;
    }
}
