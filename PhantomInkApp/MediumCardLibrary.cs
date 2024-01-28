using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhantomInkApp
{
    public class MediumCardLibrary
    {
        private static MediumCardLibrary instance;
        private MediumCardLibrary() { }
        public bool SunOrMoonCommand { get; set; }
        public void Init(int seed) // 0 - 999
        {
            randSunTeam = new Random(seed);
            randMoonTeam = new Random(seed + 1000);
            var library = new List<MediumCard>(OriginalLibrary);
            sunLibrary.Clear();
            moonLibrary.Clear();
            sunHand.Clear();
            moonHand.Clear();
            for (int i = 0; i < OriginalLibrary.Count; i++)
            {
                bool sunOrMoon = library.Count % 2 == 0;
                if (sunOrMoon)
                {
                    int nextSunElemId = randSunTeam.Next(library.Count);
                    sunLibrary.Add(library[nextSunElemId]);
                    library.RemoveAt(nextSunElemId);
                }
                else
                {
                    int nextMoonElemId = randMoonTeam.Next(library.Count);
                    moonLibrary.Add(library[nextMoonElemId]);
                    library.RemoveAt(nextMoonElemId);
                }
            }
            for (int i = 0; i < 7; i++)
            {
                sunHand.Add(GetRandomCard(true));
                moonHand.Add(GetRandomCard(false));
            }
        }
        private Random randSunTeam = null;
        private Random randMoonTeam = null;
        private List<MediumCard> sunLibrary = new List<MediumCard>();
        private List<MediumCard> moonLibrary = new List<MediumCard>();
        private List<MediumCard> sunHand = new List<MediumCard>();
        private List<MediumCard> moonHand = new List<MediumCard>();
        public List<MediumCard> SunHand { get { return sunHand; } }
        public List<MediumCard> MoonHand { get { return moonHand; } }
        public void RemoveCardFromHand(MediumCard card, bool sunOrMoon)
        {
            if (sunOrMoon)
            {
                sunHand.Remove(card);
            }
            else
            {
                moonHand.Remove(card);
            }
        }
        public void AddNewCardToHand(bool sunOrMoon)
        {
            if (sunOrMoon)
            {
                sunHand.Add(GetRandomCard(sunOrMoon));
            }
            else
            {
                moonHand.Add(GetRandomCard(sunOrMoon));
            }
        }

        public static MediumCardLibrary Instance
        {
            get
            {
                if (instance == null)
                    instance = new MediumCardLibrary();
                return instance;
            }
        }
        public MediumCard GetRandomCard(bool sunOrMoon)
        {
            if (sunOrMoon)
            {
                // ADD CHECKS HERE
                int sunCardToGet = randSunTeam.Next(sunLibrary.Count);
                var ret = sunLibrary[sunCardToGet];
                sunLibrary.RemoveAt(sunCardToGet);
                return ret;
            }
            else
            {
                // ADD CHECKS HERE
                int moonCardToGet = randMoonTeam.Next(moonLibrary.Count);
                var ret = moonLibrary[moonCardToGet];
                moonLibrary.RemoveAt(moonCardToGet);
                return ret;
            }
        }
        private List<MediumCard> OriginalLibrary
        {
            get
            {
                return
                    new List<MediumCard>()
        {
            new MediumCard("Цена", "Что стоит примерно столько же?"),
            new MediumCard("Размер", "Что примерно такого же размера?"),
            new MediumCard("Вес", "Что примерно столько же весит?"),
            new MediumCard("Опасность", "Что примерно так же опасно?"),
            new MediumCard("Животное", "Если бы это животное, то какое?"),
            new MediumCard("Инструмент", "Если бы это был музыкальный инструмент, то какой?"),
            new MediumCard("Еда", "Если бы это была еда, то какая?"),
            new MediumCard("Любимая еда", "Если бы у него была любимая еда, что бы это было?"),
            new MediumCard("Академия", "Какая научная область изучает это?"),
            new MediumCard("Историческая", "Кто из исторических личностей имел или использовал это?"),
            new MediumCard("Знаменитость", "Кто из знаменитостей имеет или использует это?"),
            new MediumCard("Характер", "Кто из вымышленных персонажей имеет или использует это?"),
            new MediumCard("Как это сделано", "Как это сделано?"),
            new MediumCard("Перевозка", "Как это перевозят?"),
            new MediumCard("Оружие", "Как использовать это в качестве оружия?"),
            new MediumCard("Концепт", "С каким абстрактным понятием это ассоциируется?"),
            new MediumCard("Несчастный случай", "К какому несчастному случаю или травме это может привести?"),
            new MediumCard("Прилагательное", "Какое прилагательное лучше всего описывает это?"),
            new MediumCard("Греческий бог", "С каким древнегреческим или римским богом это больше всего ассоциируется?"),
            new MediumCard("Категория", "К какой категории предметов это относится?"),
            new MediumCard("Цвет", "Какого это цвета?"),
            new MediumCard("Контейнер", "В каком контейнере это хранить?"),
            new MediumCard("Нужно", "Что вам нужно для того, чтобы использовать это?"),
            new MediumCard("Пахнет", "Как это пахнет?"),
            new MediumCard("Вкус", "На что это похоже на вкус?"),
            new MediumCard("Наука", "Какая область науки это изучает?"),
            new MediumCard("Жанр", "В каком жанре фильма или книиги это чаще всего встречается?"),
            new MediumCard("Использовать", "Для чего это используется?"),
            new MediumCard("Причина", "Что заставляет вас использовать это?"),
            new MediumCard("Кто это использует", "Какие люди имеют или используют это?"),
            new MediumCard("Магазин", "В каком магазине, скорее всего, найдете это?"),
            new MediumCard("Материал", "Из какого материала это сделано?"),
            new MediumCard("Прозвище", "Какое у этого прозвище?"),
            new MediumCard("Звуковой эффект", "Какие ономатопеи это издает (бум, мяу и т.д.)?"),
            new MediumCard("Часть тела", "С какой частью тела вы это используете?"),
            new MediumCard("Питание", "Что это питает?"),
            new MediumCard("Профессия", "Какая профессия работает с этим?"),
            new MediumCard("СМИ", "В какой книге, фильме или телепередаче это появляется?"),
            new MediumCard("Бренд", "Какой распространенный бренд у этого?"),
            new MediumCard("Сорт", "В какой разновидности это встречается?"),
            new MediumCard("Ложь", "Что не имеет НИКАКОГО отношения к этому (просто чтобы запутать другую команду)?"),
            new MediumCard("Внутри", "Что находится внутри этого?"),
            new MediumCard("Похожее", "Что похоже на это?"),
            new MediumCard("Сделать", "Что можно сделать с помощью этого?"),
            new MediumCard("Любимый", "Какой ваш любимый вид этого?"),
            new MediumCard("Где используется", "Где вы это используете?"),
            new MediumCard("Выбросить", "Куда это отправляется, когда умирает, ломается или становится бесполезным?"),
            new MediumCard("Дом", "Где в доме вы можете это найти?"),
            new MediumCard("Хранение", "Где это хранится?"),
            new MediumCard("Где", "Где бы вы это нашли?"),
            new MediumCard("Купить", "Где бы вы могли это купить или получить?"),
            new MediumCard("Кто производит", "Кто или что это производит?"),
            new MediumCard("Возраст", "Какой возрастной группе это нравится больше всего?"),
            new MediumCard("Драка", "Что заставляет людей ссорится из-за этого?"),
            new MediumCard("Город", "С каким городом это ассоциируется больше всего?"),
            new MediumCard("Регион", "На каком континенте или в каком регионе вы найдете больше всего этого?"),
            new MediumCard("Одежда", "Какую одежду вы носите при использовании этого предмета?"),
            new MediumCard("Сказка", "К какой сказке или детскому стишку это больше всего относится?"),
            new MediumCard("Ассоциация", "Какое первое слово, которое приходит вам в голову по этому поводу?"),
            new MediumCard("Супергерой", "С каким супергероем это больше всего ассоциируется?"),
            new MediumCard("Не нравится", "Кому это не нравится?"),
            new MediumCard("Школа", "В школе на каком предмете преподают об этом?"),
            new MediumCard("Ближайший", "Где находится ближайший?"),
            new MediumCard("Фигура", "Какую геометрическую фигуру это включает в себя?"),
            new MediumCard("Время жизни", "В какой период вашей жизни это наиболее полезно?"),
            new MediumCard("Ощущение", "Что вы чувствуете после его использования?"),
            new MediumCard("Ваше мнение", "Как вы лично относитесь к этому?"),
            new MediumCard("Подарок", "Что вы чувствуете, когда кто-то дарит это вам?"),
            new MediumCard("Влияет", "Как это влияет на окружающие предметы?"),
            new MediumCard("Долговечность", "Как долго это прослужит, если это оставить в покое?"),
            new MediumCard("Холм", "Как это отреагирует, если это столкнуть с холма?"),
            new MediumCard("Изменение", "Что это изменит?"),
            new MediumCard("Страна", "С какой страной это ассоциируется больше всего?"),
            new MediumCard("Половина", "Что вы сделаете, если у вас есть только половина этого?"),
            new MediumCard("Текстура", "Какого на ощупь, когда вы это трогаете?"),
            new MediumCard("Среда обитания", "В какой среде обитания вы могли бы это встретить?"),
            new MediumCard("Вода", "Что произойдет, если поместить это под воду?"),
            new MediumCard("Дождь", "Что произойдет с ним, если оставить это под дождем?"),
            new MediumCard("Праздник", "С каким праздником это ассоциируется больше всего?"),
            new MediumCard("Шум", "Какой шум издается при использовании этого?"),
            new MediumCard("Не из этого материала", "Из какого материала НЕ сделано это?"),
            new MediumCard("Уронил", "Какой шум это издает при падении?"),
            new MediumCard("Вечеринка", "К какой вечеринке это больше всего подошло бы?"),
            new MediumCard("Суперсила", "Какая суперсила нужна этому?"),
            new MediumCard("Время", "В какое время суток это используется?"),
            new MediumCard("Захоронить", "Что произойдет, если это закопать на год?"),
            new MediumCard("Уничтожить", "Что бы использовали, чтобы уничтожить это?"),
            new MediumCard("Игра", "В какой игре это появляется?"),
            new MediumCard("Неправильный", "Как неправильно это использовать?"),
            new MediumCard("Обратный", "Что является противоположностью этому?"),
            new MediumCard("Второй материал", "Из какого вторичного материала это сделаноО?"),
            new MediumCard("Навится", "Кому за этим столом это нравится больше всего?"),
            new MediumCard("Поднять", "Кто или что может это поднять?"),
            new MediumCard("Частота", "Как часто вы это используете?"),
            new MediumCard("Движется", "Как это перемещается?"),
            new MediumCard("Проблема", "Какую проблему это решает?"),
            new MediumCard("Держать", "Как вы держите это?"),
            new MediumCard("Церемония", "В какой церемонии это появится?"),
            new MediumCard("Ресторан", "В каком ресторане это скорее всего подадут?"),
            new MediumCard("Турист", "В каком туристическом месте, скорее всего, найдете это?"),
            new MediumCard("Съесть", "Что произойдет, если съесть это?"),
            new MediumCard("Настроение", "Какое настроение это вызывает?"),
        };
            }
        }

    }
}
