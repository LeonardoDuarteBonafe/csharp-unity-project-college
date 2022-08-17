using UnityEngine;
using UnityEngine.SceneManagement;

public class FollowThePath : MonoBehaviour {

    public Transform[] waypoints;
    
    public float moveSpeed = 500f;
    public int waypointIndex = 0;
    public bool moveAllowed = true;
    public int casasMover = 0;
    private bool statusWaypoint = true;

    public bool acabouJogo = false;

    public DebugTabuleiro debugTabuleiro;
    public GameObject painelTextoVencedor;
    public DebugChangeCard debugCardWaypoint;

    private void Start () {
        painelTextoVencedor.SetActive(false);
        acabouJogo = false;
        moveAllowed = true;
    }
	
	private void Update () {
        if (moveAllowed && (casasMover>0))
        {
            acabouJogo = false;
            Move();
        }
        else
        {
            if (!acabouJogo)
            {
                waypointIndex = debugCardWaypoint.pontuacaoGanha - casasMover;
                transform.position = waypoints[waypointIndex].transform.position;
                statusWaypoint = true;
                Invoke("SumindoTabuleiro", 1);
            }
        }
	}

    private void Move()
    {
        if (statusWaypoint)
        {
            waypointIndex = debugCardWaypoint.pontuacaoGanha - casasMover;
            transform.position = waypoints[waypointIndex].transform.position;
            statusWaypoint = false;
        }
        if (waypointIndex <= waypoints.Length - 2)
        {
            if(waypointIndex == waypoints.Length - 2)
            {
                casasMover++;
            }
            transform.position = Vector2.MoveTowards(transform.position,
            waypoints[waypointIndex + 1].transform.position,
            moveSpeed * Time.deltaTime);
            float varX = transform.position.x - waypoints[waypointIndex + 1].transform.position.x;
            float varY = transform.position.y - waypoints[waypointIndex + 1].transform.position.y;
           if ((varX > -0.005f && varX < 0.0005f) && (varY > -0.005f && varY < 0.005f))
            {
                waypointIndex++;
                casasMover--;
            }
           if(waypointIndex == waypoints.Length - 1)
            {
                painelTextoVencedor.SetActive(true);
                acabouJogo = true;
            }
        }
        else
        {
            painelTextoVencedor.SetActive(true);
        }
    }

    private void SumindoTabuleiro()
    {
         debugTabuleiro.TransicaoTabuleiro(false);
    }

    public void ContinuarJogoAtual()
    {
        acabouJogo = true;
        painelTextoVencedor.SetActive(false);
        SumindoTabuleiro();
    }
}
