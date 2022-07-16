using UnityEngine;
using UnityEngine.Events;

public class Dice : MonoBehaviour
{

    private Rigidbody rigid;
    private bool isFinished;
    float VELOCITY_THRESHOLDE=0.1f;
    float ROTATION_THRESHOLD = 0.1f;
    public int result = 0;
    public UnityEvent<Dice> diceRollFinishedEvent;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }

    public void RollDice()
    {
        rigid.AddForce(new Vector3(Random.Range(-100,100), 300, Random.Range(-100, 100)));
        rigid.AddTorque(new Vector3(Random.Range(-100, 100), Random.Range(-100, 100), Random.Range(-100, 100)));
        isFinished = false;
    }

    private void Update()
    {
        if(!isFinished)
        {
            if(rigid.velocity.magnitude<VELOCITY_THRESHOLDE)
            {
                isFinished = true;
                result = checkResults();
                //Brennen verhindern
                diceRollFinishedEvent.Invoke(this);
            }
        }
    }

    private int checkResults()
    {

        
        float up = Mathf.Abs(transform.up.y-Vector3.up.y);
        float forward = Mathf.Abs(transform.forward.y-Vector3.up.y);
        float right = Mathf.Abs(transform.right.y - Vector3.up.y);

        if(up<ROTATION_THRESHOLD)return 3;
        if(up > 2-ROTATION_THRESHOLD)return 4;

        if(forward < ROTATION_THRESHOLD)return 6;
        if(forward > 2 - ROTATION_THRESHOLD)return 1;

        if(right < ROTATION_THRESHOLD)return 2;
        if(right > 2 - ROTATION_THRESHOLD)return 5;

        return 0;
     

    }
}
