using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterial : MonoBehaviour
{
    private string MaterialName = "Male 1";
    // Start is called before the first frame update
    void Start()
    {
        Material ChangeColor = Resources.Load<Material>(MaterialName);
        SkinnedMeshRenderer skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();
        skinnedMeshRenderer.material = ChangeColor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
