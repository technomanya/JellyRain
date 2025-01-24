using UnityEngine;

public class JellyBehaviour : MonoBehaviour
{
    public int jellyId;

    public void ChangeMaterial(Material mat)
    {
        GetComponent<MeshRenderer>().material = mat;
    }
}
