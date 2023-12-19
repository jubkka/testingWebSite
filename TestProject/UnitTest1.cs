namespace TestProject
{
    public class Tests
    {
        TimeSpan time;
        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            IWebDriver driverChrome = new ChromeDriver();
            IWebDriver driverFirefox = new FirefoxDriver();

            driverFirefox.Manage().Window.Maximize();

            time = new TimeSpan(0, 0, 5);

            driver = driverFirefox;

            driver.Navigate().GoToUrl("https://pikabu.ru/");
        }

        [Ignore("skip")]
        public void Auth_Test()
        {
            Assert.That(Program.Auth(driver), Is.EqualTo(true));

            Thread.Sleep(time);
        }

        [Test]
        public void RatePost_Test()
        {
            Program.Auth(driver);

            Assert.That(Program.RatePost(driver), Is.EqualTo(true));
        }

        [Ignore("skip")]
        public void CreatePost_Test()
        {
            Program.Auth(driver);

            Assert.That(Program.CreatePost(driver), Is.EqualTo(true));
        }

        [Ignore("skip")]
        public void Search_Test()
        {
            Assert.That(Program.Search(driver), Is.EqualTo(true));
        }
    }
}