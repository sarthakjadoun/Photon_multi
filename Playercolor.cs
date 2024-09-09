using Fusion;
using UnityEngine;

public class Playercolor : NetworkBehaviour
{
    public MeshRenderer renderer;
    [Networked, OnChangedRender(nameof(colorchanged))] 
    public Color Networkcolor { get; set; }

    private void Awake()
    {
        if (renderer == null)
        {
            renderer = GetComponent<MeshRenderer>(); 
        }
    }
    private void Update()
    {
        if(HasStateAuthority && Input.GetKeyDown(KeyCode.B))
        {
            Networkcolor = new Color(Random.Range(0f,1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        }
    }
    void colorchanged()
    {
        renderer.material.color = Networkcolor;
    }
}
