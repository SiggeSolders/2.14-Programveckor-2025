
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;


public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    string inventoryFile = "\\Users\\ture.johansson\\RPG cool\\Assets\\inventoryfile.txt";

    public TextMeshProUGUI healthCountText;
    public static int healthCount = 5;
    public TextMeshProUGUI manaCountText;
    public static int manaCount = 5;
    public TextMeshProUGUI manaPotionCountText;
    public static int manaPotionCount = 0;
    public TextMeshProUGUI healthPotionCountText;
    public static int healthPotionCount = 0;


    private Inventory _inventory;
    IItem healthPotion = new HealthPotion();
    IItem manaPotion = new ManaPotion();
    private void Start()
        {
        
        //CREATES INventory
        _inventory = new Inventory();

        // Create items
        
        



        // List items
        _inventory.countItems();

        
        //load items
        using (StreamReader Reader = new StreamReader(inventoryFile))
        {
            
                string line;
                while ((line = Reader.ReadLine()) != null)
                {
                    
                    if (line == "Health Potion")
                    {
                        _inventory.AddItem(healthPotion);
                    _inventory.countItems();
                }
                    if (line == "Mana Potion")
                    {
                        _inventory.AddItem(manaPotion);
                    _inventory.countItems();
                }
                }
                //print("test: " + item.Name);
            
            
            Reader.Close();
        }

    }
    private void Update()
    {
        //use items
        if (Input.GetKeyDown(KeyCode.M))
        {
            _inventory.UseItem(manaPotion);
            _inventory.countItems();

        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            _inventory.UseItem(healthPotion);
            _inventory.countItems();

        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            // List items
            _inventory.countItems();

        }

        //save button
        if (Input.GetKeyDown(KeyCode.P))
        {
            //saving items
            using (StreamWriter sw = new StreamWriter(inventoryFile))
            {
                foreach (var item in _inventory._items)
                {
                    sw.WriteLine($"{item.Name}");
                    
                }

                sw.Close();
            }
        
        }

        healthCountText.text = ("Health " + healthCount);
        manaCountText.text = ("mana " + manaCount);
        manaPotionCountText.text = ("mana potion count " + manaPotionCount );
        healthPotionCountText.text = ("health potion count " + healthPotionCount);


    }


    //the script that make it so if you touch an item you pick it up
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "manaPotion")
        {
            _inventory.AddItem(manaPotion);
            _inventory.countItems();
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "healthPotion")
        {
            _inventory.AddItem(healthPotion);
            _inventory.countItems();
            Destroy(collision.gameObject);
        }
    }

    //inentory clas
    public class Inventory
    {
        //THE list of items that basicly is the inventory
        public List<IItem> _items = new List<IItem>();

        //add item script
        public void AddItem(IItem item)
        {
            _items.Add(item);
            Debug.Log($"Added {item.Name} to the inventory.");
        }

        //remove items
        public void RemoveItem(IItem item)
        {
            if (_items.Contains(item))
            {
                _items.Remove(item);
                Debug.Log($"Removed {item.Name} from the inventory.");
            }
            else
            {
                Debug.Log($"{item.Name} is not in the inventory.");
            }
        }

        //use items
        public void UseItem(IItem item)
        {
            if (_items.Contains(item))
            {
                item.Use();
                RemoveItem(item); 
            }
            else
            {
                Debug.Log($"{item.Name} is not in the inventory.");
            }
        }

        //showes what items you got
        public void countItems()
        {
            healthPotionCount = GetTypeCountInInventoryList<HealthPotion>(_items);
            manaPotionCount = GetTypeCountInInventoryList<ManaPotion>(_items); ;
        }

        /// <summary>
        /// count itemtype
        /// </summary>
        /// <typeparam name="ItemType"></typeparam>
        /// <param name="List"></param>
        /// <returns></returns>
        int GetTypeCountInInventoryList<ItemType>(List<IItem> List)
        {
            int Count = 0;
            
            foreach (IItem Item in List)
            {
                if(Item is ItemType)
                {
                    Count++;
                }
            }

            return Count;
        }
    }



    
    //item interface
    public interface IItem
    {
        string Name { get; }
        string Description { get; }
        void Use();
    }

    //clas for healthpotions
    public class HealthPotion : IItem
    {
        //namn på item
        public string Name => "Health Potion";
        //beskrivning av item
        public string Description => "Restores 50 HP.";

        //användning av item
        public void Use()
        {

            healthCount += 5;
            // Add logic to restore health
        }
    }

    //clas for manapotions
    public class ManaPotion : IItem
    {
        //namn på item
        public string Name => "Mana Potion";

        //beskrivning av item
        public string Description => "Restores 30 Mana.";
        //användning av item
        public void Use()
        {
            manaCount += 5;
            // Add logic to restore mana
        }
    }

}
