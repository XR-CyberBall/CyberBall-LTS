using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public BallController ballController;
    private Queue<Ball_path> Ball_pathQueue = new Queue<Ball_path>();
    public Ball_path CP_Holding_Ball;
    public Ball_path NP_Holding_Ball;
    public Ball_path PP_Holding_Ball;
    private List<Transform> characters = new List<Transform>();
    private Transform[] targets;
    public Vector3[] initialTargetPositions;
    public List<Plyers_Status> players_status;
    public static GameManager Instance; // A static reference to the GameManager instance
    public bool Show_notification = false;
    public class Ball_path
    {
      public  Enums.PLAYER_INDEX playerindex;
        public Ball_path(Enums.PLAYER_INDEX _playerindex)
        {
            playerindex = _playerindex;
        }

    }

    public Notification_Game_Manager notification_manager;

    private IEnumerator PrepareNextPlayerCoroutine()
    {
        if (NP_Holding_Ball==null)
        {
            Prepare_next_player();

            yield return new WaitForSeconds(3f);
        }
        while (Ball_pathQueue.Count > 0)
        {

            throw_ball();
            if (PP_Holding_Ball != null)
            {
                Debug.Log("previous Player index : "+ PP_Holding_Ball.playerindex);
            }

            Debug.Log("Current Player index : " + CP_Holding_Ball.playerindex);
            Debug.Log("Next Player index : " + NP_Holding_Ball.playerindex);
           


            


            yield return new WaitForSeconds(7f);

        }

    }


    void Update()
    {

    }
    void Awake()
    {
        if (Instance == null) // If there is no instance already
        {
            Instance = this;
        }
        else if (Instance != this) // If there is already an instance and it's not `this` instance
        {
            Destroy(gameObject); // Destroy the GameObject, this component is attached to
        }

    }
    private void Start()
    {

        StartCoroutine(PrepareNextPlayerCoroutine());


    }






    public GameManager()
    {
        Ball_pathQueue.Enqueue(new Ball_path(Enums.PLAYER_INDEX.LEFT));
        Ball_pathQueue.Enqueue(new Ball_path(Enums.PLAYER_INDEX.RIGHT));

        Ball_pathQueue.Enqueue(new Ball_path(Enums.PLAYER_INDEX.LEFT));

        Ball_pathQueue.Enqueue(new Ball_path(Enums.PLAYER_INDEX.RIGHT));

        Ball_pathQueue.Enqueue(new Ball_path(Enums.PLAYER_INDEX.LEFT));
        Ball_pathQueue.Enqueue(new Ball_path(Enums.PLAYER_INDEX.RIGHT));
        Ball_pathQueue.Enqueue(new Ball_path(Enums.PLAYER_INDEX.LEFT));
        Ball_pathQueue.Enqueue(new Ball_path(Enums.PLAYER_INDEX.ME));

        Ball_pathQueue.Enqueue(new Ball_path(Enums.PLAYER_INDEX.RIGHT));
        Ball_pathQueue.Enqueue(new Ball_path(Enums.PLAYER_INDEX.LEFT));
        Ball_pathQueue.Enqueue(new Ball_path(Enums.PLAYER_INDEX.RIGHT));
        Ball_pathQueue.Enqueue(new Ball_path(Enums.PLAYER_INDEX.LEFT));
        Ball_pathQueue.Enqueue(new Ball_path(Enums.PLAYER_INDEX.RIGHT));
        Ball_pathQueue.Enqueue(new Ball_path(Enums.PLAYER_INDEX.LEFT));
        Ball_pathQueue.Enqueue(new Ball_path(Enums.PLAYER_INDEX.RIGHT));
        Ball_pathQueue.Enqueue(new Ball_path(Enums.PLAYER_INDEX.LEFT));
        Ball_pathQueue.Enqueue(new Ball_path(Enums.PLAYER_INDEX.RIGHT));
        Ball_pathQueue.Enqueue(new Ball_path(Enums.PLAYER_INDEX.LEFT));
        Ball_pathQueue.Enqueue(new Ball_path(Enums.PLAYER_INDEX.RIGHT));
        Ball_pathQueue.Enqueue(new Ball_path(Enums.PLAYER_INDEX.LEFT));
        Ball_pathQueue.Enqueue(new Ball_path(Enums.PLAYER_INDEX.RIGHT));
        Ball_pathQueue.Enqueue(new Ball_path(Enums.PLAYER_INDEX.LEFT));
        Ball_pathQueue.Enqueue(new Ball_path(Enums.PLAYER_INDEX.RIGHT));
        Ball_pathQueue.Enqueue(new Ball_path(Enums.PLAYER_INDEX.LEFT));
        Ball_pathQueue.Enqueue(new Ball_path(Enums.PLAYER_INDEX.RIGHT));
        Ball_pathQueue.Enqueue(new Ball_path(Enums.PLAYER_INDEX.LEFT));
        Ball_pathQueue.Enqueue(new Ball_path(Enums.PLAYER_INDEX.RIGHT));
        Ball_pathQueue.Enqueue(new Ball_path(Enums.PLAYER_INDEX.LEFT));
        Ball_pathQueue.Enqueue(new Ball_path(Enums.PLAYER_INDEX.RIGHT));
        Ball_pathQueue.Enqueue(new Ball_path(Enums.PLAYER_INDEX.LEFT));
        Ball_pathQueue.Enqueue(new Ball_path(Enums.PLAYER_INDEX.RIGHT));
        Ball_pathQueue.Enqueue(new Ball_path(Enums.PLAYER_INDEX.LEFT));
        Ball_pathQueue.Enqueue(new Ball_path(Enums.PLAYER_INDEX.RIGHT));
        Ball_pathQueue.Enqueue(new Ball_path(Enums.PLAYER_INDEX.LEFT));
        Ball_pathQueue.Enqueue(new Ball_path(Enums.PLAYER_INDEX.RIGHT));
        Ball_pathQueue.Enqueue(new Ball_path(Enums.PLAYER_INDEX.LEFT));
        Ball_pathQueue.Enqueue(new Ball_path(Enums.PLAYER_INDEX.RIGHT));
        Ball_pathQueue.Enqueue(new Ball_path(Enums.PLAYER_INDEX.LEFT));
        Ball_pathQueue.Enqueue(new Ball_path(Enums.PLAYER_INDEX.RIGHT));
        Ball_pathQueue.Enqueue(new Ball_path(Enums.PLAYER_INDEX.LEFT));
        Ball_pathQueue.Enqueue(new Ball_path(Enums.PLAYER_INDEX.RIGHT));
        Ball_pathQueue.Enqueue(new Ball_path(Enums.PLAYER_INDEX.LEFT));
        Ball_pathQueue.Enqueue(new Ball_path(Enums.PLAYER_INDEX.RIGHT));
        Ball_pathQueue.Enqueue(new Ball_path(Enums.PLAYER_INDEX.LEFT));
        Ball_pathQueue.Enqueue(new Ball_path(Enums.PLAYER_INDEX.RIGHT));
        Ball_pathQueue.Enqueue(new Ball_path(Enums.PLAYER_INDEX.LEFT));
        Ball_pathQueue.Enqueue(new Ball_path(Enums.PLAYER_INDEX.RIGHT));
        Ball_pathQueue.Enqueue(new Ball_path(Enums.PLAYER_INDEX.LEFT));
        Ball_pathQueue.Enqueue(new Ball_path(Enums.PLAYER_INDEX.RIGHT));
    }

   
    public void Prepare_next_player()
    {


    
        if (CP_Holding_Ball != null)
         {

                PP_Holding_Ball = CP_Holding_Ball;

             }
        if (CP_Holding_Ball == null)
        {
            CP_Holding_Ball = Ball_pathQueue.Dequeue();

        }
        else
        {
            CP_Holding_Ball = NP_Holding_Ball;

        }
        NP_Holding_Ball = Ball_pathQueue.Dequeue();
        
    }

    public void throw_ball()
    {
        if (CP_Holding_Ball.playerindex==Enums.PLAYER_INDEX.LEFT | CP_Holding_Ball.playerindex==Enums.PLAYER_INDEX.RIGHT ) {


            if (CP_Holding_Ball.playerindex == Enums.PLAYER_INDEX.LEFT)
            {
                Plyers_Status player = players_status.Find(el => el.playerindex == NP_Holding_Ball.playerindex);
                ballController.ThrowToTarget(player.targetHand);

            }
            else if (CP_Holding_Ball.playerindex == Enums.PLAYER_INDEX.RIGHT)
            {
                Plyers_Status player = players_status.Find(el => el.playerindex == NP_Holding_Ball.playerindex);
                ballController.ThrowToTarget(player.targetHand);
            }

            Prepare_next_player();
            Update_next_Rceiver_player_Env();
            notification_manager.Start_Notification_counter(7);

        }


        if (CP_Holding_Ball.playerindex == Enums.PLAYER_INDEX.ME)
        {
            notification_manager.update_Notification_counter_message("It is your turn");

        }
        else if(CP_Holding_Ball.playerindex==Enums.PLAYER_INDEX.ME) {

        }

    }

    public void check_Plyer_throwing()
    {



    }
    void Update_next_Rceiver_player_Env()
    {
        players_status.ForEach(el =>
        {

            if (el.playerindex == NP_Holding_Ball.playerindex)
            {
                el.Waiting_circle_ball(Color.green, Color.green);
            }
            else
            {
                el.Reset_circle_ball();

            }

        });
    }


   


    // Start is called before the first frame update
  private int _currentTarget=0;
    public void update_the_Circle_color(Color startcolor, Color endColor)
    {




    }

}







