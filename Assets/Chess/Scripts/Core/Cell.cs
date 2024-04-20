using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    private bool _isOccupied;
    private string _piceName;
    private Color _color;

    public Color Color { get => _color; set => _color = value; }

    public bool IsOccupied{ get => _isOccupied; set =>_isOccupied = value; }

    public string PiceName { get => _piceName; set => _piceName = value; }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
