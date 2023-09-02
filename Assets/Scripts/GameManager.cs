using Unity.MLAgents.Integrations.Match3;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int playerScore { get; private set; }
    public int computerScore { get; private set; }

    [SerializeField] private Ball ball;

    [SerializeField] private Text playerScoreText;
    [SerializeField] private Text computerScoreText;
    [SerializeField] private Text timeText;
    public GameObject bgsound;
    public AudioSource hover;

    public void Awake()
    {
        if (bgsound != null)
        {
            DontDestroyOnLoad(bgsound);
        }
    }
    private void Start()
    {
        NewGame();
    }

    private void Update()
    {
        float min = Mathf.Floor((Timer.timeRemaining / 60f));
        float sec = Mathf.Floor(Timer.timeRemaining - min * 60f);
        timeText.text = min.ToString() + " : " + sec.ToString();
        Debug.Log(Timer.timeRemaining);
        if (Input.GetKeyDown(KeyCode.R))
        {
            NewGame();
        }
        if((playerScore == 5))
        {
            Debug.Log("khatam");
            Invoke("Win", 0.2f);
        }
        else if ((computerScore == 5))
        {
            Debug.Log("comp_khatam");
            Invoke("Lose", 0.2f);
        }
    }

    public void HoverSound()
    {
        hover.Play();
    }

    public void Win()
    {
        SceneManager.LoadScene("Win");
    }

    public void Lose()
    {
        SceneManager.LoadScene("Lose");
    }

    public void NewGame()
    {
        SetPlayerScore(0);
        SetComputerScore(0);
    }

    public void OnPlayerScored()
    {
        SetPlayerScore(playerScore + 1);
    }

    public void OnComputerScored()
    {
        SetComputerScore(computerScore + 1);
    }

    private void SetPlayerScore(int score)
    {
        playerScore = score;
        playerScoreText.text = score.ToString();
    }

    private void SetComputerScore(int score)
    {
        computerScore = score;
        computerScoreText.text = score.ToString();
    }

}
    