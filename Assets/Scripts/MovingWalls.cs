using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingWalls : MonoBehaviour
{   [Header("Para os Lados")]
    [SerializeField] float LeftSidePosition;
    [SerializeField] float RightSidePosition;
    [Header("Para os Lados")]
    [SerializeField] float UpPosition;
    [SerializeField] float DownPosition;

    [SerializeField] float Speed;
    [SerializeField] bool GoUp;
    [SerializeField] bool Positive;

    public bool ChangeDirec;
    private void Update()
    {
        
        if(GoUp)
        {
            if (!Positive)
            {
                if (!ChangeDirec)
                {
                    if (Mathf.Abs(transform.position.x) > Mathf.Abs(UpPosition))
                    {
                        transform.position = new Vector3(transform.position.x + (Speed * Time.deltaTime), transform.position.y, transform.position.z);
                        if (Mathf.Abs(transform.position.x) < Mathf.Abs(UpPosition))
                        {
                            ChangeDirec = true;

                        }
                    }
                }
                else if (ChangeDirec)
                {
                    if (Mathf.Abs(transform.position.x) < Mathf.Abs(DownPosition))
                    {
                        transform.position = new Vector3(transform.position.x - (Speed * Time.deltaTime), transform.position.y, transform.position.z);
                        if (Mathf.Abs(transform.position.x) > Mathf.Abs(DownPosition))
                        {
                            ChangeDirec = false;

                        }
                    }

                }

            } 
            if(Positive)
            {
                if (!ChangeDirec)
                {

                    if (Mathf.Abs(transform.position.x) < Mathf.Abs(UpPosition))
                    {
                        transform.position = new Vector3(transform.position.x + (Speed * Time.deltaTime), transform.position.y, transform.position.z);
                        if (Mathf.Abs(transform.position.x) > Mathf.Abs(UpPosition))
                        {
                            ChangeDirec = true;

                        }
                    }
                }
                else if (ChangeDirec)
                {
                    if (Mathf.Abs(transform.position.x) > Mathf.Abs(DownPosition))
                    {
                        transform.position = new Vector3(transform.position.x - (Speed * Time.deltaTime), transform.position.y, transform.position.z);
                        if (Mathf.Abs(transform.position.x) < Mathf.Abs(DownPosition))
                        {
                            ChangeDirec = false;

                        }
                    }

                }
            }
        }
        else
        {
            if (!ChangeDirec)
            {
                if (transform.position.z < LeftSidePosition)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + (Speed * Time.deltaTime));
                    if (transform.position.z > LeftSidePosition)
                    {
                        ChangeDirec = true;
                        //transform.position = new Vector3(transform.position.x, transform.position.y, LeftSidePosition);
                    }
                }
            }
            else if(ChangeDirec)
            {
                if (transform.position.z > RightSidePosition)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - (Speed * Time.deltaTime));
                    if (transform.position.z < RightSidePosition)
                    {
                        ChangeDirec = false;
                        //transform.position = new Vector3(transform.position.x, transform.position.y, RightSidePosition);
                    }
                }

            }
            

        }
    }


}
