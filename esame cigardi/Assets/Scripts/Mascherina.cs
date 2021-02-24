using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mascherina : MonoBehaviour
{
    public GameObject m_Passante;
    public GameObject NuvolaMascherina;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IndossaLaMascherina()
    {
        m_Passante.transform.gameObject.tag = "Passante";
        transform.gameObject.tag = "Passante";
        NuvolaMascherina.SetActive(false);
    }
}
