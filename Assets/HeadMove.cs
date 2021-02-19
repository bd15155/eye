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
		//if (headPose.IsRecent())
		{
			Head.transform.localRotation = Quaternion.Lerp(Head.transform.localRotation, headPose.Rotation, Time.unscaledDeltaTime * Responsiveness);
			//print("HeadPose Position (X,Y,Z): " + headPose.Position.x + ", " + headPose.Position.y + ", " + headPose.Position.z);
            print("HeadPose Rotation (X,Y,Z): " + headPose.Rotation.eulerAngles.x + ", " + headPose.Rotation.eulerAngles.y + ", " + headPose.Rotation.eulerAngles.z);
		}
	}
}
　　　　　　　　　　　　       }
