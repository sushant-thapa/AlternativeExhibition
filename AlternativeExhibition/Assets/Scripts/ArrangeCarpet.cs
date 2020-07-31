using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;


// this script is responsible for adjusting the size of the carpet;
public class ArrangeCarpet : MonoBehaviour
{


    //we have to get input from the login credentials
    public LayerMask clickableLayer;
    public InputField loginTextField;
    public InputField loginPassword;
    public Button submitButton;
	public GameObject[] UnitCarpets;
    public Camera current;
    public GameObject testTempFloor;


    private bool isSubmitButtonPressed;
    private RaycastHit hit;
    private Carpet[] definitionOfCarpets;
    // Start is called before the first frame update
    void Start()
    {
    

    // We have to run a loop which assigns a unique ID in the form of a string to each carpet. We will do so by writing in the Text component of each carpet
    

        for (int i=0;i<UnitCarpets.Length;i++)
        {
            string temp = i.ToString();
            UnitCarpets[i].GetComponent<Text>().text=temp;
        }


        // lets assume we have an array of Carpet class which alom/v2reay has data about how to scale and URL
        definitionOfCarpets = new Carpet[UnitCarpets.Length];

        definitionOfCarpets[0] = new Carpet("https://explorug.com/v2/Cache/9349E1D53DF5412E4A3961F68EA1313E/Designs/Nemoxas.rendered.jpg",5,4, "https://explorug.com/v2/default.aspx?lp=ruglife.aspx&init=Nemoxas&mode=cat","0");
        definitionOfCarpets[1] = new Carpet("https://explorug.com/v2/Cache/9349E1D53DF5412E4A3961F68EA1313E/Designs/CLASSIC/Crorito.rendered.jpg",6,4.5f,"https://explorug.com/v2/default.aspx?lp=ruglife.aspx&init=CLASSIC/Crorito&mode=cat","1");
        definitionOfCarpets[2] = new Carpet("https://explorug.com/v2/Cache/9349E1D53DF5412E4A3961F68EA1313E/Designs/CLASSIC/Gurutent.rendered.jpg",5,4,"https://explorug.com/v2/default.aspx?lp=ruglife.aspx&init=CLASSIC/Gurutent&mode=cat","2");
        definitionOfCarpets[3] = new Carpet("https://explorug.com/v2/Cache/9349E1D53DF5412E4A3961F68EA1313E/Designs/CLASSIC/Reptyt%20Envipa.rendered.jpg",6,4.5f,"https://explorug.com/v2/default.aspx?lp=ruglife.aspx&init=CLASSIC/Reptyt%20Envipa&mode=cat","3");
        definitionOfCarpets[4] = new Carpet("https://explorug.com/v2/Cache/9349E1D53DF5412E4A3961F68EA1313E/Designs/ELEMENTARY/Dinopa%20Dalog.rendered.jpg",5,4,"https://explorug.com/v2/default.aspx?lp=ruglife.aspx&init=ELEMENTARY/Dinopa%20Dalog&mode=cat","4");
        definitionOfCarpets[5] = new Carpet("https://explorug.com/v2/Cache/9349E1D53DF5412E4A3961F68EA1313E/Designs/ELEMENTARY/Venudrestre.rendered.jpg",6,4.5f,"ELEMENTARY/Venudrestre","5");
        
        // the following piece of code sets the scale of the carpet according to the given data that we have of the scale.

       
        


       for (int i =0;i<UnitCarpets.Length;i++)
       {
            UnitCarpets[i].transform.localScale = new Vector3(definitionOfCarpets[i].getX(),1,definitionOfCarpets[i].getZ());
       }   

       StartCoroutine(GetTexture(definitionOfCarpets));

    }




    IEnumerator GetTexture(Carpet[] arrayOfCarpets)
    
    {
        for (int i = 0;i < arrayOfCarpets.Length;i++)
        {
            UnityWebRequest UWR = UnityWebRequestTexture.GetTexture(arrayOfCarpets[i].getURL());
            yield return UWR.SendWebRequest();
            UnitCarpets[i].transform.GetChild(0).GetComponent<Renderer>().material.mainTexture = DownloadHandlerTexture.GetContent(UWR);
        }
    }


    void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(current.ScreenPointToRay(Input.mousePosition),out hit))
        {
            if(hit.collider.tag == "carpet") // the collider detects the actualCarpet so we have to reference the InstanceID of its parent
            {

                if(Input.GetMouseButtonDown(0)){
                    
                    for (int i=0;i<UnitCarpets.Length;i++)
                    {
                        if(definitionOfCarpets[i].getRuntimeID() == hit.collider.gameObject.transform.parent.GetComponent<Text>().text)
                            Application.OpenURL(definitionOfCarpets[i].getExploURL());

                    }
                    
                }
            }
        }
    }





}
