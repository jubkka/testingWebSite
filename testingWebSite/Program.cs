using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;

namespace testingWebSite
{
    public class Program
    {

        static void Main(string[] args)
        {
            IWebDriver driver;

            Start();

            void Start()
            {
                IWebDriver driverChrome = new ChromeDriver();
                IWebDriver driverFirefox = new FirefoxDriver();

                TimeSpan time = new TimeSpan(0, 0, 5);

                driver = driverChrome;

                driver.Navigate().GoToUrl("https://pikabu.ru/");

                Auth();

                System.Threading.Thread.Sleep(time);

                RatePost_Test();
                Search_Test();
                CreatePost_Test();
            }

            bool Auth()
            {
                var name = driver.FindElement(By.Name("username"));
                var password = driver.FindElement(By.Name("password"));

                var form = driver.FindElement(By.Id("signin-form"));

                name.SendKeys("kekbag@gmail.com");
                password.SendKeys("}9LGy:UXdT^qN99");
                form.Submit();

                try
                {
                    var test = driver.FindElement(By.ClassName("user__info-item"));
                }
                catch { return false; }
                
                return true;
            }

            void RatePost_Test() 
            {
                var button = driver.FindElement(By.ClassName("story__rating-plus"));
                button.Click();
            }

            void CreatePost_Test() 
            {
                IReadOnlyList<IWebElement> a = driver.FindElements(By.TagName("a"));

                IWebElement button;

                var pickman = driver.FindElement(By.ClassName("pikman__close"));
                pickman.Click();

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

                checkbox[3].Click();
                messageTextBox.Click();
                messageTextBox.SendKeys("asd");
                tags.SendKeys("TestPost, TestPost2, ");
                tags.SendKeys(" ");

                titleTextBox.SendKeys("asddd");

                buttonSent[1].Click();
            }

            void Search_Test()
            {
                var menuSearch = driver.FindElement(By.CssSelector(".header-right-menu__search"));
                var textBox = menuSearch.FindElement(By.Name("q"));
                var form = menuSearch.FindElement(By.TagName("form"));
                var button = menuSearch.FindElement(By.TagName("button"));

                button.Click();
                textBox.SendKeys("Животные");
                form.Submit();
            }
        }
    }
}
