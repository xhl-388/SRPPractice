using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MeshBall : MonoBehaviour
{
    private static int baseColorId = Shader.PropertyToID("_BaseColor");

    [SerializeField] private Mesh mesh = default;

    [SerializeField] private Material material = default;

    private Matrix4x4[] _matrices = new Matrix4x4[1023];
    private Vector4[] _baseColors = new Vector4[1023];

    private MaterialPropertyBlock _block;

    private void Awake()
    {
        for (int i = 0; i < _matrices.Length; i++)
        {
            _matrices[i] = 
                Matrix4x4.TRS(Random.insideUnitSphere * 10.0f, 
                    Quaternion.Euler(Random.value*360f,Random.value*360f,Random.value*360f), 
                    Vector3.one*Random.Range(0.5f,1.5f));
            _baseColors[i] = new Vector4(Random.value, Random.value, Random.value,Random.Range(0.5f,1.0f));
        }
    }

    private void Update()
    {
        if (_block == null)
        {
            _block = new MaterialPropertyBlock();
            _block.SetVectorArray(baseColorId,_baseColors);
        }
        Graphics.DrawMeshInstanced(mesh,0,material,_matrices,1023,_block);
    }
}
