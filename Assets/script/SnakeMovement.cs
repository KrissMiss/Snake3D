using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SnakeMovement : MonoBehaviour
{
    public List<Transform> Tails;
    [Range(0, 3)]
    public float BonesDistance;
    public GameObject BonePrefab;
    [Range(0,4)]
    public float Speed;
    private int count;
    public Text countText;
    private Transform _transform;

    private void Start()
    {
        _transform = GetComponent<Transform>();
        count = 0;
        SetCountText ();
    }

    private void Update()
    {
        MoveSnake(_transform.position + _transform.forward * Speed);

        float angle = Input.GetAxis("Horizontal");
        _transform.Rotate(0, angle, 0);


        if (transform.position.y <= 0)
        {
            SceneManager.LoadScene(2);
        }
    }        

    private void MoveSnake(Vector3 newPosition) 
    {
        float sqrDistance = BonesDistance * BonesDistance;
        Vector3 previousPosition = _transform.position;

        foreach (var bone in Tails)
        {
            if ((bone.position - previousPosition).sqrMagnitude > sqrDistance)
            {
                Vector3 temp = bone.position;
                bone.position = previousPosition;
                previousPosition = temp;
            }
            else
            {
                break;
            }
        }
        _transform.position = newPosition;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Food"))
        {
            Destroy(collision.gameObject);

            GameObject bone = Instantiate(BonePrefab);
            Tails.Add(bone.transform);
            count++;
            SetCountText();
        }
        else if (collision.gameObject.CompareTag("Camera"))
        {
            Destroy(collision.gameObject);
            SceneManager.LoadScene(2);
        }
    }


    void SetCountText ()
    {
        countText.text = "Ananas: " + count.ToString();
    }
}
