using UnityEngine;
using CameraShakingSystem;

public class SSimpleController : MonoBehaviour
{

    [SerializeField] private Camera mainCamera;

    private SCameraShakeComponent _cameraShake;

    private void Start()
    {
        _cameraShake = mainCamera.GetComponent<SCameraShakeComponent>();
        
        if(!_cameraShake) Debug.LogError("Cannot find SCameraShake component on {0}", mainCamera);
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Camera Shake Triggered");
            _cameraShake.PlayCameraShake();
        }       
    }
}
