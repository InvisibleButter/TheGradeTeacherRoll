using System;
using Exames;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using Random = UnityEngine.Random;

public class Dice : MonoBehaviour
{

    private Rigidbody rigid;
    private bool isFinished;
    float VELOCITY_THRESHOLDE=0.1f;
    float ROTATION_THRESHOLD = 0.1f;
    public int result = 0;
    public UnityEvent<Dice> diceRollFinishedEvent;
    private bool wasMoved = false;
    
    private bool _isLocked;

    public bool IsLocked
    {
        get => _isLocked;
        set
        {
            _isLocked = value;
            
            //todo just testing, later material or something
            transform.parent.gameObject.SetActive(!value);
        }
    }

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }

    public void RollDice()
    {
        result = 0;
        IsLocked = false;
        rigid.constraints = RigidbodyConstraints.None;
        rigid.isKinematic = false;

        rigid.AddForce(new Vector3(Random.Range(-100,100), 300, Random.Range(-100, 100)));
        rigid.AddTorque(new Vector3(Random.Range(-100, 100), Random.Range(-100, 100), Random.Range(-100, 100)));
        isFinished = false;
        wasMoved = false;
    }

    private void Update()
    {
        if (rigid.velocity.magnitude > VELOCITY_THRESHOLDE && !wasMoved)
        {
            wasMoved = true;
        }
        
        if(!isFinished&&wasMoved)
        {
            if(rigid.velocity.magnitude<VELOCITY_THRESHOLDE)
            {
                isFinished = true;
                result = checkResults();
                //Brennen verhindern

                if (result == 0)
                {
                    Debug.LogWarning("** ich bin ne 0");
                    RollDice();
                }
                else
                {
                    diceRollFinishedEvent.Invoke(this);
                }
                
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

    private void OnMouseDown()
    {
        if (!IsLocked)
        {
            ExamManager.Instance.SetDice(this);
            ExamManager.Instance.ShowDiceVal(this, false);
        }
    }

    private void OnMouseEnter()
    {
        if (!_isLocked && result != 0)
        {
            ExamManager.Instance.ShowDiceVal(this, true);
        }
    }
    
    private void OnMouseExit()
    {
        ExamManager.Instance.ShowDiceVal(this, false);
    }

    public void SetToSLot(Vector3 target)
    {
        transform.position = target;   
        
        rigid.constraints = RigidbodyConstraints.FreezeRotation;
        rigid.constraints = RigidbodyConstraints.FreezePositionX;
        rigid.constraints = RigidbodyConstraints.FreezePositionZ;

        rigid.isKinematic = true;
    }
}
