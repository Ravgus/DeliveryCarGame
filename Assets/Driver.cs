using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] public float steerSpeed = 200.0f;
    [SerializeField] public float moveSpeed = 10.0f;
    [SerializeField] public float slowMoveSpeed = 5.0f;
    [SerializeField] public float boostMoveSpeed = 20.0f;

    // Start is called before the first frame update
    void Start()
    {
        transform.SetPositionAndRotation(new Vector3(), new Quaternion());
    }

    // Update is called once per frame
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        this.moveSpeed = this.slowMoveSpeed;

        Debug.Log("Slow!");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Boost") {
            this.moveSpeed = this.boostMoveSpeed;

            Debug.Log("Boost!");
        }
    }
}
