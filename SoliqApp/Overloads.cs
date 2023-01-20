using System;
using Cookie = OpenQA.Selenium.Cookie;
using System.Net;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.Extensions;
namespace SoliqApp
{
    public class Overloads : General
    {

        protected void TestExpectedActual(By expected, string actual)
        {
            Assert.AreEqual(driver.FindElement(expected).Text, actual);
        }

        protected void TestExpectedActual(By expected, int index, string actual)
        {
            Assert.AreEqual(driver.FindElements(expected)[index].Text, actual);
        }

        protected void TestExpectedActualNonDigit(By expected, string actual)
        {

            Assert.AreEqual(NonDigitAndSimbols(driver.FindElement(expected).Text), actual);
        }

        protected void TestExpectedActualNonDigit(By expected, string actual, int index)
        {
            Assert.AreEqual(NonDigitAndSimbols(driver.FindElements(expected)[index].Text), actual);
        }

        public void TestExpectedActualOnlyDigit(By expected, string actual, int index)
        {
            Assert.AreEqual(OnlyDigit(driver.FindElements(expected)[index].Text), actual);
        }

        protected void TestExpectedActualOnlyDigit(By expected, string actual)
        {
            Assert.AreEqual(OnlyDigit(driver.FindElement(expected).Text), actual);
        }

        protected void TestExpectedActual(By expected, string actual, int index)
        {
            Assert.AreEqual(driver.FindElements(expected)[index].Text, actual);
        }

        protected void Click(By element, int index)
        {
            driver.FindElements(element)[index].Click();
            Thread.Sleep(300);
        }

        protected void Click(By element, string type, string name)
        {
            driver.FindElement(element).FindElement(By.XPath($"//{type}[text()='{name}']"));
        }

        protected void
            Click(By element) //перегрузка метода "Клик" - просто введите Click(элемент, который нужно кликнуть)
        {
            var clickedElement = driver.FindElement(element);
            clickedElement.Click();

        }

        protected void
            SendKeys(By element, string text) //перегрузка "SendKeys" - введите SendKeys(элемент поля ввода,текст)
        {
            Scroll(element);
            var sendingElement = driver.FindElement(element);
            sendingElement.SendKeys(text);
            Thread.Sleep(200);
        }

        protected void SendKeys(IWebElement row, string text)
        {
            row.SendKeys(text);
        }

        protected void
            SendKeys(By element, float text) //перегрузка "SendKeys" - введите SendKeys(элемент поля ввода,текст)
        {
            var sendingElement = driver.FindElement(element);
            sendingElement.SendKeys(text.ToString().Replace(',', '.'));

        }

        protected void
            SendKeys(By element, int text) //перегрузка "SendKeys" - введите SendKeys(элемент поля ввода,текст)
        {
            Scroll(element);
            var sendingElement = driver.FindElement(element);
            sendingElement.SendKeys(text.ToString());

        }

        protected void
            SendKeys(By element, int index,
                string text) //перегрузка "SendKeys" - введите SendKeys(элемент поля ввода,текст)
        {
            var sendingElement = driver.FindElements(element)[index];
            sendingElement.SendKeys(text);

        }

        protected void Clear(By element) //перегрузка "SendKeys" - введите SendKeys(элемент поля ввода,текст)
        {
            var sendingElement = driver.FindElement(element);
            sendingElement.Clear();
        }

        protected void Clear(IWebElement row, By element)
        {
            row.FindElement(element).Clear();
        }

        protected void Clear(By element, int index) //перегрузка "SendKeys" - введите SendKeys(элемент поля ввода,текст)
        {
            var sendingElement = driver.FindElements(element)[index];
            sendingElement.Clear();

        }


        protected void Screenshot(string name) //перегрузка метода. Просто введи Screenshot("имя_скриншота")
        {
            string _name = new StackTrace(1).GetFrame(0).GetMethod().Name;
            Screenshot s1 = ((ITakesScreenshot)driver).GetScreenshot();
            Directory.CreateDirectory($"C:/Users/ipopov/RiderProjects/TestsPaymart/TestsPaymart/File/{this}/{_name}");
            s1.SaveAsFile($"C:/Users/ipopov/RiderProjects/TestsPaymart/TestsPaymart/File/{this}/{_name}/{name}.jpg");
        }

        protected string OnlyDigit(string text) //метод, возвращающий строку цифр
        {
            string word = "";
            for (int i = 0; i < text.Length; i++)
            {
                if (Char.IsDigit(text[i]))
                {
                    word += text[i];
                }
            }

            return word;
        }

        private string NonDigitAndSimbols(string text) //метод, возвращающий строку без символовов и цифр
        {
            string word = "";
            for (int i = 0; i < text.Length; i++)
            {
                if (Char.IsLetter(text[i]) || text[i] == ' ')
                {
                    word += text[i];
                }
            }

            return word;
        }


        protected void
            DownloadFileToUrl(
                string file) //метод сохраняет файл,добавляя имени # в начало имени. Параметры - "имя_файла.расширение"
        {
            string name = new StackTrace(1).GetFrame(0).GetMethod().Name;
            WebClient wc = new WebClient();
            try
            {
                Directory.CreateDirectory(
                    $"C:/Users/ipopov/RiderProjects/TestsPaymart/TestsPaymart/File/{this}/{name}");
            }
            catch (DirectoryNotFoundException)
            {
            }

            wc.DownloadFile(driver.Url,
                $"C:/Users/ipopov/RiderProjects/TestsPaymart/TestsPaymart/File/{this}/{name}/" + file);
        }


        public void Unhide(IWebDriver driver, IWebElement element) //делаем элемент видимым
        {
            String script = "arguments[0].style.opacity=1;"
                            + "arguments[0].style['transform']='translate(0px, 0px) scale(1)';"
                            + "arguments[0].style['MozTransform']='translate(0px, 0px) scale(1)';"
                            + "arguments[0].style['WebkitTransform']='translate(0px, 0px) scale(1)';"
                            + "arguments[0].style['msTransform']='translate(0px, 0px) scale(1)';"
                            + "arguments[0].style['OTransform']='translate(0px, 0px) scale(1)';"
                            + "return true;";
            driver.ExecuteJavaScript(script, element);
        }

        public void AttachFile(IWebDriver driver, By locator, String file) //добавляем файл
        {
            IWebElement input = driver.FindElement(locator);
            Unhide(driver, input);
            input.SendKeys(file);
        }

        public void AttachFile(By locator, String file) //добавляем файл
        {
            IWebElement input = driver.FindElement(locator);
            input.SendKeys(file);
        }

        public void RightClick(By element)
        {
            Actions action = new Actions(driver);
            IWebElement elemen = driver.FindElement(element);
            action.ContextClick(elemen).Perform();
        }

        public void RightClick(IWebElement element)
        {
            Actions action = new Actions(driver);
            action.ContextClick(element).Perform();
        }
        //Методы авторизации




        public void AuthBuyer(string token, string status)
        {
            Delete();
            driver.Manage().Cookies.AddCookie(new Cookie("token", token));
            driver.Manage().Cookies.AddCookie(new Cookie("status", status));
            driver.Navigate().GoToUrl("https://sasha-front.paymart.uz/ru/profile/"); //вводим адрес сайта
        }
        //



        public void Select(By select, int index, int element)
        {
            SelectElement list = new SelectElement(driver.FindElements(select)[index]);
            list.SelectByIndex(element);
        }

        public void Select(By select, int index, string text)
        {
            SelectElement list = new SelectElement(driver.FindElements(select)[index]);
            list.SelectByText(text);
        }

        public void ActionClick(By element)
        {
            Actions action = new Actions(driver);
            action.Click(driver.FindElement(element)).Perform();
        }

        public void ActionClick(By element, string type, string name)
        {
            Thread.Sleep(200);
            Actions action = new Actions(driver);
            action.Click(driver.FindElement(element).FindElement(By.XPath($"//{type}[text()='{name}']"))).Perform();
        }

        public void ActionClick(By list, int index)
        {
            Thread.Sleep(200);
            Actions action = new Actions(driver);
            action.Click(driver.FindElements(list)[index]).Perform();
        }

        public void ActionClickLastElement(By list) //жмем на последний появившийся li списка ul
        {
            Thread.Sleep(200);
            Actions action = new Actions(driver);
            action.Click(driver.FindElements(list)[driver.FindElements(list).Count - 1]).Perform();
        }

        public void ActionClick(By list, string name, int index) //кликаем на элементу списка по индексу.
        {
            Thread.Sleep(200);
            Actions action = new Actions(driver);
            action.Click(driver.FindElement(list).FindElements(By.XPath($"//span[text()='{name}']"))[index]).Perform();
        }

        public void
            ActionClickLastElement(By list,
                string name) //кликаем на последний появившийся элемент li списка ul по имени. "Защита от клонов"
        {
            Actions action = new Actions(driver);
            action.Click(
                driver.FindElement(list).FindElements(By.XPath($"//span[text()='{name}']"))[
                    driver.FindElements(By.XPath($"//span[text()='{name}']")).Count - 1]).Perform();
        }

        public void ActionClick(By list, int index, string name)
        {
            Actions action = new Actions(driver);
            action.Click(driver.FindElements(list)[index].FindElement(By.XPath("[text()='" + name + "']"))).Perform();
        }

        public void Scroll(int width, int height)
        {
            driver.ExecuteJavaScript($"window.scrollTo({width},{height})");
        }

        public void
            Select(By list, int indexList, By element, int indexElement) //Заполняем модифицированный список Ul/li
        {
            ActionClick(list, indexList); //Жмем кнопку, если она единственная, то индекс заполняем 0
            Thread.Sleep(200);
            ActionClick(element, indexElement); //element - искомый элемент в листе, indexElement - его индекс
            Thread.Sleep(500);
        }

        public void
            Select(By list, int indexList, By element, string name, int tab) //Заполняем модифицированный список Ul/li
        {
            ActionClick(list, indexList); //Жмем кнопку, если она единственная, то индекс заполняем 0
            Thread.Sleep(200);
            ActionClick(element, name, tab); //element - искомый элемент в листе, indexElement - его индекс
            Thread.Sleep(500);
        }

        public void Select(By list, By element, string name) //Заполняем модифицированный список Ul/li
        {
            ActionClickLastElement(list); //Жмем кнопку, если она единственная, то индекс заполняем 0
            Thread.Sleep(500);
            ActionClickLastElement(element, name); //element - искомый элемент в листе, indexElement - его индекс
            Thread.Sleep(500);
        }

        public void Scroll(By element)
        {
            Actions action = new Actions(driver);
            action.MoveToElement(driver.FindElement(element)).Build().Perform();
            Scroll(0, 300);
        }

        public void Scroll(By element, int index)
        {
            Actions action = new Actions(driver);
            action.MoveToElement(driver.FindElements(element)[index]).Build().Perform();
            Scroll(0, 300);
        }

        public HttpClient httpClient = new HttpClient();

        public string Post()
        {
            var content = new StringContent("phone:998991234567,contract_id:14", Encoding.UTF8, "application/json");
            var result = httpClient.PostAsync("https://sasha.paymart.uz/api/v3/buyers/send-code-sms", content).Result;
            return result.ToString();
        }

        public By SelectForString(string row, int indexRow, string element)
        {
            var el = By.XPath($"{row}[{indexRow+1}]{element}");
            return el;
        }
        public void Select(By list, By element, int arrayCount, params string[] names)
        {

            for (int i = 0; i < arrayCount; i++)
            {
                ActionClickLastElement(list); //Жмем кнопку, если она единственная, то индекс заполняем 0
                Thread.Sleep(500);
                ActionClickLastElement(element,
                    names[i]); //element - искомый элемент в листе, indexElement - его индекс
                Thread.Sleep(500);
            }
        }

        public void Delete() //Очищает все файлы, связанные с тестом, перед его запуском.
        {
            string name = new StackTrace(2).GetFrame(0).GetMethod().Name;
            try
            {
                Directory.Delete($"C:/Users/ipopov/RiderProjects/TestsPaymart/TestsPaymart/File/{this}/{name}", true);
            }
            catch (DirectoryNotFoundException)
            {
            }
        }

        public IWebElement ByInRow(By row, int rowIndex, By element, int index)
        {

            IWebElement by = driver.FindElements(row)[rowIndex].FindElements(element)[index];
            return by;
        }

    }
}