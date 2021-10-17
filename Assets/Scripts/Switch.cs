using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public string ActivatorObjectTag;
    public Material InactiveMaterial;
    public Material ActiveMaterial;

    private MeshRenderer _meshRenderer;
    private int _collidingActivators;

    void Awake() => _meshRenderer = gameObject.GetComponent<MeshRenderer>();

    void Update()
    {

        if(_collidingActivators > 0)
            _meshRenderer.material = ActiveMaterial;
        else
            _meshRenderer.material = InactiveMaterial;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == ActivatorObjectTag)
            _collidingActivators++;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == ActivatorObjectTag)
            _collidingActivators--;
    }
}
