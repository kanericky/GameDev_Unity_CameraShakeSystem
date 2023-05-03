using UnityEngine;
using Random = UnityEngine.Random;

namespace CameraShakingSystem
{
    [CreateAssetMenu(fileName = "CameraShaking_Time_Trend", menuName = "Camera shaking profile")]
    public class SOCameraShakeProfile : ScriptableObject
    {
        [Header("Animation Curve")]
        [SerializeField] public AnimationCurve cameraShakeCurveX;
        [SerializeField] public AnimationCurve cameraShakeCurveY;
        [SerializeField] public AnimationCurve cameraShakeCurveZ;

        [Header("Shake Duration")]
        [SerializeField] public float cameraShakeDuration;


        /// <summary>
        /// Get Random value for camera shaking
        /// </summary>
        /// <param name="timeStamp"> A timestamp to get value from animation curve </param>
        /// <returns> Target vector3 value for camera rotation </returns>
        public Vector3 GetRandomTarget(float timeStamp)
        {
            return new Vector3(
                x: Random.Range(-cameraShakeCurveX.Evaluate(timeStamp), cameraShakeCurveX.Evaluate(timeStamp)), 
                y: Random.Range(-cameraShakeCurveY.Evaluate(timeStamp), cameraShakeCurveY.Evaluate(timeStamp)),
                z: Random.Range(-cameraShakeCurveZ.Evaluate(timeStamp), cameraShakeCurveZ.Evaluate(timeStamp)));
        }
    }
}