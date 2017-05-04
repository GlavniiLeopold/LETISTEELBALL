using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public Text WinText;
    public Text DieText;
    // gravity constant
    public float g = 9.8f;

    void FixedUpdate()
    {
        // normalize axis
        var gravity = new Vector3(
            Input.acceleration.x,
            Input.acceleration.z,
            Input.acceleration.y
        ) * g;

        GetComponent<Rigidbody>().AddForce(gravity, ForceMode.Acceleration);
    }
        void OnTriggerEnter(Collider other)
    {
        //Сцена один
        if (other.gameObject.tag == "PickUp")
        {
            other.gameObject.SetActive(false);
            WinText.gameObject.SetActive(true);
            SceneManager.LoadScene(2);
        }
        other.gameObject.SetActive(true);
        WinText.gameObject.SetActive(false);
        //Сцена два
        if (other.gameObject.tag == "PickUp2")
        {
            WinText.gameObject.SetActive(true);
            SceneManager.LoadScene(3);
        }
        //////////////////////
        //Сцена три
        if (other.gameObject.tag == "PickUp3")
        {
            WinText.gameObject.SetActive(true);
        }
        /////////////////////
        //Смерть
        if (other.gameObject.tag == "Enemy")
        {
            DieText.gameObject.SetActive(true);
            SceneManager.LoadScene(3);
            
        }






    }

}
