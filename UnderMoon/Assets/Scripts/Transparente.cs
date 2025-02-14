using UnityEngine;

public class Transparente : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public SkinnedMeshRenderer mr;
    Material myMaterial;
    public bool Transparent = false;

    // Use this for initialization
    void Start()
    {
      
      myMaterial = mr.material;
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1) && !Transparent){
            myMaterial.color = new Color(1, 1, 1, 0.3f);
            Transparent = true;
        }else if(Input.GetKeyDown(KeyCode.Alpha1) && Transparent){
            myMaterial.color = new Color(1, 1, 1, 1f);
            Transparent = false;
        }
    }

}
