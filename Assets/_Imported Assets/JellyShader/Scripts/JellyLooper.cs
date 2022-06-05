using UnityEngine;

namespace JellyShader.Scripts
{
	public class JellyLooper : MonoBehaviour 
	{
		private Renderer _modelRenderer;
		private float _controlTime;

		private void Awake()
		{
			_modelRenderer = GetComponent<MeshRenderer>();
		}

		private void Start () 
		{
        
			var upscaleT = transform.position;
			upscaleT.y *= 1.25f;
			_modelRenderer.material.SetVector("_ModelOrigin", transform.position);
			_modelRenderer.material.SetVector("_ImpactOrigin", upscaleT);
		}
	
		private void Update () 
		{
			if (_controlTime > 25)
			{
				_controlTime = 0;
			}
			_controlTime += Time.deltaTime;
			_modelRenderer.material.SetFloat("_ControlTime", _controlTime);
		}
	}
}
