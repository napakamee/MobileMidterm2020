using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleController : MonoBehaviour
{
    public float speed = 1;
    public float limit_CoordinateX = -2.4f;

    public float minDistance = 17;
    public float maxDistance  = 20;
    public float resetX = 0.8f;
    public float resetY = 0;

    [SerializeField]
    private Transform[] m_triangle;
    // Start is called before the first frame update
    void Start()
    {
        m_triangle = new Transform[this.transform.childCount];
        for (int i = 0; i < m_triangle.Length; i++)
        {
            m_triangle[i] = this.transform.GetChild(i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManagement.instance.isStartGame)
        {
            for (int i = 0; i < m_triangle.Length; i++)
            {
                m_triangle[i].position -= new Vector3(speed * Time.deltaTime, 0, 0);
                if (m_triangle[i].position.x < limit_CoordinateX)
                {
                    m_triangle[i].position = new Vector3(resetX, resetY, 0);
                }
            }
        }
    }
}
