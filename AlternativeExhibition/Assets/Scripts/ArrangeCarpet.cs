using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;


// this script is responsible for adjusting the size of the carpet;
public class ArrangeCarpet : MonoBehaviour
{


    //we have to get input from the login credentials

    public InputField loginTextField;
    public InputField loginPassword;
    public Button submitButton;
	public GameObject[] UnitCarpets;

    // Start is called before the first frame update
    void Start()
    {
        // lets assume we have an array of Carpet class which alreay has data about how to scale and URL
        Carpet[] defintionOfCarpets = new Carpet[UnitCarpets.Length];

        defintionOfCarpets[0] = new Carpet("https://explorug.com/v2/Cache/9349E1D53DF5412E4A3961F68EA1313E/Designs/Nemoxas.rendered.jpg",5,4);
        defintionOfCarpets[1] = new Carpet("https://explorug.com/v2/Cache/9349E1D53DF5412E4A3961F68EA1313E/Designs/CLASSIC/Crorito.rendered.jpg",6,4.5f);
        defintionOfCarpets[2] = new Carpet("https://explorug.com/v2/Cache/9349E1D53DF5412E4A3961F68EA1313E/Designs/CLASSIC/Gurutent.rendered.jpg",5,4);
        defintionOfCarpets[3] = new Carpet("https://explorug.com/v2/Cache/9349E1D53DF5412E4A3961F68EA1313E/Designs/CLASSIC/Reptyt%20Envipa.rendered.jpg",6,4.5f);
        defintionOfCarpets[4] = new Carpet("https://explorug.com/v2/Cache/9349E1D53DF5412E4A3961F68EA1313E/Designs/ELEMENTARY/Dinopa%20Dalog.rendered.jpg",5,4);
        defintionOfCarpets[5] = new Carpet("https://explorug.com/v2/Cache/9349E1D53DF5412E4A3961F68EA1313E/Designs/ELEMENTARY/Venudrestre.rendered.jpg",6,4.5f);
       

        // the following piece of code sets the scale of the carpet according to the given data that we have of the scale.

       
       for (int i =0;i<UnitCarpets.Length;i++)
       {
            UnitCarpets[i].transform.localScale = new Vector3(defintionOfCarpets[i].getX(),1,defintionOfCarpets[i].getZ());
       }   

    StartCoroutine(GetTexture(defintionOfCarpets));
    }

    void Update()
    {
        // print(loginTextField.text);
        // print(loginPassword.text);
    }

    // Update is called once per frame
    IEnumerator GetTexture(Carpet[] arrayOfCarpets)
    
    {
        for (int i = 0;i < arrayOfCarpets.Length;i++)
        {
            UnityWebRequest UWR = UnityWebRequestTexture.GetTexture(arrayOfCarpets[i].getURL());
            
            yield return UWR.SendWebRequest();

            UnitCarpets[i].transform.GetChild(0).GetComponent<Renderer>().material.mainTexture = DownloadHandlerTexture.GetContent(UWR);
        }
    }


}
