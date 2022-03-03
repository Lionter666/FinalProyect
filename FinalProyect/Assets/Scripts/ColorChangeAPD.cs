using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChangeAPD : MonoBehaviour
{
    [SerializeField] Material material;
    private Renderer rD;

    // Start is called before the first frame update
    void Start()
    {
        rD = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ChangeColor(string mColor)
    {
        if (mColor == "Blue")
        {
            rD.material.color = Color.blue;
        }
        if (mColor == "Green")
        {
            rD.material.color = Color.green;
        }
        if (mColor == "Red")
        {
            rD.material.color = Color.red;
        }
    }
}
