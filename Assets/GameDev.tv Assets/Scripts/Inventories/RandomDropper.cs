using UnityEngine;

namespace GameDevTV.Inventories
{
    public class RandomDropper : ItemDropper
    {
        [Tooltip("An array of possible drops")] [SerializeField]
        private DropLibrary dropLibrary;

        [SerializeField] private int dropperLevel = 1;

        // PUBLIC

        public void RandomDrop()
        {
            var drops = dropLibrary.GetRandomDrops(dropperLevel);
            foreach (var drop in drops)
            {
                DropItem(drop.item, drop.number);
            }
        }
    }
}