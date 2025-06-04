using System.Collections;
using System.Collections.Generic;
using ClassDish;
using static ClassDish.Dish;


namespace Dishes.UnitTests
{
    [TestFixture]
    public class DishUnitTests
    {
        [Test]
        public void ConstructorTest()
        {
            var karbonara = CreateTestDish();

            Assert.That(karbonara.NameOfDish, Is.EqualTo("Карбонара"));
            Assert.That(karbonara.Kitchen, Is.EqualTo(KitchenName.Итальянская));
            Assert.That(karbonara.AboutTheDish, Is.EqualTo("паста с яичным соусом, сыром и беконом."));
            Assert.That(karbonara.Price, Is.EqualTo(40));
            Assert.That(karbonara.DishExistence, Is.EqualTo(true));
            Assert.That(karbonara.CookingTime, Is.EqualTo(20));
        }

        [Test]
        public void GetInfoTest()
        {
            var karbonara = CreateTestDish();
            var info = karbonara.GetInfo();

            Assert.That(info.Length, Is.EqualTo(6));
            Assert.That(info[0], Is.EqualTo("Название: Карбонара"));
            Assert.That(info[1], Is.EqualTo("Кухня: Итальянская"));
            Assert.That(info[2], Is.EqualTo("Описание: паста с яичным соусом, сыром и беконом."));
            Assert.That(info[3], Is.EqualTo("Цена: 40 руб."));
            Assert.That(info[4], Is.EqualTo("Наличие: в наличии"));
            Assert.That(info[5], Is.EqualTo("Время приготовления: 20 минут"));

        }

        private Dish CreateTestDish()
        {
            var DishMember = new Dish("Карбонара", KitchenName.Итальянская, "паста с яичным соусом, сыром и беконом.", 40, true, 20);
            return DishMember;
        }
    }

    [TestFixture]
    public class SnackUnitTests
    {
        public class TestSnack : Snack
        {
            public TestSnack(string name, bool whatKindOfSnack, KitchenName kitchen,
                             string aboutTheDish, int price, bool dishExistence, int cookingtime)
                : base(name, whatKindOfSnack, kitchen, aboutTheDish, price, dishExistence, cookingtime)
            {
            }
        }

        [Test]
        public void ConstructorTest_Snack()
        {
            var julienne = CreateTestSnack();
            Assert.That(julienne.WhatKindOfSnack, Is.EqualTo(true));
        }

        [Test]
        public void GetInfoTest_SnackInfo()
        {
            var julienne = CreateTestSnack();
            var lines = new[]
            {
                "Название: Грибной жюльен",
                "Тип закуски: горячая",
                "Кухня: Французская",
                "Описание: запечённые грибы с сыром",
                "Цена: 5 руб.",
                "Наличие: в наличии",
                "Время приготовления: 15 минут"
            };

            var info = julienne.GetInfo();

            Assert.That(info.Length, Is.EqualTo(7));
            for (int i = 0; i < info.Length; i++)
            {
                Assert.That(info[i], Is.EqualTo(lines[i]));
            }
        }
        private Snack CreateTestSnack()
        {
            return new TestSnack(
                name: "Грибной жюльен",
                whatKindOfSnack: true,
                kitchen: KitchenName.Французская,
                aboutTheDish: "запечённые грибы с сыром",
                price: 5,
                dishExistence: true,
                cookingtime: 15
            );
        }
    }

    [TestFixture]
    public class BasicFoodUnitTests
    {
        public class TestBasicFood : BasicFood
        {
            public TestBasicFood(string name, TypeOfBasicFood typeFood, string garnish, KitchenName kitchen, string aboutTheDish, int price, bool dishExistence, int cookingtime)
             : base(name, typeFood, garnish, kitchen, aboutTheDish, price, dishExistence, cookingtime) { }
        }

        [Test]
        public void ConstructorTest_BasicFood()
        {
            var cutletWithMashedPotatoes = CreateBasicFoodTests();
            Assert.That(cutletWithMashedPotatoes.TypeFood, Is.EqualTo(TypeOfBasicFood.Мясо));
            Assert.That(cutletWithMashedPotatoes.Garnish, Is.EqualTo("Пюре"));
        }

        [Test]
        public void GetInfoTest_BasicFoodInfo()
        {
            var cutletWithMashedPotatoes = CreateBasicFoodTests();
            var lines = new[]
            {
                "Название: Котлеты с пюре",
                "Тип основного продукта: Мясо",
                "Гарнир: Пюре",
                "Кухня: Русская",
                "Описание: это блюдо, состоящее из жареных мясных котлет и мягкого картофельного пюре",
                "Цена: 30 руб.",
                "Наличие: в наличии",
                "Время приготовления: 30 минут"
            };

            var info = cutletWithMashedPotatoes.GetInfo();

            Assert.That(info.Length, Is.EqualTo(8));
            for (int i = 0; i < info.Length; i++)
            {
                Assert.That(info[i], Is.EqualTo(lines[i]));
            }
        }

        private BasicFood CreateBasicFoodTests()
        {
            return new TestBasicFood(
                name: "Котлеты с пюре",
                typeFood: TypeOfBasicFood.Мясо,
                garnish: "Пюре",
                kitchen: KitchenName.Русская,
                aboutTheDish: "это блюдо, состоящее из жареных мясных котлет и мягкого картофельного пюре",
                price: 30,
                dishExistence: true,
                cookingtime: 30
            );
        }
    }

    [TestFixture]
    public class DishesTests
    {
        [Test]
        public void CompareToTest()
        {
            var lagman = new Dish("Лагман", KitchenName.Среднеазиатская, "лапша с мясом и овощами", 30, true, 30);
            var plov = new Dish("Плов", KitchenName.Среднеазиатская, "рис с мясом и морковью", 45, true, 20);
            var borscht = new Dish("Борщ", KitchenName.Восточная, "суп из свеклы и капусты", 60, true, 15);
            var shashlik = new Dish("Шашлык", KitchenName.Кавказская, "жареное мясо на шампуре", 40, true, 25);
            var khachapuri = new Dish("Хачапури", KitchenName.Кавказская, "сырный хлеб", 20, true, 10);

            Assert.That(lagman.CompareTo(borscht), Is.LessThan(0)); // Среднеазиатская после Восточной
            Assert.That(plov.CompareTo(shashlik), Is.GreaterThan(0)); // Среднеазиатская перед Кавказской
            Assert.That(shashlik.CompareTo(khachapuri), Is.GreaterThan(0)); // обе из Кавказской — сравнение по названию
        }
    }

    [TestFixture]
    public class MenuTests
    {
        Menu menu;
        Dish[] fewDishes;

        [SetUp]
        public void SetUp()
        {
            var lagman = new Dish("Лагман", KitchenName.Среднеазиатская, "лапша с мясом и овощами", 30, true, 30);
            var plov = new Dish("Плов", KitchenName.Среднеазиатская, "рис с мясом и морковью", 45, true, 20);
            var borscht = new Dish("Борщ", KitchenName.Восточная, "суп из свеклы и капусты", 60, true, 15);
            var shashlik = new Dish("Шашлык", KitchenName.Кавказская, "жареное мясо на шампуре", 40, true, 25);
            var khachapuri = new Dish("Хачапури", KitchenName.Кавказская, "сырный хлеб", 20, true, 10);

            fewDishes = new Dish[] { lagman, plov, borscht, shashlik, khachapuri };
            menu = new Menu("28.05.2025", fewDishes);

        }

        [Test]
        public void IEnumerableTest()
        {
            int i = 0;

            foreach (var dish1 in menu)
                Assert.That(dish1, Is.SameAs(fewDishes[i++]));
        }
    }
}




