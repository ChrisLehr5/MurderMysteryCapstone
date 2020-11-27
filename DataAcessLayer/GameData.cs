using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using MurderMysteryCapstone.Models;

namespace MurderMysteryCapstone.DataAcessLayer
{
    public static class GameData
    {
        public static Player PlayerData()
        {
            return new Player()
            {
                Id = 1,
                Name = "Violet",
                //Age = 13,             
                Health = 100,
                Lives = 3,              
                Inventory = new ObservableCollection<GameItemQuantity>()
                {
                    new GameItemQuantity(GameItemById(1002), 1),
                    new GameItemQuantity(GameItemById(1004), 1),
                    new GameItemQuantity(GameItemById(2001), 5),
                },
                //Missions = new ObservableCollection<Mission>()
               // {
                //    MissionById(1),
                //    MissionById(2),
               //     MissionById(3)
               // }
            };
        }

        public static GameItem GameItemById(int id)
        {
            return StandardGameItems().FirstOrDefault(i => i.Id == id);
        }

        private static Npc NpcById(int id)
        {
            return Npcs().FirstOrDefault(i => i.Id == id);
        }

        private static Location LocationById(int id)
        {
            List<Location> locations = new List<Location>();

            foreach (Location location in GameMap().MapLocations)
            {
                if (location != null) locations.Add(location);
            }

            return locations.FirstOrDefault(i => i.Id == id);
        }
              

        public static GameMapCoordinates InitialGameMapLocation()
        {
            return new GameMapCoordinates() { Row = 0, Column = 0 };
        }

        public static Map GameMap()
        {
            int rows = 5;
            int columns = 5;

            Map gameMap = new Map(rows, columns);
            gameMap.StandardGameItems = StandardGameItems();


            gameMap.MapLocations[0, 0] = new Location()
            {
                Id = 1,
                Name = "Street",
                Description = "You exit the cab, taking a moment to stretch.  " +
               "The trip from school was long and tedious, and you are happy to finally be home.",
                Accessible = true,
                ModifiyExperiencePoints = 10,
                Message = "",
                GameItems = new ObservableCollection<GameItemQuantity>()
                {
                    new GameItemQuantity(GameItemById(2001), 1),
                    new GameItemQuantity(GameItemById(4002), 1),
                },
            };


            gameMap.MapLocations[1, 0] = new Location()
            {
                Id = 1,
                Name = "Entrance",
                Description = "The Family Manor is a stately Victorian, boasting numerous rooms and turrets.  " +
                "The wrought iron gate swings in the breeze, and the door is slightly ajar. " +
                "Home from school, you wonder where your aunt is.",
                Accessible = true,
                Message = "You expected to be greeted at the gate..." +
                " It's very unusual that nobody is in sight- leaving you the options of standing here wondering " +
                "or going inside to see what is going on... "
            };

            gameMap.MapLocations[1, 1] = new Location()
            {
                Id = 2,
                Name = "Front Hallway",
                Description = "The Hallway connected to the entrance. " +
                "To your left is the door to the parlor, to the right the vaulted entrance to the library." + "" +
                "The Hallway itself is padded with thick rugs, the walls covered in knicknacks and curios from all over the world.",
                Accessible = true,
                Message = "The floor creaks beneath your feet."
            };

            gameMap.MapLocations[0, 2] = new Location()
            {
                Id = 3,
                Name = "Parlor",
                Description = "The rarely used formal Parlor. The furniture is ornate and looks very uncomfortable." +
                "You notice that the curio cabinet against the far wall has a drawer that is slightly ajar, and there is a hand mirror sitting " +
                "on the small desk between the chairs.",
                Accessible = false,
                RequiredKeyId = 4001,
                RequiredExperiencePoints = 4000,
                Message = "The air in this room is musty, and the chairs look overstuffed and uncomfortable." +
                "You don't think your Aunt has ever used this room. She is much too informal!",
                GameItems = new ObservableCollection<GameItemQuantity>()
                {
                    new GameItemQuantity(GameItemById(2003), 1),
                    new GameItemQuantity(GameItemById(3001), 1)
                }
            };

            gameMap.MapLocations[2, 1] = new Location()
            {
                Id = 4,
                Name = "Library",
                Description = "The giant room is stuffed to the brim with books and exotic curios. Your family has always liked" +
                "to travel, and centuries of collecting has seen this wing expanded twice. There is a small glass door leading to the garden here.",
                Accessible = true,
                Message = "",
                GameItems = new ObservableCollection<GameItemQuantity>()
                {
                    new GameItemQuantity(GameItemById(4001), 1),
                    new GameItemQuantity(GameItemById(3002), 2)

                },
                Npcs = new ObservableCollection<Npc>()
                {
                    NpcById(2001)
                }
            };

            gameMap.MapLocations[3, 1] = new Location()
            {
                Id = 5,
                Name = "Garden",
                Description = "The air is cool and heavy inside the tropical garden. The outside world melts away between the thick glass walls." +
                "A large water feature dominates the center of the room, of which inside stands a statue of a woman pouring water from a pitcher." +
                "A necklace hangs around her neck, sparkling from the damp mist.",
                Accessible = false,
                RequiredMundaneItemId = 2003,
                RequiredExperiencePoints = 4000,
                GameItems = new ObservableCollection<GameItemQuantity>()
                {
                    new GameItemQuantity(GameItemById(2004), 1),
                     new GameItemQuantity(GameItemById(4003), 1),
                    new GameItemQuantity(GameItemById(2001), 1)

                },
                Npcs = new ObservableCollection<Npc>()
                 {
                   NpcById(2003)
                },
                Message = "Something about that necklace looks familiar..."
            };
            gameMap.MapLocations[1, 2] = new Location()
            {
                Id = 6,
                Name = "Hallway Middle",
                Description = "Thick rugs are still under feet in the middle of the Hallway but you can now hear the ticking of a clock. " +
                "Further inspections reveal a large grandfather clock.",
                Accessible = true,
                ModifiyExperiencePoints = 10,
                Message = "Nothing of note in this part of the passage, except a large painting of your great-grandfather.",
                GameItems = new ObservableCollection<GameItemQuantity>()
                {
                    new GameItemQuantity(GameItemById(2002), 1),
                    new GameItemQuantity(GameItemById(2001), 1)

                }
            };

            gameMap.MapLocations[1, 3] = new Location()
            {
                Id = 7,
                Name = "Back Hallway",
                Description = "The Hallway ends here, with a door to the left and right. They are both locked. ",
                Accessible = true,
                Message = "You know there is a servants entrance to the upstairs, but which way?",
                Npcs = new ObservableCollection<Npc>()
                {
                    NpcById(2002)
                },
                GameItems = new ObservableCollection<GameItemQuantity>()
                {
                    new GameItemQuantity(GameItemById(3003), 1)

                }
            };


            gameMap.MapLocations[1, 4] = new Location()
            {
                Id = 8,
                Name = "Study",
                Description = "The door to the left. Upon opening it you find a small room, someone's study area. It is cluttered.",
                Accessible = false,
                RequiredKeyId = 4003,
                RequiredExperiencePoints = 4000,
                Message = "You feel as if someone...or something is watching you.",
                GameItems = new ObservableCollection<GameItemQuantity>()
                {
                    new GameItemQuantity(GameItemById(2001), 1),
                    new GameItemQuantity(GameItemById(3002), 1),
                    new GameItemQuantity(GameItemById(4004), 1)

                },
                Npcs = new ObservableCollection<Npc>()
                {
                    NpcById(2004)
                },
            };

            return gameMap;
        }
        public static List<GameItem> StandardGameItems()
        {
            return new List<GameItem>()
            {
                new MundaneItem(2001, "Gold Coin", "24 karat gold coin", "You don't know where to use this right now.","Old. Odd that it appears so well preserved...", MundaneItem.UseActionType.OPENLOCATION),
                new MundaneItem(2004, "Emerald Necklace","Dazzling emerald necklace","Not really your style.","Strange that this is inside the garden...", MundaneItem.UseActionType.OPENLOCATION),
            };
        }

        public static List<Npc> Npcs()
        {
            return new List<Npc>()
            {
                new NpcCharacter()
                {
                    Id = 2001,
                    Name = "Parrot",                   
                    Description = "A striking red parrot. Its cold flat eyes follow you around the room, like it is waiting for something.",
                    Messages = new List<string>()
                    {
                        "Pretty Bird!",
                        "Give me the shiny!",
                        "SQUAWK"
                    },                   
                   
                },

                new NpcCharacter()
                {
                    Id = 2002,
                    Name = "Butler Smith",                  
                    Description = "You recognize the etheral form of the family butler Smith flickering in the room. A Ghost!?!",
                    Messages = new List<string>()
                    {
                        "You shouldn't be here!",
                        "I am sorry, the lady is out. May I take a message?",
                        "I feel...hungry gazing upon you..."
                    },                  
                },

                new NpcCharacter()
                {
                    Id = 2003,
                    Name = "Wailing Lady",                  
                    Description = "A woman in a tattered white dress.",
                    Messages = new List<string>()
                    {
                        "You must find my mirror!",
                        "Fool!",
                        ".............."
                    },                    
                },

                new NpcCharacter()
                {
                    Id= 2004,
                    Name ="Mouse",                   
                    Description = "A small gray mouse.",
                    Messages = new List<string>()
                    {
                        "Squeek!",
                        "Squeeeekkkkk!"
                    },                   
                }
            };

        }

      

    }
}