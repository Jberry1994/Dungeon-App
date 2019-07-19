using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungeonLibrary;
using MonsterLibrary;
using WeaponLibrary;
using System.IO;

namespace DungeonApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            string docPath = "C: \\Users\\Student\\Documents\\Visual Studio 2015\\Projects\\DungeonApplicatonPersonal\\DungeonApplication\\SaveLoad.txt";
            int monstersSlain = 0;
            DateTime startTime = DateTime.Now;
            Console.WriteLine("Welcome to the dungeon!\n");
            Console.Title = "Dungeon Run!";
            bool loadGame = false;
            Player player = new Player("", 0, 0, 0, 0, null, PlayerRace.Human, null);
            Weapon spear = new Weapon("Spear", true, 10, 10, 40);
            List<Item> items = new List<Item>();
            Inventory playerInventory = new Inventory(items);
            Console.WriteLine("New or load");
            ConsoleKey loadChoice = Console.ReadKey(true).Key;
            Console.Clear();
            switch (loadChoice)
            {
                case ConsoleKey.L:
                    loadGame = true;
                    break;
                case ConsoleKey.N:
                    loadGame = false;
                    break;
                default:
                    break;
            }
            if (loadGame)
            {
                //string input = "";
                //try
                //{   // Open the text file using a stream reader.
                //    using (StreamReader sr = new StreamReader(docPath))
                //    {
                //        // Read the stream to a string, and write the string to the console.
                //        input += sr.ReadToEnd();

                //        Console.WriteLine(input);
                //    }
                //}
                //catch (IOException e)
                //{
                //    Console.WriteLine("The file could not be read:");
                //    Console.WriteLine(e.Message);
                //}
                //string[] temp = input.Split('-');
                //string name = temp[0];
                //int hitChance = int.Parse(temp[1]);
                //int block = int.Parse(temp[2]);
                //int life = int.Parse(temp[3]);
                //int maxLife = int.Parse(temp[4]);
                //monstersSlain = int.Parse(temp[5]);
                //player = new Player(name,hitChance,block,life,maxLife,spear,PlayerRace.Human,playerInventory);
                Player.LoadGame();
            }
            else
            {
                Console.Write("Enter your name: ");
                string heroName = Console.ReadLine();
                Console.Clear();
                PlayerRace playerRace = RaceSelection();



                player = new Player(heroName, 40, 10, 20, 20, spear, playerRace, playerInventory);
            }

            Console.WriteLine($"Welcome, {player.Name}. Your journey begins...");
            bool exit = false;
            do
            {
                //TODO GetRoom();
                Console.WriteLine(GetRoom());
                //TODO CreateMonster();
                Monster monster = GetMonster();
                Console.WriteLine($"In this room: {monster.Name}");
                bool reload = false;
                do
                {
                    Console.Title = $"Monsters Slain: {monstersSlain}";
                    Console.Write("\nPlease choose an action:\n" +
                        "A) Attack\n" +
                        "R) Run Away\n" +
                        "P) Use Potion\n" +
                        "S) Stats\n" +
                        "I) Inventory\n" +
                        "X) Exit\n");
                    ConsoleKey userChoice = Console.ReadKey(true).Key;
                    Console.Clear();
                    switch (userChoice)
                    {
                        case ConsoleKey.A:
                            Combat.DoBattle(player, monster);
                            if (monster.Life <= 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.WriteLine($"\nYou killed {monster.Name}!");
                                Console.ResetColor();
                                monstersSlain++;
                                player.PlayerInventory.AddItem(GetWeapon());
                                reload = true;
                            }
                            break;
                        case ConsoleKey.R:
                            Console.WriteLine($"{monster.Name} attacks you as you flee!");
                            Combat.DoAttack(monster, player);
                            reload = true;
                            break;
                        case ConsoleKey.S:
                            Console.WriteLine(player);
                            Console.WriteLine(monster);
                            break;
                        case ConsoleKey.P:
                            player.UsePotion();
                            break;
                        case ConsoleKey.I:
                            Console.WriteLine(playerInventory);
                            break;
                        case ConsoleKey.E:
                        case ConsoleKey.X:
                            Console.WriteLine("Quitting already?");
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Invalid Input. Try again!");
                            break;
                    }
                    if (player.Life <= 0)
                    {
                        DateTime endTime = DateTime.Now;
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine($"You have died after {(endTime - startTime)}");
                        Console.ResetColor();

                        exit = true;
                    }

                } while (!reload && !exit);

            } while (!exit);

            Console.WriteLine("\n\nGAME OVER");
            if (player.Life > 0)
            {
                string SaveGame = $"{player.Name}-{player.HitChance}-{player.Block}-{player.Life}-{player.Maxlife}-{monstersSlain}";
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath)))
                {
                    outputFile.WriteLine(SaveGame);
                }
            }

        } // Main()

        private static string GetRoom()
        {
            #region rooms
            string[] rooms =
                {
                "A skeleton dressed in moth-eaten garb lies before a large open chest in the rear of this chamber. The chest is empty, but you note two needles projecting from the now-open lock. Dust coats something sticky on the needles' points.",
                "A flurry of bats suddenly flaps through the doorway, their screeching barely audible as they careen past your heads. They flap past you into the rooms and halls beyond. The room from which they came seems barren at first glance.",
                "You peer into this room and spot the white orb of a skull lying on the floor. Suddenly a stone falls from the ceiling and smashes the skull to pieces. An instant later, another stone from the ceiling drops to strike the floor and shatter. You hear a low rumbling and cracking noise",
                "A strange ceiling is the focal point of the room before you. It's honeycombed with hundreds of holes about as wide as your head. They seem to penetrate the ceiling to some height beyond a couple feet, but you can't be sure from your vantage point.",
                "The burble of water reaches your ears after you open the door to this room. You see the source of the noise in the far wall: a large fountain artfully carved to look like a seashell with the figure of a seacat spewing clear water into its basin.",
                "The strong, sour-sweet scent of vinegar assaults your nose as you enter this room. Sundered casks and broken bottle glass line the walls of this room. Clearly this was someone's wine cellar for a time. The shards of glass are somewhat dusty, and the spilled wine is nothing more than a sticky residue in some places. Only one small barrel remains unbroken amid the rubbish.",
                "This narrow room at first appears to be a dead-end corridor, but then you note several metal plates on the walls set at about eye height. Looking more closely, you see that one of these plates is slid aside to reveal a peephole.",
                "You open the door and before you is a dragon's hoard of treasure. Coins cover every inch of the room, and jeweled objects of precious metal jut up from the money like glittering islands in a sea of gold.",
                "A strange ceiling is the focal point of the room before you. It's honeycombed with hundreds of holes about as wide as your head. They seem to penetrate the ceiling to some height beyond a couple feet, but you can't be sure from your vantage point.",
                "A rusted portcullis stands just beyond the door. Looking into the room, you see three other exits, similarly blocked by portcullises. Four skeletons dressed in aged clothing and rusting armor lie on the floor in the room against the walls. They seem in poses of repose rather than violence.",
                "Dozens of dead, winged beings lie scattered about the floor, each about the size of a cat. Their broken bodies are batlike and buglike at the same time. Each had two sets of bat wings, a long nose like a mosquito, and six legs, but many were split in half or had limbs or wings lopped off. Their forms are little more than dried husks now, and there's no sign of what killed them.",
                "You open the door to reveal a 10-foot-by-10-foot room with a floor studded with spikes. The bones of some creature lie among the spikes and some insects scuttle away from the desiccated remains. No other doors are in the room, and it appears the door you opened was created to blend in with the walls. Additionally, you see no ceiling. You must be at the bottom of a very deep spiked pit.",
                "There's a hiss as you open this door, and you smell a sour odor, like something rotten or fermented. Inside you see a small room lined with dusty shelves, crates, and barrels. It looks like someone once used this place as a larder, but it has been a long time since anyone came to retrieve food from it.",
                "A pit yawns open before you just on the other side of the door's threshold. The entire floor of the room has fallen into a second room beneath it. Across the way you can spy a door in the wall now 15 feet off the rubble-strewn floor, and near the center of the room stands a thick column of mortared stone that appears to hold the spiral staircase that leads down to what was the lower level.",
                "This room smells strange, no doubt due to the weird sheets of black slime that drip from cracks in the ceiling and spread across the floor. The slime seeps from the shattered stone of the ceiling at a snails crawl, forming a mess of dangling walls of gook. As you watch, a bit of the stuff separates from a sheet and drops to the ground with a wet plop.",
                "A glow escapes this room through its open doorways. The masonry between every stone emanates an unnatural orange radiance. Glancing quickly about the room, you note that each stone bears the carving of someone's name. ",
                "A large forge squats against the far wall of this room, and coals glow dimly inside. Before the forge stands a wide block of iron with a heavy-looking hammer lying atop it, no doubt for use in pounding out shapes in hot metal. Other forge tools hang in racks nearby, and a barrel of water and bellows rest on the floor nearby.",
                "You open the door and a gout of flame rushes at your face. A wave of heat strikes you at the same time and light fills the hall. The room beyond the door is ablaze! An inferno engulfs the place, clinging to bare rock and burning without fuel.",
                "You peer through the open doorway into a broad, pillared hall. The columns of stone are carved as tree trunks and seem placed at random like trees in a forest. Stone root systems crawl out into the floor and marble branches expand across the ceiling. You even note a few carvings of small birds and squirrels. Beautiful as they are, the sculpting doesn't appear elven, and it's nothing dwarves would carve.",
                "This hall stinks with the wet, pungent scent of mildew. Black mold grows in tangled veins across the walls and parts of the floor. Despite the smell, it looks like it might be safe to travel through. A path of stone clean of mold wends its way through the hallway.",
                "You open the door and a gout of flame rushes at your face. A wave of heat strikes you at the same time and light fills the hall. The room beyond the door is ablaze! An inferno engulfs the place, clinging to bare rock and burning without fuel.",
                "Looking into this room, you note four pits in the floor. A wide square is nearest you, a triangular pit beyond it, and a little farther than both lie two circular pits. The room is rectangular nearest you but it widens into a larger rounded chamber starting just beyond the rectangular pit. You note that many flagstones, ceiling tiles, and wall blocks are carved with a skull emblem of some kind, whose dark openings emulate the layout of the pits. You've opened a door in the chin and are looking up at the face.",
                "You pull open the door and hear the scrape of its opening echo throughout what must be a massive room. Peering inside, you see a vast cavern. Stalactites drip down from the ceiling in sharp points while flowstone makes strange shapes on the floor.",
                "This small room is lined with benchlike seats on all the walls. The seats all have holes in their top, like a privy. Facing stones on the front of the benches prevent you from seeing how deep the holes go. It looks like a communal bathroom. ",
                "A furious rumble resounds in the area as stones come clattering through the doorway, along with a thick cloud of rock dust. The room beyond is filled with rubble.",
                "You push open the stone door to this room and note that the only other exit is a door made of wood. It and the table shoved against it are warped and swollen. Indeed, the table only barely deserves that description. Its surface is rippled into waves and one leg doesn't even touch the floor. The door shows signs of someone trying to chop through from the other side, but it looks like they gave up.",
                "A stone throne stands on a foot-high circular dais in the center of this cold chamber. The throne and dais bear the simple adornments of patterns of crossed lines -- a pattern also employed around each door to the room.",
                "Burning torches in iron sconces line the walls of this room, lighting it brilliantly. At the room's center lies a squat stone altar, its top covered in recently spilled blood. A channel in the altar funnels the blood down its side to the floor where it fills grooves in the floor that trace some kind of pattern or symbol around the altar. Unfortunately, you can't tell what it is from your vantage point.",
                "This tiny room holds a curious array of machinery. Winches and levers project from every wall, and chains with handles dangle from the ceiling. On a nearby wall, you note a pictogram of what looks like a scythe on a chain. ",
                "A liquid-filled pit extends to every wall of this chamber. The liquid lies about 10 feet below your feet and is so murky that you can't see its bottom. The room smells sour. A rope bridge extends from your door to the room's other exit."
            };
            #endregion
            return rooms[new Random().Next(rooms.Length)];
        } // GetRoom()

        private static Monster GetMonster()
        {
            Rat ratSwarm = new Rat("Rat Swarm", 25, 10, 10, 10, 1, 3, "It's  a swarm of rats!", false);
            Rat sirRat = new Rat("Sir Rattington the clean", 50, 15, 20, 20, 2, 5, "A rat with a top hat? And what's that smell?", true);
            Spider spider = new Spider("Giant Wolf Spider", 35, 35, 15, 15, 2, 4, "Smaller than a normal giant spider.", false);
            Spider webSpider = new Spider("Giant Spider", 45, 30, 15, 15, 3, 4, "Watch out for it's webs!", true);
            Wolf wolf = new Wolf("Lone Wolf", 50, 40, 20, 20, 3, 5, "Just a lone wolf, how strong can it be?", false);
            Wolf wolfPack = new Wolf("Pack of Wolves", 55, 45, 30, 30, 4, 6, "The more the merrier!", true);

            List<Monster> monsters = new List<Monster>() {
                ratSwarm, ratSwarm, ratSwarm, ratSwarm, ratSwarm, ratSwarm,
                sirRat,
                spider, spider, spider, spider, spider, spider,
                webSpider,
                wolf, wolf, wolf, wolf, wolf, wolf,
                wolfPack };

            return monsters[new Random().Next(monsters.Count)];
        }

        private static Weapon GetWeapon()
        {
            Weapon weakSpear = new Spear("Old Spear", 5, 1, 4);
            Weapon rustyDagger = new Dagger("Rusty Dagger", 5, 1, 3, false);
            Weapon PoisonedDagger = new Dagger("Poisoned Dagger", 5, 1, 4, true, 1);
            List<Weapon> weapons = new List<Weapon>()
            {
                weakSpear,
                rustyDagger,
                PoisonedDagger
            };
            return weapons[new Random().Next(weapons.Count)];
        }

        private static PlayerRace RaceSelection()
        {
            bool validRace = false;
            PlayerRace playerRace = PlayerRace.Human;
            while (!validRace)
            {
                int userChoice = 0;
                Console.WriteLine("Choose a race by selecting a number: ");
                foreach (PlayerRace race in Enum.GetValues(typeof(PlayerRace)))
                {
                    Console.WriteLine(userChoice + " - " + race);
                    userChoice++;
                }
                userChoice = int.Parse(Console.ReadLine());
                if (userChoice <= 9 && userChoice >= 0)
                {
                    playerRace = (PlayerRace)userChoice;
                    validRace = true;
                }
            }
            Console.Clear();
            return playerRace;
        }


    } // class
} // namespace
