﻿using System;
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
                Description = "As one of Elizabeth's oldest friends, you've stopped by her house at her request. It's been several weeks since the tragic passing" +
                " of her husband. You haven't seen her since the funeral, and were quite surprised to get her letter asking you stop by. As one of her oldest friends you"+
                " are happy she finally wants to talk.",
                Accessible = true,               
                Message = "You arrive at the Killingsworth Vineyard.",
                Perception = "This is strange",
                GameItems = new ObservableCollection<GameItemQuantity>()
                {
                    new GameItemQuantity(GameItemById(2001), 1),
                    new GameItemQuantity(GameItemById(4002), 1), //killer key
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
                Name = "Hallway",
                Description = "The Hallway runs from the entrance."+
                "Down the hallway on your left is the door to the formal parlor and to the right the landing to the stairwell, leading upstairs." + "" +
                "The Hallway itself is padded with thick rugs, the walls covered in knicknacks and curios from all over the world.",
                Accessible = true,
                Message = "The floor creaks beneath your feet.",
                Perception = "You feel a foreboading.",
                Npcs = new ObservableCollection<Npc>()
                {
                    NpcById(2003)                   
                },
                GameItems = new ObservableCollection<GameItemQuantity>()
                {
                    new GameItemQuantity(GameItemById(3003), 1),
                }  
            };

            gameMap.MapLocations[0, 2] = new Location()
            {
                Id = 4,
                Name = "Formal Parlor",
                Description = "This portion of the house is quite grand. The original parlor sports wooden walls and high, valuted ceilings."+
                "The large fireplace in the corner crackles, casting shadows over the old fashioned paintings adorned the walls.",
                Accessible = false,
                RequiredKeyId = 4001,                
                Message = "The fire in the fireplace must have been started recently, as the fire burns steadily. Surely Elizabeth is somewhere in the house.",
                Perception ="",
                GameItems = new ObservableCollection<GameItemQuantity>()
                {
                    new GameItemQuantity(GameItemById(4003), 1),
                    new GameItemQuantity(GameItemById(3001), 1),
                },
                 Npcs = new ObservableCollection<Npc>()
                {
                    NpcById(2004)
                },
            };

            gameMap.MapLocations[2, 1] = new Location()
            {
                Id = 5,
                Name = "Upstairs",
                Description = "Elizabth may be upstairs in her study. She is known to get lost within books time to time." +
                "Perhaps she simply lost track of the time?" + "You decide to go check alone, heading up the sweeping staircase towards her study.",
                Accessible = true,
                Message = "",
                GameItems = new ObservableCollection<GameItemQuantity>()
                {
                    new GameItemQuantity(GameItemById(4001), 1),
                    new GameItemQuantity(GameItemById(3002), 2)

                },
                Npcs = new ObservableCollection<Npc>()
                {
                    NpcById(2005)
                }
            };

            gameMap.MapLocations[2, 3] = new Location()
            {
                Id = 6,
                Name = "Garden",
                Description = "Inspired by the Dune books, Robert built this garden for Elizabeth years ago. Her award winning orchides thrive in this room." +
                "Robert really never came here- it was always Elizabeth's sanctuary.",
                Accessible = false,
                RequiredKeyId = 4003,                
                GameItems = new ObservableCollection<GameItemQuantity>()
                {
                    new GameItemQuantity(GameItemById(2004), 1), 
                    new GameItemQuantity(GameItemById(4003), 1), 
                    new GameItemQuantity(GameItemById(2001), 1)

                },
                Npcs = new ObservableCollection<Npc>()
                {
                   NpcById(2006)
                }               
            };
            gameMap.MapLocations[1, 2] = new Location()
            {
                Id = 7,
                Name = "Hallway Middle",
                Description = "Thick rugs are still under feet in the middle of the Hallway but you can now hear the ticking of a clock. " +
                "Further inspections reveal a large grandfather clock.",
                Accessible = true,               
                Message = "",
                GameItems = new ObservableCollection<GameItemQuantity>()
                {                   
                    new GameItemQuantity(GameItemById(2001), 1)

                }
            };

            gameMap.MapLocations[1, 3] = new Location()
            {
                Id = 7,
                Name = "Back Hallway",
                Description = "The Hallway ends here, branching to the left and right. The door to the left is a closet, and the one to the right goes to the garden." + 
                "You haven't been in this part of the house with Elizabeth before...",
                Accessible = true,
                Message = "",
                Npcs = new ObservableCollection<Npc>()
                {
                    NpcById(2007)
                }               
            };


            gameMap.MapLocations[1, 4] = new Location()
            {
                Id = 8,
                Name = "Cellar Door",
                Description = "Familiar with the house, you know the cellar is located through this door." + 
                "Maybe Elizabeth went down to get a bottle of wine for her guests?",
                Accessible = true,               
                Message = "As you approach the door the man, Franklin, yells out from behind you in the hallway. \"I'm coming too\"! He does not give you the option"+
                "of declining. You shrug your shoulders in acceptance.",
                GameItems = new ObservableCollection<GameItemQuantity>()
                {                    
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
                new MundaneItem(2001, "Penny", "A shiny new penny.", "You don't know where to use this right now.","Pennies are lucky, right?", MundaneItem.UseActionType.OPENLOCATION),
                new MundaneItem(2003, "Gardening Book", "Elizabeth's Gardening Book.", "Oh, that reminds you, there is a indoor Garden in this house.","A battered tome that Elizabeth consults regularly.", MundaneItem.UseActionType.OPENLOCATION),
                new MundaneItem(2004, "Wishing Pot", "The pot breaks into pieces.","A small unique piece of pottery that usually contains a message.","Strange that this is inside the garden...", MundaneItem.UseActionType.OPENLOCATION),
                new MundaneItem(3003, "Painting","A stern looking man in old fashioned formal attire","How exactly do you think your going to use this? By becoming an art thief? And it weighs a ton, why are you carrying this!?","Your pretty sure Elizabeth bought this at an estate sale. The man frowns at you, probably because you stole it off the wall. Maybe it really is haunted...", MundaneItem.UseActionType.OPENLOCATION),
                new Key(4001, "Parlor Key", "Brassy and well worn, this is the key to the formal parlor.", "You have opened the Parlor.","This key is cold to the touch. Almost like ice...", Key.UseActionType.OPENLOCATION),
                new Key(4003, "Garden Key", "Large silver key. You haven't seen it before.", "You have opened the Garden.","This key looks like a brand new copy.", Key.UseActionType.OPENLOCATION),
                new Key(4002, "Car Key", "Your car key. Wow, how did you drop that?","You decide that this was a bad idea, and march back your car.", "Just a key.", Key.UseActionType.KILLPLAYER),
                new Key(4004, "Mystery Key", "An ornate key hanging on the knob.","What mysteries does this key hold?", "Looks like a grinning imp is carved into the key.", Key.UseActionType.PLAYERWIN)
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
                    Description = "A woman with long blonde hair and glamorous clothing.",
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
                    Name = "Man",
                    Description ="Pleasant looking man, dressed up for a formal event.",
                    Messages = new List<string>()
                    {
                       "You walk over to the man. He looks at you with interest. \"Hello, my name is Franklin! I am a friend of Elizabeths from her old hometown."
                    + "Last time we spoke, she invited me to stop by. I'm on vacation in happened to be driving through town, so I decided to stop by\"."                       
                    },
                    Perceptions = new List<string>
                    {
                        "You get the feeling that Franklin knows Elizabeth well, although you find it odd that not once in the 10 years you've know her she has mentioned him."
                        + "Maybe an old boyfriend? But why didn't he stop earlier, for Robert's funeral...?"
                    }
                },

                new NpcCharacter()
                {
                    Id = 2003,
                    Name = null,
                    Description = "Yourself",
                    Messages = new List<string>()
                    {
                        "Your voice carries down the seemingly empty hallway, garnering no response.",
                    },
                    Perceptions = new List<string>
                    {
                        "Looking closer you notice that several places on the walls are discolored. Has Elizabth been forced to sell off antiques for money?" +
                        "On painting in particular seems to leer at you. A portrait of man wearing a severely tailored suit and a top hat. You swear that the eyes glitter"+
                        " almost as if it was alive...Creeped out you move closer, slowly as to not alarm anyone. Suddenly you thrust your finger out and hit the painting in the eyeball. The -warm- squishy"+
                        " eyeball. It screams in pain, as you turn and flee the hall in terror...you should stop watching horror movies for awhile."
                    }
                },

                new NpcCharacter()
                {
                    Id= 2004,
                    Name = null,
                    Description = "Yourself",
                    Messages = new List<string>()
                    {
                        "You hum to yourself."
                    },
                    Perceptions = new List<string>
                    {
                        "While you are bored, you aren't bored enough to go poking around the room further. You decide to stick close to the fire to keep warm. After all Elizabeth"+
                        "should appear anytime...right?"
                    }
                },

                new NpcCharacter()
                {
                    Id= 2005,
                    Name = null,
                    Description = null,
                    Messages = new List<string>()
                    {
                        "Nothing creepy about being upstairs alone in the darkness...right?"
                    },
                    Perceptions = new List<string>
                    {
                        "The upstairs lights taper off as you get closer to Elizabeth's study, casting eerie shadows."
                    }
                },

                   new NpcCharacter()
                {
                    Id= 2006,
                    Name = null,
                    Description = "Yourself",
                    Messages = new List<string>()
                    {
                        "This room smells like cigarette smoke. How strange...Robert was a smoker, but he never had any interest in gardening..."
                    },
                    Perceptions = new List<string>
                    {
                        "Elizabeth is quite the accomplished gardener, raising many hothouse varieties of flowers." +
                        "The low sound of the water pump runs in this room, and you can hear water dripping. Looking around the room does not reveal Elizabeth, but"+
                        " you do find a wishing pot in the corner."
                    }
                },

                   new NpcCharacter()
                {
                    Id= 2007,
                    Name = null,
                   Description = "Yourself",
                    Messages = new List<string>()
                    {
                        "You should feel bad about skulking around Elizabeth's house, but you quickly justify it. After all, this isn't like her."
                    },
                    Perceptions = new List<string>
                    {
                        "Now that you've been in the house for awhile, something really doesn't feel right."                                            }
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