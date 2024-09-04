using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshSortingLayer : MonoBehaviour
{

    public string sortingLayerName;

    // Start is called before the first frame update
    void Start()
    {
        MeshRenderer mesh = GetComponent<MeshRenderer>();
        mesh.sortingLayerName = sortingLayerName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
