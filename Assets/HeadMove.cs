//頭のPOSEを取るクラス
using UnityEngine;
using Tobii.Gaming;

namespace TobiiEyeTracking{
	public class HeadMove : MonoBehaviour
{
		public Transform Head;
		public float Responsiveness = 10f;

	void Update()
	{
		var headPose = TobiiAPI.GetHeadPose();
		if (headPose.IsRecent())
		{
			Head.transform.localRotation = Quaternion.Lerp(Head.transform.localRotation, headPose.Rotation, Time.unscaledDeltaTime * Responsiveness);
		}
	}
}
　　　　　　　　　　　　}
