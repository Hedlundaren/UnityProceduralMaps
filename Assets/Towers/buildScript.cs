using UnityEngine;
using System.Collections;

public class buildScript : MonoBehaviour {
    
    public GameObject modelHouse;
    public GameObject previewModelHouse;
    public GameObject player;
    bool buildPossible = false;
    public Material previewMat; 

    public class Building
    {
        
    }


	// Use this for initialization
	void Start () {
        previewModelHouse.SetActive(false);
        previewMat.shader = Shader.Find("Transparent/Diffuse");

    }

    // Update is called once per frame
    void Update () {

        
        
        if (previewModelHouse.active)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                previewModelHouse.transform.position = hit.point;

                Vector3 playerHouse = hit.point - player.transform.position;
                float playerHouseDistance = Mathf.Sqrt( Mathf.Pow(playerHouse.x, 2.0f) + Mathf.Pow(playerHouse.z, 2.0f) );
                if(playerHouseDistance > 3.0f)
                {
                    previewMat.SetColor("_Color", new Color(1.0f, 0.0f, 0.0f,0.5f));
                    buildPossible = false;
                }
                else if(playerHouseDistance < 1.0f)
                {

                    previewMat.SetColor("_Color", new Color(1.0f, 0.0f, 0.0f,0.5f));
                    buildPossible = true;
                }else
                {

                    previewMat.SetColor("_Color", new Color(1.0f, 1.0f, 1.0f, 0.5f));
                    buildPossible = true;
                }
            }
        }
        else
        {
            previewModelHouse.SetActive(false);
        }


        if (Input.GetMouseButtonDown(0) && buildPossible)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                Instantiate(modelHouse, hit.point, Quaternion.identity);
                previewModelHouse.SetActive(false);
                buildPossible = false;
            }

        }

        if (Input.GetMouseButtonDown(1))
        {
            previewModelHouse.SetActive(false);
            buildPossible = false;
        }
    }
}
