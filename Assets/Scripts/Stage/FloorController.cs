using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorController : MonoBehaviour
{
    public float speed = 1;
    public float limit_CoordinateX = -2.4f;

    public float limit_min = 1.0f;
    public float limit_max = 1.75f;
    public float resetTo = 0.8f;

    [SerializeField]
    private Transform[] m_floor;
    // Start is called before the first frame update
    void Start()
    {
        m_floor = new Transform[this.transform.childCount];
        for (int i = 0; i < m_floor.Length; i++)
        {
            m_floor[i] = this.transform.GetChild(i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManagement.instance.isStartGame)
        {
            for (int i = 0; i < m_floor.Length; i++)
            {
                m_floor[i].position -= new Vector3(speed * Time.deltaTime, 0, 0);
                if (m_floor[i].position.x < limit_CoordinateX)
                {
                    m_floor[i].position = new Vector3(resetTo, -5, 0);
                    m_floor[i].localScale = new Vector3(Random.Range(limit_min, limit_max),1,1);
                }
            }
        }
    }
}
