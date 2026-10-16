using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private Camera _mainCamera;

    private void Awake()
    {
        _mainCamera = Camera.main;
    }

    public void SetCameraY(float y)
    {
        Vector3 pos = _mainCamera.gameObject.transform.position;
        pos.y = y;
        _mainCamera.gameObject.transform.position = pos;
    }
}
