using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    //obejcts and vectors
    private Vector3 _startPos;
    public GameObject _camera;
    public GameObject _sun;

    //variables for speed
    public float _rotSpeed = 1;
    public float _moveSpeed = 1;

    // Start is called before the first frame update
    void Start()
    {
        _startPos = transform.position;
        transform.position = _startPos;
    }

    // Update is called once per frame
    void Update()
    {
        //learned how to rotate here
        //https://docs.unity3d.com/2018.1/Documentation/ScriptReference/Transform.Rotate.html
        transform.Rotate(Vector3.up * Time.deltaTime * _rotSpeed);

    }

    public void RotateCube(float magnitude)
    {
        transform.Rotate(Vector3.right * magnitude);
    }

    public void ScaleCube(float magnitude)
    {
        transform.localScale = transform.localScale * magnitude;

        //learned how to call methods from other scripts here
        //https://gamedevbeginner.com/how-to-get-a-variable-from-another-script-in-unity-the-right-way/
        //learned GetComponent<>() here
        //https://docs.unity3d.com/ScriptReference/GameObject.GetComponent.html
        CameraBehavior camera = _camera.GetComponent<CameraBehavior>();
        camera.ChangeOffset(magnitude);
    }
}
