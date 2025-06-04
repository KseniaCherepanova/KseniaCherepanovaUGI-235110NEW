using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Collections;
using System.Globalization;


namespace ClassDish
{
    public enum KitchenName
    {
        Русская,
        Кавказская,
        Итальянская,
        Французская,
        Среднеазиатская,
        Восточная
    }
    public class Dish : IComparable<Dish>
    {
        public string NameOfDish { get; }
        public KitchenName Kitchen { get; set; }
        public string AboutTheDish { get; set; }

        public int Price { get; set; }
        public bool DishExistence { get; }
        public int CookingTime { get; set; }

        public Dish(string name, KitchenName kitchen, string aboutTheDish, int price, bool dishExistence, int cookingtime)
        {
            NameOfDish = name;
            Kitchen = kitchen;
            AboutTheDish = aboutTheDish;
            Price = price;
            DishExistence = dishExistence;
            CookingTime = cookingtime;
        }

        public virtual string[] GetInfo()
        {
            var info = new string[6];

            info[0] = $"Название: {NameOfDish}";
            info[1] = $"Кухня: {Kitchen}";
            info[2] = $"Описание: {AboutTheDish}";
            info[3] = $"Цена: {Price} руб.";
            info[4] = $"Наличие: {(DishExistence ? "в наличии" : "нет в наличии")}";
            info[5] = $"Время приготовления: {CookingTime} минут";

            return info;
        }

        public int CompareTo(Dish other)
        {
            if (Kitchen != other.Kitchen)
                return Kitchen.CompareTo(other.Kitchen);
            return NameOfDish.CompareTo(other.NameOfDish);
        }

        public abstract class Snack : Dish
        {
            public bool WhatKindOfSnack { get; set; }

            public Snack(string name, bool whatKindOfSnack, KitchenName kitchen, string aboutTheDish, int price, bool dishExistence, int cookingtime)
                : base(name, kitchen, aboutTheDish, price, dishExistence, cookingtime)
            {
                WhatKindOfSnack = whatKindOfSnack;
            }

            public override string[] GetInfo()
            {
                var info = new string[7];
                var dishInfo = base.GetInfo();

                info[0] = dishInfo[0];
                info[1] = $"Тип закуски: {(WhatKindOfSnack ? "горячая" : "холодная")}";
                info[2] = dishInfo[1];
                info[3] = dishInfo[2];
                info[4] = dishInfo[3];
                info[5] = dishInfo[4];
                info[6] = dishInfo[5];

                return info;
            }
        }

        public enum TypeOfBasicFood
        {
            Мясо,
            Рыба,
            Вегетарианское
        }

        public abstract class BasicFood : Dish
        {
            public TypeOfBasicFood TypeFood { get; set; }
            public string Garnish { get; set; }

            public BasicFood(string name, TypeOfBasicFood typeFood, string garnish, KitchenName kitchen, 
                string aboutTheDish, int price, bool dishExistence, int cookingtime)
                : base(name, kitchen, aboutTheDish, price, dishExistence, cookingtime)
            {
                TypeFood = typeFood;
                Garnish = garnish;
            }

            public override string[] GetInfo()
            {
                var info = new string[8];
                var dishInfo = base.GetInfo();

                info[0] = dishInfo[0];
                info[1] = $"Тип основного продукта: {TypeFood}";
                info[2] = $"Гарнир: {Garnish}";
                info[3] = dishInfo[1];
                info[4] = dishInfo[2];
                info[5] = dishInfo[3];
                info[6] = dishInfo[4];
                info[7] = dishInfo[5];

                return info;
            }

        }

        public class Menu : IEnumerable<Dish>
        {
            DateTime Date;
            List<Dish> Dishes;

            public Menu(string dateString, IEnumerable<Dish> dishes)
            {
                Date = DateTime.ParseExact(dateString, "28.05.2025", CultureInfo.InvariantCulture);
                Dishes = new List<Dish>();
                foreach (var dish in dishes)
                {
                    if (!Dishes.Contains(dish))
                    {
                        Dishes.Add(dish);
                    }
                }
            }
            public IEnumerator<Dish> GetEnumerator() => Dishes.GetEnumerator();
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}
