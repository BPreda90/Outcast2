using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
using System.IO;
using System.Collections.Generic;

public class Main : MonoBehaviour
{

    private int p = 1;
    private string playerName;
    private States state;
    public int temp;
    bool CombatHasStarted = false;
    public Text text;
    public HunterParty hp;
    public JsonData jData;
    public InputField inputField;
    public Player myPlayer;
    [SerializeField]
    private Hunter myHunter;

    private enum ContractDifficulty { Easy, Medium, Hard }
    private ContractDifficulty cd;

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
        ContractPick,




    };

    // Use this for initialization
    private void Awake()
    {
        jData = FindObjectOfType<JsonData>();
    }


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

    // Related Helper Functions 

    private void CreateNewPlayer()
    {
        myPlayer = new Player("bob", 100, 0, 0);
        jData.gameData._myPlayer.Add(myPlayer);
        Debug.Log(myPlayer.Name);
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

    // Related Helper Functions: 

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
            myPlayer.Expenses -= h.MonthlyPay;
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



    void Map()

    {
        Debug.Log(state);
        text.text = "Greetings Grandmaster " + myPlayer.Name + " You are in the map screen\n" +
                    "Press T to visit the Tavern \n Press G to check out the GuildHall" +
                    "Press A to check out the Armory \n" +
                    "Press Space to create a Hunt Party\n" +
                    "Press H to trigger the hunt\n " +
                    "Press P to pick a hunter from the party pool\n" +
                    "Press 1,2,3 to generate an easy, medium or hard contract\n";
        /// The user starts the party edit function
        if (Input.GetKeyDown(KeyCode.Space)) { CreateHunterParty(); }
        else if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            cd = ContractDifficulty.Easy;
            GenerateContracts(cd);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            cd = ContractDifficulty.Medium;
            GenerateContracts(cd);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            cd = ContractDifficulty.Hard;
            GenerateContracts(cd);
        }
        else if (Input.GetKeyDown(KeyCode.H)) { TriggerHunt(); }
        else if (Input.GetKeyDown(KeyCode.Return)) { ContractPick(); }
        else if (Input.GetKeyDown(KeyCode.T)) { state = States.Tavern; }
        else if (Input.GetKeyDown(KeyCode.G)) { state = States.GuildHall; }
        else if (Input.GetKeyDown(KeyCode.A)) { state = States.Armory; }
        else if (Input.GetKeyDown(KeyCode.P)) { state = States.HunterPick; }

    }

    // Related helper functions


    /// <summary>
    /// This region contains the entire mechanic to generate contracts. It gets a monster from the predefined list according
    /// to contract difficulty, adds the monster to the contract monster list then stores the contract in the current contracts list.
    /// </summary>
    #region


    void GenerateContracts(ContractDifficulty cd)
    {
        Debug.Log("Contract generation started");
        //Generating a monster list
        List<Monster> m = new List<Monster>();
        // Populating the list with monsters according to contract difficulty
        for (int i = 0; i <= UnityEngine.Random.Range(0, 2); i++)
        {
            Debug.Log("Monster added to the list");
            m.Add(GrabMonsters(cd));
        }

        Debug.Log(m.Count.ToString() + " monsters added to the contract");
        // Generating and saving the contract to the gamedata
        Contract c = new Contract("MonsterHunt", 500, 4, m);
        jData.gameData.contracts.Add(c);
        Debug.Log("Contract" + jData.gameData.contracts[jData.gameData.contracts.Count - 1].Name + " added!");
        hp.activeContract = jData.gameData.contracts[jData.gameData.contracts.Count - 1];
    }

    /// <summary>
    /// Grabs a monster from the predefined monster list
    /// The numbers should be adjusted as soon as an actual monster list is added; Right now all monsters are placeholders
    /// </summary>
    /// <param name="cd"></param>
    /// this parameter represents the contract's difficulty and on it depends what kind of monster is retreived from the list
    /// <returns></returns>
    Monster GrabMonsters(ContractDifficulty cd)
    {
        Monster m = null;
        int x = 0;
        if (cd == ContractDifficulty.Easy)
        {
            x = UnityEngine.Random.Range(0, 3);
            switch (x)
            {

                case 0:
                    m = jData.gameData.monsters[0];
                    break;
                case 1:
                    m = jData.gameData.monsters[1];
                    break;
                case 2:
                    m = jData.gameData.monsters[4];
                    break;

            }
            return m;
        }
        else if (cd == ContractDifficulty.Medium)
        {
            x = UnityEngine.Random.Range(0, 6);
            switch (x)
            {

                case 0:
                    m = jData.gameData.monsters[3];
                    break;
                case 1:
                    m = jData.gameData.monsters[4];
                    break;
                case 2:
                    m = jData.gameData.monsters[6];
                    break;
                case 3:
                    m = jData.gameData.monsters[7];
                    break;
                case 4:
                    m = jData.gameData.monsters[9];
                    break;
                case 5:
                    m = jData.gameData.monsters[10];
                    break;

            }
            return m;
        }
        else if (cd == ContractDifficulty.Hard)
        {
            x = UnityEngine.Random.Range(0, 1);
            switch (x)
            {

                case 0:
                    m = jData.gameData.monsters[4];
                    break;
                case 1:
                    m = jData.gameData.monsters[7];
                    break;
                case 2:
                    m = jData.gameData.monsters[8];
                    break;
                case 3:
                    m = jData.gameData.monsters[10];
                    break;
                case 4:
                    m = jData.gameData.monsters[12];
                    break;
            }
            return m;
        }
        return m;
    }
    #endregion

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



    /// <summary>
    /// This is a temporary functions that allows the user to switch through available contracts to send a party to resolve
    /// This should be replaced later by a UI function that allows the user to switch through various contracts in a relevant menu
    /// </summary>
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
            hp.activeContract = jData.gameData.contracts[temp];
            Debug.Log("Currrent active contract: " + hp.activeContract.Name);
            temp = 0;
            state = States.Map;
        }
    }
    // Related helper functions:


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



    /// <summary>
    /// This is a temporary function that helps me switch through the players hunters in the game
    /// This should be replaced by a UI function that lets the user navigate through all the available hunters in various relevant menus
    /// </summary>
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
            hp.HuntParty.Add(jData.gameData.hunters[temp]);
            Debug.Log("Current added hunter is " + hp.HuntParty[hp.HuntParty.Count - 1].Name);
            temp = 0;
            jData.gameData.huntingParties.Add(hp);
            state = States.Map;
        }
    }


    void TriggerHunt()
    {
        jData.gameData.huntingParties.Add(hp);
        Debug.Log("Monster Hunt triggered");
        hp.GetPartyStats();
        Debug.Log(hp.PartyTracking);
        hp.activeContract.GetMonstersStats();
        Debug.Log(hp.activeContract.MonstersStealth);
        if (hp.PartyTracking <= (1 / 2 * hp.activeContract.MonstersStealth))
        {
            Debug.Log("Critical Fail! \n While attempting to track the monsters one of the hunters got ambushed and ravaged by the beasts");
            DismissHunter(hp.HuntParty[UnityEngine.Random.Range(0, hp.HuntParty.Count)]);
            hp.ClearPartyStats();
            hp.activeContract.ClearMonsterStats();
        }
        else if ((hp.PartyTracking >= (1 / 2 * hp.activeContract.MonstersStealth)) &&
            (hp.PartyTracking <= (hp.activeContract.MonstersStealth)))
        {
            Debug.Log("Tracking has Failed! \n The hunters were unable to track down the monsters");
            hp.ClearPartyStats();
            hp.activeContract.ClearMonsterStats();
        }
        else if ((hp.PartyTracking >= hp.activeContract.MonstersStealth) &&
            (hp.PartyTracking < hp.activeContract.MonstersStealth + (1 / 2 * hp.activeContract.MonstersStealth)))
        {
            Debug.Log("Tracking was successful, the hunters managed to track down the beasts. They will now attempt to fulfill the contract.");
            hp.ClearPartyStats();
            hp.activeContract.ClearMonsterStats();
            Combat(0);
        }
        else
        {
            Debug.Log("Critical success! A monster fell into a trap and the hunters easily took it down, the hunt should be significantyl less" +
                "dangerous now");
            int t = UnityEngine.Random.Range(0, hp.activeContract.MonstersGroup.Count);
            foreach (Hunter h in hp.HuntParty)
            {
                h.ArkaneNnowledge += hp.activeContract.MonstersGroup[t].RewardKnowledge;
            }
            hp.activeContract.MonstersGroup.Remove(hp.activeContract.MonstersGroup[t]);
            if(hp.activeContract.MonstersGroup.Count<=0)
            {
                Debug.Log("The sole monster that was in the contract got killed by the hunters' trap. The reward can be already collected"
                    + "\n Combat is skipped");
                myPlayer.Fortune = hp.activeContract.Reward;
                hp.activeContract = null;
            }
            else
            {
                Combat(0);
            }
        }
    }
    //TODO: Start writing UI functionality

    void Combat( int roundCounter)
    {
        {

            // Check that at least one combatant on both sides is alive
            int monsterCount = 0, hunterCount = 0;
            Debug.Log("Combat has been initiated");
            
            foreach (Hunter h in hp.HuntParty)
                if(h.IsAlive)
                {
                    hunterCount++;
                }
            foreach(Monster m in hp.activeContract.MonstersGroup)
                if(m.IsAlive)
                {
                    monsterCount++;
                }
            Debug.Log("Combatant count is over. We have " + hunterCount +" hunters alive. And" + monsterCount + " monsters alive.");
            if (hunterCount == 0 || monsterCount == 0)
            {
                if (hunterCount == 0)
                {
                    Debug.Log("The hunt has failed! All your hunters have been killed by the monsters.");                   
                    return;
                }
                else
                {
                    Debug.Log("The hunt has succeded! All the beasts have been vanquised and your hunters are returning " +
                        "safely to the guild.");
                    myPlayer.Fortune = hp.activeContract.Reward;
                    hp.activeContract = null;                  
                    return;
                }
            }
            else
            {
                Debug.Log("There are still hunters and monsters alive the combat continues");
                roundCounter = AddCounter(roundCounter);
                Debug.Log("Current combat round is:" + roundCounter);
            }

            /// The combat starts here
            /// I have to go through all the combatants one by one in order of reactivity and have them
            /// each take an action then mark them that they have taken an action

            // Count if there are any 
            for (int i = hp.HuntParty.Count-1; i == 0; i--)
            {
                
            }
        }
        
        // Check that there are combatants on both sides
        while(true)
        {
            //Check which party is going to react first
            if (hp.PartyReactivity >= hp.activeContract.MonsterReactivity)
            {
                int t = 0;
                foreach (Monster m in hp.activeContract.MonstersGroup)
                {
                    Debug.Log(m.Name + " was attacked by hunter " + hp.HuntParty[t].Name);
                    m.CurrentHealth -= hp.HuntParty[t].MeleeDamage;
                    t++;
                    if (m.CurrentHealth <= 0)
                    {
                        Debug.Log("Monster " + m.Name + " is dead!");
                        foreach (Hunter h in hp.HuntParty)
                        {
                            h.ArkaneNnowledge += m.RewardKnowledge;
                        }
                        hp.activeContract.MonstersGroup.Remove(m);
                    }
                }
                t = 0;
                foreach (Hunter h in hp.HuntParty)
                {
                    Debug.Log(h.Name + " was attacked by monster" + hp.activeContract.MonstersGroup[t].Name);
                    h.CurrentHealth -= hp.activeContract.MonstersGroup[t].MeleeDamage;
                    t++;
                    if (h.CurrentHealth <= 0)
                    {
                        Debug.Log("Hunter " + h.Name + " is dead!");
                        hp.HuntParty.Remove(h);
                        DismissHunter(h);
                    }
                }
            }
            if (hp.PartyReactivity < hp.activeContract.MonsterReactivity)
            {
                int t = 0;
                foreach (Hunter h in hp.HuntParty)
                {
                    Debug.Log(h.Name + " was attacked by monster" + hp.activeContract.MonstersGroup[t].Name);
                    h.CurrentHealth -= hp.activeContract.MonstersGroup[t].MeleeDamage;
                    t++;
                    if (h.CurrentHealth <= 0)
                    {
                        Debug.Log("Hunter " + h.Name + " is dead!");
                        hp.HuntParty.Remove(h);
                        DismissHunter(h);
                    }
                }
                t = 0;
                foreach (Monster m in hp.activeContract.MonstersGroup)
                {
                    Debug.Log(m.Name + " was attacked by hunter " + hp.HuntParty[t].Name);
                    m.CurrentHealth -= hp.HuntParty[t].MeleeDamage;
                    t++;
                    if (m.CurrentHealth <= 0)
                    {
                        Debug.Log("Monster " + m.Name + " is dead!");
                        foreach (Hunter h in hp.HuntParty)
                        {
                            h.ArkaneNnowledge += m.RewardKnowledge;
                        }
                        hp.activeContract.MonstersGroup.Remove(m);
                    }
                }

            }
        }
        if (hp.HuntParty.Count == 0)
        {
            Debug.Log("The party has been wiped by the monsters. Combat is over!");
            
        }
        else
        {
            Debug.Log("The monsters have been defeated and the hunters are returning to the guild!");
            myPlayer.Fortune += hp.activeContract.Reward;           
            hp.activeContract.ClearMonsterStats();
            hp.ClearPartyStats();
            hp.activeContract = null;

        }

    }

    int AddCounter(int t)
    {
        t++;
        return t;
    }

    int SubtractCounter(int t)
    {
        t--;
        return t;
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

