using System;
using UnityEngine;

[DisallowMultipleComponent]
public class PerObjectMaterialProperties : MonoBehaviour
{
    private static int _baseColorId = Shader.PropertyToID("_BaseColor");
    private static int _cutoffId = Shader.PropertyToID("_Cutoff");

    [SerializeField] private Color _baseColor = Color.white;

    [SerializeField, Range(0.0f, 1.0f)] private float _cutoff = 0.5f; 

    private static MaterialPropertyBlock _block;


    private void Awake()
    {
        OnValidate();
    }

    private void OnValidate()
    {
        if (_block == null)
        {
            _block = new MaterialPropertyBlock();
        }

        _block.SetColor(_baseColorId, _baseColor); 
        _block.SetFloat(_cutoffId,_cutoff);
        GetComponent<Renderer>().SetPropertyBlock(_block);
    }
}
