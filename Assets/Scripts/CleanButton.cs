using UnityEngine;

public class CleanButton : MonoBehaviour
{
    public Dignity dignityref;
    private void Start()
    {
        dignityref = GameObject.FindObjectOfType<Dignity>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Backspace))
        {
            OnCleanButtonPressed();
        }
    }
    public void OnCleanButtonPressed()
    {
        for(int i =0; i< dignityref.allCommands.Count; i++)
        {
            if(dignityref.allCommands[i].spawned == true)
            {
                if(dignityref.allCommands[i].myObject !=null)
                {
                    Destroy(dignityref.allCommands[i].myObject);
                    dignityref.allCommands[i].spawned = false;
                }
            }
        }
       

    }


}

