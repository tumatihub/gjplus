using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    int horiz, vert;
    [SerializeField] GameObject ballPrefab;
    [SerializeField] GameObject playerPrefab;
    List<GameObject> players = new List<GameObject>();

    GameObject ball;
    GameObject selectedPlayer;
    GameObject playerToPass;

    public delegate void PlayerAction();
    public PlayerAction playerAction;

    void Start()
    {
        GameObject obj;
        obj = Instantiate(playerPrefab, new Vector3(3, 3, 0), Quaternion.identity);
        players.Add(obj);
        obj = Instantiate(playerPrefab, new Vector3(6, 3, 0), Quaternion.identity);
        players.Add(obj);
        obj = Instantiate(playerPrefab, new Vector3(5, 7, 0), Quaternion.identity);
        players.Add(obj);
        selectedPlayer = players[0];
        playerToPass = players[1];
        ball = Instantiate(ballPrefab, selectedPlayer.transform);
        playerAction = Move;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerInput();
    }

    public void CallAction()
    {
        playerAction();
    }

    public void Move()
    {
        selectedPlayer.transform.position = new Vector2(selectedPlayer.transform.position.x + horiz,
            selectedPlayer.transform.position.y + vert);
        ClearInput();
    }

    private void PlayerInput()
    {
        
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            horiz = 1;
            playerAction = Move;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            horiz = -1;
            playerAction = Move;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            vert = 1;
            playerAction = Move;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            vert = -1;
            playerAction = Move;
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            playerAction = Pass;
        }
    }

    public void Pass()
    {
        GameObject tmp = selectedPlayer;
        selectedPlayer = playerToPass;
        playerToPass = tmp;
        ball.transform.parent = null;
        StartCoroutine(MoveBall());
        
        playerAction = Move;
    }

    IEnumerator MoveBall()
    {
        while (Vector3.Distance(ball.transform.position, selectedPlayer.transform.position) >= 0.1f)
        {
            print("Moving Ball");
            ball.transform.position = Vector3.MoveTowards(ball.transform.position, selectedPlayer.transform.position, 1f);
            yield return new WaitForSeconds(.1f);
        }
        ball.transform.position = selectedPlayer.transform.position;
        ball.transform.parent = selectedPlayer.transform;

    }

    private void ClearInput()
    {
        horiz = 0;
        vert = 0;
    }
}
