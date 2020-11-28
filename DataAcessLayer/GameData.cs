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
                Name = "Katherine",
                Age = 33,           
             
                Inventory = new ObservableCollection<GameItemQuantity>()
                {
                    new GameItemQuantity(GameItemById(1002), 1),
                    new GameItemQuantity(GameItemById(1004), 1),
                    new GameItemQuantity(GameItemById(2001), 5),
                },
                Journals = new ObservableCollection<Journal>()
                {
                      JournalById(1),                      
                }
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
        public static Journal JournalById(int id)
        {
            return Journals().FirstOrDefault(m => m.Id == id);
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
                Name = "Street View",
                Description = "You arrive at the Killingsworth Vineyard",
                Accessible = true,               
                Message = "As one of Elizabeth's oldest friends, you walk into the house without ringing the doorbell.",
                Perception = "This is strange",
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
                Description = "The house is a grand old victorian- the sweeping double staircase leading upstairs  " +
                "while rooms branch off to either sides. A large fireplace sits against the west wall, and " +
                "an overstuffed bookcase is placed on the east wall.",
                Accessible = true,
                Message = "Two strangers are within the hall with you. One is a glamorous looking woman and the other a middle aged man." +
                "Neither of them are familair to you but they seem to know each other, talking near the fireplace." +
                "When you walk into the room their conversation stops. They both watch you, waiting.",
                Npcs = new ObservableCollection<Npc>()
                {
                    NpcById(2001),
                    NpcById(2002)
                },
            };

            gameMap.MapLocations[1, 1] = new Location()
            {
                Id = 3,
                Name = "Front Hallway",
                Description = "The Hallway connected to the entrance. " +
                "To your left is the door to the parlor, to the right the vaulted entrance to the library." + "" +
                "The Hallway itself is padded with thick rugs, the walls covered in knicknacks and curios from all over the world.",
                Accessible = true,
                Message = "The floor creaks beneath your feet.",
                Perception = "You feel a foreboading."
            };

            gameMap.MapLocations[0, 2] = new Location()
            {
                Id = 4,
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
                Id = 5,
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
                Id = 6,
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
                Id = 7,
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
                new Key(4001, "Parlor Key", "Brassy and well worn, this is the key to the formal parlor.", "You have opened the Parlor.","This key is cold to the touch. Almost like ice...", Key.UseActionType.OPENLOCATION),
                new Key(4003, "Study Key", "Large silver key. You haven't seen it before.", "You have opened the Study.","This key looks brand new.", Key.UseActionType.OPENLOCATION),
                new Key(4002, "Bent Key", "This must have fallen from someones pocket...","A strange tingle passes up your arm, as your vision fades, you realize the key was poisoned...", "Seems dangerously sharp.", Key.UseActionType.KILLPLAYER),
                new Key(4004, "Stairwell Key", "Ornate key.","You open the stairwell. What mysteries will upstairs hold?", "Looks like a grinning imp is carved into the key.", Key.UseActionType.PLAYERWIN)
            };

        }

        public static List<Npc> Npcs()
        {
            return new List<Npc>()
            {
                new NpcCharacter()
                {
                    Id = 2001,
                    Name = "Woman",
                    Description = "A striking red parrot. Its cold flat eyes follow you around the room, like it is waiting for something.",
                    Messages = new List<string>()
                    {
                        "My name is Dr. Sally Forth- I am Elizabeths new neighbor- I came over to talk to Elizabeth about a party I'm hosting next week." +
                        "She flicks her long ash blonde hair away from her face before continuing. \"I simply must have some overflow parking. Her empty field would be perfect!" +
                        "After all\", she continues tactlessly, \"Now that Robert is dead she won't be needing it."                        
                    },
                    Perceptions = new List<string>()
                    {
                        "You don't get the feeling that Elizabeth knows this woman very well, she speaks of her as an acquaintance, not a close friend." +
                        "You wonder why Elizabeth agreed to see her tonight, of all times."
                    }

                },

                new NpcCharacter()
                {
                    Id = 2002,
                    Name = "Franklin",
                    Description ="Pleasant looking",
                    Messages = new List<string>()
                    {
                       "You walk over to the man. He looks at you with interest. \"Hello, my name is Franklin! I am a friend of Elizabeths from her old hometown."
                    + "Last time we spoke, she invited me to stop by. I'm on vacation in happened to be driving through town, so I decided to stop by."
                    },
                    Perceptions = new List<string>
                    {
                        "You get the feeling that Franklin knows Elizabeth well, although you find it odd that not once in the 10 years you've know her she has mentioned him."
                        + "Maybe an old boyfriend? But why wouldn't he stop for Robert's funeral...?"
                    }
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

        public static List<Journal> Journals()
        {
            return new List<Journal>()
            {
                new JournalTravel()
                {
                    Id = 1,
                    Name = "Locked Locations",
                    Description = "Figure out how to get into these locations.",
                    Status = Journal.JournalStatus.Incomplete,
                    RequiredLocations = new List<Location>()
                    {
                        LocationById(5),
                        LocationById(8)
                    },
                },

            };
        }
    }
}