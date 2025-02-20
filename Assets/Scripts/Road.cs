using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;

public class road : MonoBehaviour
{
    public float speed;

    [SerializeField]private Renderer bgRenderer;

    private void Start()
    {
        bgRenderer = GetComponent<Renderer>();
    }
    private void Update()
    {
        
        bgRenderer.material.mainTextureOffset += new Vector2(0, speed * Time.deltaTime);
    }
}