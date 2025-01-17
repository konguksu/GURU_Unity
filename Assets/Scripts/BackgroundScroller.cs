using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{

    [Range(-1f, 2f)]
    public float scrollSpeed = 0.5f;
    float offset;
    Material mat;

    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<Renderer>().material;
        
    }

    // Update is called once per frame
    void Update()
    {
        offset += (Time.unscaledDeltaTime * scrollSpeed) / 10f;
        mat.SetTextureOffset("_MainTex", new Vector2(offset, 0));
        
    }


}
