using OpenQA.Selenium;

namespace Functions
{
    public class Program
    {
        static TimeSpan time;

        public static void Main(string[] args) { }

        public static bool Auth(IWebDriver driver)
        {
            var name = driver.FindElement(By.Name("username"));
            var password = driver.FindElement(By.Name("password"));

            var form = driver.FindElement(By.Id("signin-form"));

            name.SendKeys("kekbag@gmail.com");
            password.SendKeys("}9LGy:UXdT^qN99");
            form.Submit();

            time = new TimeSpan(0, 0, 10);

            Thread.Sleep(time);

            try { var test = driver.FindElement(By.ClassName("user__info-item")); }
            catch { return false; }

            return true;
        }

        public static bool RatePost(IWebDriver driver)
        {
            time = new TimeSpan(0, 0, 2);

            var button = driver.FindElement(By.ClassName("story__rating-plus"));

            int.TryParse(button.FindElement(By.ClassName("story__rating-count")).Text, out int res1);

            button.Click();

            Thread.Sleep(time);

            int.TryParse(button.FindElement(By.ClassName("story__rating-count")).Text, out int res2);

            Console.WriteLine(res1);
            Console.WriteLine(res2);

            if (res1 != res2) return true;
            else return false;
        }

        public static bool CreatePost(IWebDriver driver)
        {
            IReadOnlyList<IWebElement> a = driver.FindElements(By.TagName("a"));

            IWebElement button;

            time = new TimeSpan(0, 0, 3);

            foreach (IWebElement e in a)
            {
                if (e.GetAttribute("class") == "button button_success button_add button_width_100")
                {
                    button = e;
                    button.Click();
                    break;
                }
            }

            var titleTextBox = driver.FindElement(By.ClassName("pkb-rich-editor-title__content--zgdQjMAN"));
            var messageTextBox = driver.FindElement(By.ClassName("pkb-rich-editor-node-paragraph__content--kaIg2xvI"));
            var tags = driver.FindElement(By.ClassName("pkb-input-tag-input__input--v4GHM_dK"));
            var checkbox = driver.FindElements(By.ClassName("pkb-checkbox__check--kQEIYePs"));
            var buttonSent = driver.FindElements(By.ClassName("pkb-btn__text--FO_UA9yM"));

            Thread.Sleep(time);

            var buttona = driver.FindElement(By.ClassName("button_main"));

            buttona.Click();

            checkbox[3].Click();
            messageTextBox.Click();
            messageTextBox.SendKeys("asd");
            tags.SendKeys("TestPost, TestPost2, ");
            tags.SendKeys(" ");

            titleTextBox.SendKeys("asddd");

            buttonSent[1].Click();

            Thread.Sleep(time);

            try 
            {
                var test = driver.FindElement(By.ClassName("scheduled-story-alert__link"));
            }
            catch { return false; }

            return true;
        }

        public static bool Search(IWebDriver driver)
        {
            time = new TimeSpan(0, 0, 3);

            var menuSearch = driver.FindElement(By.CssSelector(".header-right-menu__search"));
            var textBox = menuSearch.FindElement(By.Name("q"));
            var form = menuSearch.FindElement(By.TagName("form"));
            var button = menuSearch.FindElement(By.TagName("button"));

            button.Click();
            textBox.SendKeys("Животные");
            form.Submit();

            uint count;

            try
            {
                Thread.Sleep(time);

                var panel = driver.FindElement(By.ClassName("stories-search__feed-panel"));
                var countText = panel.FindElement(By.TagName("span")).Text;

                Console.WriteLine(countText);

                uint.TryParse(countText.Split(" ")[0], out count);
            }
            catch { return false; }

            return true;
        }
    }
}