using UnityEngine;

namespace CameraShakingSystem
{
    public class SCameraShakeComponent : MonoBehaviour
    {
        [Header("Profile Data")]
        public SOCameraShakeProfile cameraShakeProfile; //Profile that stores all the camera shake config

        private Vector3 _targetRotation; // Target camera rotation value
        private Vector3 _rotationBeforeShake;
        
        private bool _isShakingFinished;
        private float _timeStamp;

        private void Start()
        {
            _isShakingFinished = true;
        }

        private void LateUpdate()
        {
            if (_timeStamp >= cameraShakeProfile.cameraShakeDuration) ResetCameraShake();
            
            if (_isShakingFinished) return;

            _targetRotation = cameraShakeProfile.GetRandomTarget(timeStamp: _timeStamp);
            _timeStamp += Time.deltaTime;
            
            transform.rotation = Quaternion.Euler(_targetRotation);
        }

        /// <summary>
        /// Play camera shake effect
        /// </summary>
        public void PlayCameraShake()
        {
            if (!_isShakingFinished)
            {
                Debug.LogWarning("Last camera shaking is not finished");
                return;
            }
            
            _rotationBeforeShake = transform.rotation.eulerAngles;
            _isShakingFinished = false;
        }

        /// <summary>
        /// Reset the camera shaking system
        /// </summary>
        private void ResetCameraShake()
        {
            _timeStamp = 0f;
            _isShakingFinished = true;
            transform.rotation = Quaternion.Euler(_rotationBeforeShake);
        }
        
    }
}