using UnityEngine;
using Zenject;

public class CameraController : MonoBehaviour
{
    private Camera _camera;
    private GameZone _gameZone;
    private Vector3 _startPos;

    private float _cameraSpeed;
    private float _targetPosX;
    private float _targetPosZ;
    private float _zoomSensitivity;
    private float _minZoom = 40f;
    private float _maxZoom = 75f;

    private bool _canMove;

    [Inject]
    public void Construct(Camera camera, LevelSettings levelSettings, GameZone gameZone)
    {
        _camera = camera;
        _cameraSpeed = levelSettings.CameraSpeed;
        _zoomSensitivity = levelSettings.ZoomSensitivity;
        _gameZone = gameZone;
        _targetPosX = transform.position.x;
        _targetPosZ = transform.position.z;
    }

    private void Update()
    {
        CameraMovement();
        CameraZoom(Input.GetAxis("Mouse ScrollWheel") * _zoomSensitivity);
    }

    private void CameraMovement()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _canMove = true;
            _startPos = Input.mousePosition;
        }
        else
        {
            if (Input.touchCount == 2)
            {
                var touchZero = Input.GetTouch(0);
                var touchOne = Input.GetTouch(1);

                var touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
                var touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

                var prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
                var currentMagnitude = (touchZero.position - touchOne.position).magnitude;

                var difference = currentMagnitude - prevMagnitude;

                CameraZoom(difference * 0.01f * _zoomSensitivity);

            }
            else
            {
                if (Input.GetMouseButton(0))
                {
                    var posX = Input.mousePosition.x - _startPos.x;
                    var posZ = Input.mousePosition.y - _startPos.y;


                    transform.position = new Vector3(Mathf.Clamp(transform.position.x + posX * Time.deltaTime * _cameraSpeed,
                    -_gameZone.gameObject.GetComponent<MeshRenderer>().bounds.size.x / 2,
                    _gameZone.gameObject.GetComponent<MeshRenderer>().bounds.size.x / 2),
                    transform.position.y,
                    Mathf.Clamp(transform.position.z + posZ * Time.deltaTime * _cameraSpeed,
                    -_gameZone.gameObject.GetComponent<MeshRenderer>().bounds.size.z / 2,
                    _gameZone.gameObject.GetComponent<MeshRenderer>().bounds.size.z / 2));

                    _startPos = Input.mousePosition;
                }
                else
                    _canMove = false;
            }
        }
    }

    private void CameraZoom(float increment)
    {
        if (increment != 0)
            _camera.fieldOfView = Mathf.Clamp(_camera.fieldOfView - increment, _minZoom, _maxZoom);
    }
}