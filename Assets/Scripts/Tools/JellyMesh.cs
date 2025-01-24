using System;
using UnityEngine;
using UnityEngine.Serialization;

public class JellyMesh : MonoBehaviour
{
    public class JellyVertex
    {
        public int id;
        public Vector3 position;
        public Vector3 velocity;
        public Vector3 force;

        public JellyVertex(int _id, Vector3 _position)
        {
            id = _id;
            position = _position;
        }

        public void Shake(Vector3 _target, float _m, float _s, float _d)
        {
            force = (_target - position) * _s;
            velocity = (velocity + force / _m) * _d;
            position += velocity;
            if ((velocity + force + force / _m).magnitude < 0.001f)
            {
                position = _target;
            }
        }
    }
    public float intensity = 1.0f;
    public float mass = 1.0f;
    public float stiffness = 1.0f;
    public float damping = 0.75f;
    
    private Mesh meshOriginal, meshClone;
    private MeshRenderer renderer;
    private JellyVertex[] verticesJelly;
    private Vector3[] vertexArray;
    void Start()
    {
        meshOriginal = GetComponent<MeshFilter>().sharedMesh;
        meshClone = Instantiate(meshOriginal);
        GetComponent<MeshFilter>().sharedMesh = meshClone;
        renderer = GetComponent<MeshRenderer>();
        
        verticesJelly = new JellyVertex[meshClone.vertices.Length];
        for (int i = 0; i < meshClone.vertices.Length; i++)
        {
            verticesJelly[i] = new JellyVertex(i, transform.TransformPoint(meshClone.vertices[i]));
        }
    }

    private void FixedUpdate()
    {
        vertexArray = meshOriginal.vertices;
        for (int i = 0; i < verticesJelly.Length; i++)
        {
            Vector3 target = transform.TransformPoint(vertexArray[verticesJelly[i].id]);
            float intensityTemp = (1-(renderer.bounds.max.y-target.y)/ renderer.bounds.size.y) * this.intensity;
            verticesJelly[i].Shake(target, mass, stiffness, damping);
            target = transform.InverseTransformPoint(verticesJelly[i].position);
            vertexArray[verticesJelly[i].id] = Vector3.Lerp(vertexArray[verticesJelly[i].id], target, intensityTemp);
        }
        meshClone.vertices = vertexArray;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
