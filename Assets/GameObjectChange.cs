using UnityEngine;
using Tobii.Gaming;


[RequireComponent(typeof(GazeAware))]
[RequireComponent(typeof(MeshRenderer))]
public class GameObjectChange : MonoBehaviour
{

	public Color selectionColor;
	public GameObject LookTargetSub;
	public GameObject LookTarget;
	public Vector3 iniLookTargetSubPos;
	public Quaternion iniLookTargetSubRot;
	private GazeAware _gazeAwareComponent;
	private MeshRenderer _meshRenderer;
	

	private Color _deselectionColor;
	private Color _lerpColor;
	private float _fadeSpeed = 0.1f;


	// Set the lerp color
	void Start()
	{
		_gazeAwareComponent = GetComponent<GazeAware>();
		_meshRenderer = GetComponent<MeshRenderer>();
		_lerpColor = _meshRenderer.material.color;
		_deselectionColor = Color.white;
		Vector3 iniLookTargetSubPos = LookTargetSub.transform.position;
		Quaternion iniLookTargetSubRot = LookTargetSub.transform.rotation;
	}

	//Lerping the color
	void Update()
	{
		Vector3 LookTargetSub_Pos = LookTargetSub.transform.position;
		if (_meshRenderer.material.color != _lerpColor)
		{
			_meshRenderer.material.color = Color.Lerp(_meshRenderer.material.color, _lerpColor, _fadeSpeed);
		}
		

		// Change the GameObject of the cube
		if (_gazeAwareComponent.HasGazeFocus)
		{
			SetLerpColor(selectionColor);
			LookTargetSub.transform.position = new Vector3(LookTargetSub_Pos.x , LookTargetSub_Pos.y , LookTargetSub_Pos.z + 0.1f);
			LookTargetSub.transform.rotation = LookTarget.transform.rotation;
		}
		else
		{
			
			SetLerpColor(_deselectionColor);
			LookTargetSub.transform.position = iniLookTargetSubPos;
			LookTargetSub.transform.rotation = iniLookTargetSubRot;
		}
	}

	//Update the color, which should used for the lerping
	public void SetLerpColor(Color lerpColor)
	{
		this._lerpColor = lerpColor;
	}
}
