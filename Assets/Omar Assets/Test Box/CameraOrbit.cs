using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOrbit : MonoBehaviour
{
    #region Attributes of the camera orbitiing Script

    protected Transform _XFrom_Camera;
    protected Transform _XFrom_Parent;

    protected Vector3 _LocalRotation;
    protected float _CameraDistance = 10f;

    public float mouseSensitivity = 4f;
    public float scrollSensitivity = 2f;
    public float orbitDampening = 10f;
    public float scrollDampening = 6f;

    [Header("Orbiting arround Objects Limitations")]
    public bool horizontalRotationIsntLimited = false;
    public float maxHorizontalRotationAngle = 80;
    public float minHorizontalRotationAngle = -80;
    public float maxVerticalRotationAngle = 100;
    public float minVerticalRotationAngle = -20;



    public bool cameraDisabled = false;

    #endregion
    // Start is called before the first frame update
    void Start()
    {
        _XFrom_Camera = this.transform;
        _XFrom_Parent = this.transform.parent;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            cameraDisabled = !cameraDisabled;
        }

        if (Input.GetMouseButton(2))
        {
            if (!cameraDisabled)
            {
                //Rotation of the camera according to mouse coordinatess
                if (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
                {
                    _LocalRotation.x += Input.GetAxis("Mouse X") * mouseSensitivity;
                    _LocalRotation.y -= Input.GetAxis("Mouse Y") * mouseSensitivity;

                    // Clamp the y rotation to horizon and not flipping over at the top;
                    _LocalRotation.x = !horizontalRotationIsntLimited ? Mathf.Clamp(_LocalRotation.x, -80, 80) : _LocalRotation.x;
                    _LocalRotation.y = Mathf.Clamp(_LocalRotation.y, -20, 100);
                }

                //Actual Camera Rig Transformations
                Quaternion quaternion = Quaternion.Euler(_LocalRotation.y, _LocalRotation.x, 0);
                this._XFrom_Parent.rotation = Quaternion.Lerp(this._XFrom_Parent.rotation, quaternion, Time.deltaTime * orbitDampening);
            }
        }

        //Zooming input from our mouse control wheel
        if (Input.GetAxis("Mouse ScrollWheel") != 0f)
        {
            float scrollAmount = Input.GetAxis("Mouse ScrollWheel") * scrollSensitivity;

            //Makes camera zoom faster the further away it is from the target.
            scrollAmount *= (this._CameraDistance * 0.3f);

            this._CameraDistance += scrollAmount * -1f;
            this._CameraDistance = Mathf.Clamp(this._CameraDistance, 1.5f, 100f);
        }

        if (this._XFrom_Camera.localPosition.z != this._CameraDistance * -1f)
        {
            this._XFrom_Camera.localPosition = new Vector3(0f, 0f, Mathf.Lerp(this._XFrom_Camera.localPosition.z, this._CameraDistance * -1f, Time.deltaTime * scrollDampening));
        }

    }
}
