using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhantomInkApp
{
    public class SpiritCardLibrary
    {
        private static SpiritCardLibrary instance;
        private SpiritCardLibrary() { }
        private Random rand = new Random(DateTime.Now.Millisecond);

        public static SpiritCardLibrary Instance
        {
            get
            {
                if (instance == null)
                    instance = new SpiritCardLibrary();
                return instance;
            }
        }
        public SpiritCard RandomCard { get { return library[rand.Next(library.Count)]; } }

        private List<SpiritCard> library = new List<SpiritCard>() 
        {
            new SpiritCard(new string[]
            {
                "Мрамор", "Зонтик", "Гусеница", "Чили", "Штопор", "Классная доска"
            }),
            new SpiritCard(new string[]
            {
                "Кактус", "Иглу", "Попкорн", "Пингвин", "Наушники", "Тигр"
            }),
            new SpiritCard(new string[]
            {
                "Печь", "Перо", "Метроном", "Сыр", "Палочка", "Утка"
            }),
            new SpiritCard(new string[]
            {
                "Свинья", "Подушка", "Подлодка", "Айсберг", "Небоскреб", "Шляпа"
            }),
            new SpiritCard(new string[]
            {
                "Корона", "Воздушный шар", "Изгородь", "Степлер", "Молоток", "Шлем"
            }),
            new SpiritCard(new string[]
            {
                "Монокль", "Пух Перо", "Книга", "Мелок", "Сани", "Морской конек"
            }),
            new SpiritCard(new string[]
            {
                "Гриль", "Печь", "Принтер", "Яйцо", "Поводок", "Термос"
            }),
            new SpiritCard(new string[]
            {
                "Гидрант", "Карандаш", "Сарай", "Печать", "Утконос", "Правитель"
            }),
            new SpiritCard(new string[]
            {
                "Трофей", "Пума", "Лиса", "Бумажник", "Павлин", "Рубин"
            }),
            new SpiritCard(new string[]
            {
                "Пила", "Вишня", "Живой мертвец", "Стервятник", "Нож", "Крыса"
            }),
            new SpiritCard(new string[]
            {
                "Камера", "Вилка", "Кит", "Спичка", "Часы", "Зеркало"
            }),

            new SpiritCard(new string[]
            {
                "Гамак", "Коробка", "Кекс", "Арфа", "Динозавр", "Гитара"
            }),
        };
    }
}
