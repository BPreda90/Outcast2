using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    GameData gameData = new GameData();
    public Player newPlayer = new Player("Bob", 100, 100, 100);
    public enum States

    {
        GuildHall, // User's central hub, it accesses all the other rooms, and the user is able to check
        // the guild's treasury
        Tavern, // User recuits or dismisses Hunters, gets contracts
        Map, // User sends squads of Hunters to fulfil missions
        Armory, // User uses arkane points to research new technologies or techniques


    };

    // Helper Functions;

    public void RecruitNewHunter()
    {
        Hunter h = new Hunter("bob", 3, 1, 1, 1, 0, 25, 7, 10, 10);
        gameData.hunters.Add(h);
        text.text += "New hunter added";
    }

    private States state;

    public Text text;
    
            
    
    // Use this for initialization
    void Start()
    {
        state = States.GuildHall;
 
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case States.GuildHall:
                GuildHall();
                break;
            case States.Tavern:
                Tavern();
                break;
            case States.Map:
                Map();
                break;
            case States.Armory:
                Armory();
                break;
        }
    }
    void GuildHall()
    {
        text.text = "Greetings Grandmaster" + newPlayer.Name + "You are in the guild hall" +
                    "Currently the guild fortune amounts to " + newPlayer.Fortune + " dublons \n" +

                    "Press T to visit the Tavern \n, M view the map - not yet implemented\n" +
                    " or A to check out the Armory - not yet implemented";
        if (Input.GetKeyDown(KeyCode.T)) { state = States.Tavern; }
        else if (Input.GetKeyDown(KeyCode.M)) { state = States.Map; }
        else if (Input.GetKeyDown(KeyCode.A)) { state = States.Armory; }
    }
    void Tavern()
    {
        text.text = "Greetings Grandmaster" + newPlayer.Name + "You are in the tavern" +
                    "The tavern is the place to recruit hunters for the guild"+

                    "Press H to recruit a new hunter\n," +
                    "Press V to view all the hunters in the guild\n" +
                    "Press M view the map - not yet implemented\n" +
                    "Press A to check out the Armory - not yet implemente\n" +
                    "Press G to return to the Guild Hall";
        if (Input.GetKeyDown(KeyCode.H)) { RecruitNewHunter(); }
        if (Input.GetKeyDown(KeyCode.G)) { state = States.GuildHall; }
        else if (Input.GetKeyDown(KeyCode.M)) { state = States.Map; }
        else if (Input.GetKeyDown(KeyCode.A)) { state = States.Armory; }
    }
    void Map()
    {
        text.text = "Greetings Grandmaster" + newPlayer.Name + "You are in the guild hall" +
                    "Currently the guild fortune amounts to " + newPlayer.Fortune + " dublons \n" +

                    "Press T to visit the Tavern \n, or G to check out the GuildHall -not yet implemented" +
                    " or A to check out the Armory - not yet implemented";
        if (Input.GetKeyDown(KeyCode.T)) { state = States.Tavern; }
        else if (Input.GetKeyDown(KeyCode.G)) { state = States.GuildHall; }
        else if (Input.GetKeyDown(KeyCode.A)) { state = States.Armory; }
    }
    void Armory()
    {
        text.text = "Greetings Grandmaster" + newPlayer.Name + "You are in the guild hall" +
                    "Currently the guild fortune amounts to " + newPlayer.Fortune + " dublons \n" +

                    "Press T to visit the Tavern \n, M view the map - not yet implemented\n" +
                    " or G to check out the GuildHall- not yet implemented";
        if (Input.GetKeyDown(KeyCode.T)) { state = States.Tavern; }
        else if (Input.GetKeyDown(KeyCode.M)) { state = States.Map; }
        else if (Input.GetKeyDown(KeyCode.G)) { state = States.GuildHall; }
    }
}
