using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManagement : MonoBehaviour
{
    [SerializeField]
    private int score = 0;
    public int Score
    {
        get { return score; }
        set
        {
            //SetScore(value);
            score = value;
            UIManagement.instance.SetScore(score, isStartGame);
            
        }
    }
    public bool isStartGame = false;
    public static GameManagement instance = null;
    public PlayerControl m_player;
    public FloorController m_floor;
    public TriangleController m_triangle;
    public TriangleController m_coin;
    // Start is called before the first frame update

    void Awake()
    {
        if(instance == null)
            instance = this;
        
    }
    void Start()
    {
        isStartGame = true;
        SetupControl();
    }

    public void PlusScore(float factor){
        score += (int)(10 * factor);
    }
    // Update is called once per frame
    void Update()
    {
        if (m_player.isDead){
            isStartGame = false;
            SetupControl();
        }
        
        
    }

    void SetupControl(){
        m_player.SettingSimulated();
        UIManagement.instance.SetupControl(isStartGame);
        UIManagement.instance.SetScore(score, isStartGame);
    }

    public void ResetLevel()
    {
        SceneManager.LoadScene("MainGame");
    }
}
