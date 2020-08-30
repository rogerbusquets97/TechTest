using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PostProcessing
{
    [RequireComponent(typeof(Camera))]
    public class PostProcess : MonoBehaviour
    {
        [SerializeField] private Material _PostProcessMat = null;
        [SerializeField] private Material _IdentityMat = null;
        [SerializeField] private bool _EffectActive = true;

        [Tooltip("This value cannot be changed at runtime!")]
        [SerializeField] private int _ScreenHeight = 144;

        private RenderTexture _DownscaledRenderTexture;


        private void OnEnable()
        {
            Camera camera = GetComponent<Camera>();
            int width = Mathf.RoundToInt(camera.aspect * _ScreenHeight);
            _DownscaledRenderTexture = new RenderTexture(width, _ScreenHeight, 16);
            _DownscaledRenderTexture.filterMode = FilterMode.Point;
        }

        private void OnDisable()
        {
            Destroy(_DownscaledRenderTexture);
        }
        private void OnRenderImage(RenderTexture source, RenderTexture destination)
        {
            if (_EffectActive)
            {
                Graphics.Blit(source, _DownscaledRenderTexture, _PostProcessMat);
                Graphics.Blit(_DownscaledRenderTexture, destination, _IdentityMat);
            }
            else
            {
                Graphics.Blit(source, destination);
            }
        }
    }
}