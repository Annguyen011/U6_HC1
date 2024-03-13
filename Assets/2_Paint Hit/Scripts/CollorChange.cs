using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollorChange : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Red"))
        {
            gameObject.GetComponent<Collider>().enabled = false;
        }
        else
        {
            GetComponent<Collider>().enabled = true;
            GameObject gameObject = Instantiate(Resources.Load("Splash1")) as GameObject;   
            gameObject.transform.parent = collision.transform;
            Destroy(gameObject, .1f);
            collision.transform.tag = "Red";
            StartCoroutine(ChangeColor(collision.gameObject));
        }
    }

    private IEnumerator ChangeColor(GameObject g)
    {
        yield return new WaitForSeconds(.1f );
        g.gameObject.GetComponent<MeshCollider>().enabled = true;
        g.gameObject.GetComponent<MeshRenderer>().material.color = BallHandler.oneColor;
        Destroy(gameObject);
    }
}
