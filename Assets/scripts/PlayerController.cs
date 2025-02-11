using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
  public float movespeed;
  public float cameraSpeed;
  public float gravity;
  public float gravityLimit;
  public float gravityMultiplier;
  public float jumpForce;
  Vector2 inputs;

  public CharacterController controller;
public GameObject cam;
public GameObject PlayerHead;

public string spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Roatation();
        jump();
    }

    void Movement()
    {
        inputs = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Vector3 movement = new Vector3 (inputs.x, gravity, inputs.y);
        movement = Quaternion.Euler(0, cam.transform.eulerAngles.y, 0) * movement;
        controller.Move(movement * movespeed * Time.deltaTime);
    }
    void Roatation()
    {
        PlayerHead.transform.rotation = Quaternion.Slerp(PlayerHead.transform.rotation, cam.transform.rotation, cameraSpeed * Time.deltaTime);
    }
    void jump()
    {
        if (gravity < gravityLimit)
        {
            gravity = gravityLimit;
        }
        else
        {
            gravity -= Time.deltaTime * gravityMultiplier;
        }

       
        if(controller.isGrounded && Input.GetButtonDown("Jump"))
        {
            gravity = Mathf.Sqrt(jumpForce);
        }
    }
    public IEnumerator ResetPos()
    {
        controller.enabled = false;
        transform.position = GameObject.Find(spawnPoint).transform.position;
        yield return new WaitForSeconds(1f);
        controller.enabled = true;
    }
     public IEnumerator LoadNewScene(string levelName)
    {
        controller.enabled = false;
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(levelName);
    }

}
