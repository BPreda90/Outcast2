using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
using System.IO;

public class Main : MonoBehaviour
{

    private int p = 1;
    private string playerName;
    private States state;
    public int temp;
    public Text text;
    public HunterParty hp;
    public JsonData jData;
    public InputField inputField;
    public Player myPlayer;
    [SerializeField]
    private Hunter myHunter;

    public enum States


    {
        StartState,
        GuildHall, // User's central hub, it accesses all the other rooms, and the user is able to check
        // the guild's treasury
        Tavern, // User recuits or dismisses Hunters, gets contracts
        Map, // User sends squads of Hunters to fulfil missions
        Armory, // User uses arkane points to research new technologies or techniques
        //Utilities
        HunterPick,
        ContractPick



    };



    // Helper Functions;
    // Grabs the player's name from the input field, then closes the input field.
    string AcceptStringInput()
    {
        inputField.gameObject.SetActive(true);
        string userInput = inputField.text;
        userInput = userInput.ToLower();
        text.text += userInput;
        inputField.gameObject.SetActive(false);
        return userInput;
    }
    private void CreateNewPlayer()
    {
        myPlayer = new Player("bob", 100, 0, 0);
        jData.gameData._myPlayer.Add(myPlayer);
        Debug.Log(myPlayer.Name);
    }

    public void RecruitNewHunter()
    {
        int x = UnityEngine.Random.Range(0, 3);
        switch (x)
        {
            case 0:
                {
                    Hunter h = new Hunter("bob_melee", 5, 2, 2, 1, 0, UnityEngine.Random.Range(18, 33), 10);
                    if (myPlayer.Fortune >= h.MonthlyPay)
                    {
                        Debug.Log("Melee hunter recruited");
                        jData.gameData.hunters.Add(h);
                        text.text = "New hunter added" + h.Name;
                        myPlayer.Fortune -= h.MonthlyPay;
                        myPlayer.Expenses += h.MonthlyPay;
                    }
                }
                break;
            case 1:
                {
                    Hunter h = new Hunter("tom_ranged", 2, 5, 2, 1, 0, UnityEngine.Random.Range(18, 33), 10);
                    if (myPlayer.Fortune >= h.MonthlyPay)
                    {
                        jData.gameData.hunters.Add(h);
                        text.text = "New hunter added" + h.Name;
                        myPlayer.Fortune -= h.MonthlyPay;
                        myPlayer.Expenses += h.MonthlyPay;
                        Debug.Log("Ranged hunter recruited");
                    }
                }
                break;
            case 2:
                {
                    Hunter h = new Hunter("sam_utility", 2, 2, 5, 1, 0, 24, 10);
                    if (myPlayer.Fortune >= h.MonthlyPay)
                    {
                        jData.gameData.hunters.Add(h);
                        text.text = "New hunter added" + h.Name;
                        myPlayer.Fortune -= h.MonthlyPay;
                        myPlayer.Expenses += h.MonthlyPay;
                        Debug.Log("Utility hunter recruited");
                    }
                    break;
                }
        }
    }



    public void DismissHunter(Hunter h)
    {
        if (jData.gameData.hunters.Contains(h))
        {
            myPlayer.Fortune -= h.MonthlyPay;
            jData.gameData.hunters.Remove(h);
        }
        else
        {
            Debug.LogError(h.Name + "does not exist in the hunters list. Something went wrong");
        }
    }

    public void ViewHunters()
    {
        foreach (Hunter h in jData.gameData.hunters)
        {
            text.text = " The available hunters are:\n" +
                 h.Name + " strenght: " + h.Strength.ToString() + "accuracy: " + h.Tracking.ToString() +
                 " lore: " + h.ArkaneNnowledge.ToString() + " level: " + h.Level.ToString() + " experience: " +
                 h.Experience.ToString() + " age: " + h.Age.ToString() + " sanity: " + h.Sanity.ToString() +
                 " monthly pay: " + h.MonthlyPay.ToString() + " total fortune: " + h.Fortune.ToString() +
                 "\n";
        }
    }






    // Use this for initialization
    void Start()
    {
        state = States.StartState;
        temp = 0;
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case States.StartState:
                StartState();
                break;
            case States.GuildHall:
                GuildHall();
                break;
            case States.Tavern:
                Tavern();
                break;
            case States.Map:
                Map();
                break;
            case States.HunterPick:
                HunterPick();
                break;
            case States.ContractPick:
                ContractPick();
                break;
            case States.Armory:
                Armory();
                break;
        }
    }
    /// <summary>
    /// User input function
    /// /// </summary>
    /// <param name="userInput"></param>




    // State Machine functions

    void StartState()
    {
        text.text = "Press N for a new game or L to load a previous session";

        if (Input.GetKeyDown(KeyCode.R))
        {
            jData.ReadData();
            state = States.GuildHall;
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            text.text = "Five years ago The Great War stopped abruptly\n\n" +
"We didn't knew it then, but the Old Ones had awakened, and then chaos reigned!\n" +
"At first the dead simply rose up from the mud and trenches and started fighting" +
"each other as if nothing had happened\n." +
"Then they turned on the living.\n\n" +
"Then other monstrosities showed up, animals twistend and mutated started killing folk. \n" +
"Society crumbled under the weight \n" +
"What remained retreated to... " +
"Press G to return to the Guild Hall";

            CreateNewPlayer();
            state = States.GuildHall;
        }


    }



    /// <summary>
    /// During the GuildHall state, the user should be able to:
    /// - Manage the guild's finances
    /// - Accept contracts, take loans, enact decrees
    /// - 
    /// </summary>
    void GuildHall()
    {
        Debug.Log(state);
        text.text = "Greetings Grandmaster" + myPlayer.Name + "You are in the guild hall" +
                    "Currently the guild fortune amounts to " + myPlayer.Fortune + " dublons \n" +

                    "Press T to visit the Tavern \n, M view the map - not yet implemented\n" +
                    ", S to Save the game, or A to check out the Armory - not yet implemented";
        if (Input.GetKeyDown(KeyCode.S)) { jData.SaveData(); }
        if (Input.GetKeyDown(KeyCode.T)) { state = States.Tavern; }
        if (Input.GetKeyDown(KeyCode.M)) { state = States.Map; }
        if (Input.GetKeyDown(KeyCode.A)) { state = States.Armory; }
    }
    void Tavern()
    {
        Debug.Log(state);
        text.text = "Greetings Grandmaster" + myPlayer.Name + "You are in the tavern" +
                    "The tavern is the place to recruit hunters for the guild" +

                    "Press H to recruit a new hunter\n," +
                    "Press V to view all the hunters in the guild\n" +
                    "Press M view the map - not yet implemented\n" +
                    "Press A to check out the Armory - not yet implemente\n" +
                    "Press G to return to the Guild Hall";
        if (Input.GetKeyDown(KeyCode.H)) { RecruitNewHunter(); }
        else if (Input.GetKeyDown(KeyCode.G)) { state = States.GuildHall; }
        else if (Input.GetKeyDown(KeyCode.M)) { state = States.Map; }
        else if (Input.GetKeyDown(KeyCode.A)) { state = States.Armory; }
    }

    void Map()

    {
        Debug.Log(state);
        text.text= "Greetings Grandmaster " + myPlayer.Name + " You are in the map screen\n" +
                    "Press T to visit the Tavern, or G to check out the GuildHall" +
                    " or A to check out the Armory \n" +
                    "Press Space to create a Hunt Party\n" +
                    "Press P to pick a hunter from the party pool";
        /// The user starts the party edit function
        if (Input.GetKeyDown(KeyCode.Space)) { CreateHunterParty(); }
        else if(Input.GetKeyDown(KeyCode.Return)) { ContractPick(); }
        else if (Input.GetKeyDown(KeyCode.T)) { state = States.Tavern; }
        else if (Input.GetKeyDown(KeyCode.G)) { state = States.GuildHall; }
        else if (Input.GetKeyDown(KeyCode.A)) { state = States.Armory; }
        else if (Input.GetKeyDown(KeyCode.P)) { state = States.HunterPick; }
        
    }

    void CreateHunterParty()
    {
        text.text = "Create a new party?/n" +
            "If yes press Space, else press Escape to discard";       
        {
            GameObject go = new GameObject();
            go.AddComponent<HunterParty>();
            hp = go.GetComponent<HunterParty>();

            go.name = "Hunter Party" + p.ToString();
            p++;      
        }
    }



    void Add()
    {
        Debug.Log(temp);
        temp++;
        if (temp >= jData.gameData.hunters.Count)
        { temp = jData.gameData.hunters.Count - 1; }
    }

    void Subtract()
    {
        Debug.Log(temp);
        temp--;
        if (temp <= 0)
        { temp = 0; }
    }

    void ContractPick()
    {
        Debug.Log(state);
        text.text = "Contract " + temp.ToString() + "will be assigned to hunt party" +
            "\n Press up or down to switch through the the hunters" +
            "\n Press enter to add the assign the contract to the party";
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Add();
            Debug.Log("T=" + temp.ToString());
            state = States.Map;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {            
            Subtract();
            Debug.Log("T=" + temp.ToString());
            state = States.Map;
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            hp.activeContract= jData.gameData.contracts[temp];
            Debug.Log("Currrent active contract: " + hp.activeContract.name);
            temp = 0;
            state = States.Map;            
        }
    }


    void HunterPick()
    {
        Debug.Log(state);
        text.text = "Contract " + temp.ToString() + "will be assigned to hunt party" +
            "\n Press up or down to switch through the the hunters" +
            "\n Press enter to add the assign the contract to the party";
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Add();
            Debug.Log("T=" + temp.ToString());
            state = States.Map;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Subtract();
            Debug.Log("T=" + temp.ToString());
            state = States.Map;
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            hp.activeContract = jData.gameData.contracts[temp];
            Debug.Log("Currrent active contract: " + hp.activeContract.name);
            temp = 0;
            state = States.Map;
        }
    }

    void Armory()
    {
        Debug.Log(state);
        text.text = "Greetings Grandmaster" + myPlayer.Name + "You are in the guild hall" +
                    "Currently the guild fortune amounts to " + myPlayer.Fortune + " dublons \n" +

                    "Press T to visit the Tavern \n, M view the map - not yet implemented\n" +
                    " or G to check out the GuildHall- not yet implemented";
        if (Input.GetKeyDown(KeyCode.T)) { state = States.Tavern; }
        else if (Input.GetKeyDown(KeyCode.M)) { state = States.Map; }
        else if (Input.GetKeyDown(KeyCode.G)) { state = States.GuildHall; }
    }
}

