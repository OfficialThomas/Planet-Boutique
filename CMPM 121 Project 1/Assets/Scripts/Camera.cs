using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject _player;
    public Vector3 _cameraOffset = new Vector3(0, 5, -10);
    public float _offsetScale = 1;
    public float _moveSpeed = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 startPos = _player.transform.position + _cameraOffset*_offsetScale;
        transform.position = startPos;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 startPos = transform.position;
        Vector3 endPos = _player.transform.position + _cameraOffset * _offsetScale;

        //relearned Vector3.Lerp() here
        //https://docs.unity3d.com/ScriptReference/Vector3.Lerp.html
        Vector3 movingPos = Vector3.Lerp(startPos, endPos, _moveSpeed * Time.deltaTime);

        //learned Mathf.Abs() here
        //https://docs.unity3d.com/ScriptReference/Mathf.Abs.html
        if (Mathf.Abs(endPos.z - startPos.z) < 0.01)
        {
            transform.position = endPos;
        }
        else
        {
            transform.position = movingPos;
        }
        
    }
}
