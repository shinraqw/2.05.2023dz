using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._05._2023dz
{
    class Backpack
    {
        public string Color { get; set; }
        public string Brand { get; set; }
        public string Manufacturer { get; set; }
        public string Material { get; set; }
        public double Weight { get; set; }
        public double Volume { get; set; }
        public double VolumeLimit { get; set; }

        private List<Item> contents = new List<Item>();
        public List<Item> Contents
        {
            get { return contents; }
            set { contents = value; }
        }

        public event EventHandler<ItemEventArgs> ItemAdded;

        public void AddItem(Item item)
        {
            if (Volume + item.Volume > VolumeLimit)
            {
                throw new InvalidOperationException("The backpack cannot hold this item.");
            }

            contents.Add(item);
            Volume += item.Volume;

            ItemAdded?.Invoke(this, new ItemEventArgs(item));
        }

        public void FillBackpack(string color, string brand, string manufacturer, string material, double weight, double volumeLimit)
        {
            Color = color;
            Brand = brand;
            Manufacturer = manufacturer;
            Material = material;
            Weight = weight;
            VolumeLimit = volumeLimit;
        }

        public override string ToString()
        {
            return $"Color: {Color}\nBrand: {Brand}\nManufacturer: {Manufacturer}\nMaterial: {Material}\nWeight: {Weight}\nVolume: {Volume}\n";
        }
    }

    class ItemEventArgs : EventArgs
    {
        public Item Item { get; set; }

        public ItemEventArgs(Item item)
        {
            Item = item;
        }
    }

    class Item
    {
        public string Name { get; set; }
        public double Volume { get; set; }

        public Item(string name, double volume)
        {
            Name = name;
            Volume = volume;
        }
    }
}