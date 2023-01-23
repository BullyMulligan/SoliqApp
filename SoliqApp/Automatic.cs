
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using NUnit.Framework;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Interactions;
using Cookie = OpenQA.Selenium.Cookie;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V108.IndexedDB;
using Keys = OpenQA.Selenium.Keys;
namespace SoliqApp
{
    public class Automatic : Overloads
    {
        public List<Check> checks;
        private InfoAboutMethod info;
        public List<DBpsic.DBCheck> psics;

        public Automatic(List<Check> _checks, InfoAboutMethod _info)
        {
            checks = _checks;
            info = _info;
        }
        public Automatic(List<DBpsic.DBCheck> _psics)
        {
            psics = _psics;
        }
        
        
        public PsicCategory[] TasnifChangePSIC(PsicCategory[] psics)
        {
            driver = new ChromeDriver(); //открываем Хром
            driver.Manage().Window.Maximize(); //открыть в полном окне
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(20);
            driver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(10);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            driver.Navigate().GoToUrl("https://tasnif.soliq.uz");
            driver.Manage().Cookies.AddCookie(new Cookie("route", "e1d411c9323dc6d99ec5a609ea7ed6d2"));
            driver.Manage().Cookies.AddCookie(new Cookie("ADRUM_BTa", "R:31|g:1b550b98-bcb2-43e4-b3d4-945997782628|n:customer1_9c28b63e-99cb-4969-b91e-d0d7809dc215"));
            driver.Manage().Cookies.AddCookie(new Cookie("SameSite", "None"));
            driver.Manage().Cookies.AddCookie(new Cookie("route", "086c58384ea403180bada0e20efc3336"));
            
            //выбираем русский язык для простоты понимания
            Click(_switchSaliqLanguage, 0);
            Click(_languageRu, 2);
            Click(_buttonEnter, 0);
            Click(_buttonEnter, 0);
            Click(_buttonEnter, 1);
            
            //ждем, пока не введен пароль
            while (driver.FindElements(By.XPath("//div[@class='ant-col ant-col-7 Header_avatarPart__1jsPv']")).Count == 0) { }

            try
            {
                Click(_flagFindByPsic);//кликаем на флажок "поиск по ИКПУ"
                for (int i = 0; i < psics.Length; i++)
                {
                    if (psics[i].status==0)
                    {
                        SendKeys(_fieldFindPsic,psics[i].psic_code);//вводим в поле поиска psic_code
                        
                        //если появилось сообщение об изменении псика добавить new_psic в поле и поставить статус "изменен"
                        if (driver.FindElements(_messageAboutNeedChange).Count>0)
                        {
                            psics[i].new_psic = driver.FindElement(_newPsic).Text;
                            psics[i].status = 2;
                        }

                        //если появилось успешное сообщение ставим статус "успешно" и достаем текст
                        if (driver.FindElements(_messageAboutTryePSIC).Count>0)
                        {
                            psics[i].psic_text = driver.FindElement(_productName).Text;
                            psics[i].status = 1;
                        }
                        //по окончанию цикла(прохода по ИКПУ), обновляем страницу и жмем флажок "поиск по ИКПУ"
                        driver.Navigate().GoToUrl("https://tasnif.soliq.uz");
                        Click(_flagFindByPsic);
                    }
                    
                }
                MessageBox.Show("Все чеки пройдены");//выводим сообщение, что все чеки успешно пройдены
            }
            catch (Exception e)
            {
                
                MessageBox.Show($"Ошибка \n{e}");//выводим ошибку
            }
            return psics;
        }
        
        public void TasnifChangePSIC()
        {
            driver = new ChromeDriver(); //открываем Хром
            driver.Manage().Window.Maximize(); //открыть в полном окне
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(20);
            driver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(10);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            driver.Navigate().GoToUrl("https://tasnif.soliq.uz");
            driver.Manage().Cookies.AddCookie(new Cookie("route", "e1d411c9323dc6d99ec5a609ea7ed6d2"));
            driver.Manage().Cookies.AddCookie(new Cookie("ADRUM_BTa", "R:31|g:1b550b98-bcb2-43e4-b3d4-945997782628|n:customer1_9c28b63e-99cb-4969-b91e-d0d7809dc215"));
            driver.Manage().Cookies.AddCookie(new Cookie("SameSite", "None"));
            driver.Manage().Cookies.AddCookie(new Cookie("route", "086c58384ea403180bada0e20efc3336"));
            
            //выбираем русский язык для простоты понимания
            Click(_switchSaliqLanguage, 0);
            Click(_languageRu, 2);
            Click(_buttonEnter, 0);
            Click(_buttonEnter, 0);
            Click(_buttonEnter, 1);
            
            //ждем, пока не введен пароль
            while (driver.FindElements(By.XPath("//div[@class='ant-col ant-col-7 Header_avatarPart__1jsPv']")).Count == 0) { }

            try
            {
                Click(_flagFindByPsic);//кликаем на флажок "поиск по ИКПУ"
                for (int i = 0; i < psics.Count; i++)
                {
                    if (psics[i].status==0)
                    {
                        SendKeys(_fieldFindPsic,psics[i].psic_code);//вводим в поле поиска psic_code
                        
                        //если появилось сообщение об изменении псика добавить new_psic в поле и поставить статус "изменен"
                        if (driver.FindElements(_messageAboutNeedChange).Count>0)
                        {
                            psics[i].new_psic = driver.FindElement(_newPsic).Text;
                            psics[i].status = 2;
                        }

                        //если появилось успешное сообщение ставим статус "успешно" и достаем текст
                        if (driver.FindElements(_messageAboutTryePSIC).Count>0)
                        {
                            psics[i].psic_text = driver.FindElement(_productName).Text;
                            psics[i].status = 1;
                        }
                        //по окончанию цикла(прохода по ИКПУ), обновляем страницу и жмем флажок "поиск по ИКПУ"
                        driver.Navigate().GoToUrl("https://tasnif.soliq.uz");
                        Click(_flagFindByPsic);
                    }
                    
                }
                MessageBox.Show("Все чеки пройдены");//выводим сообщение, что все чеки успешно пройдены
            }
            catch (Exception e)
            {
                MessageBox.Show($"Ошибка \n{e}");//выводим ошибку
            }
        }
        

        public PsicCategory[] Tasnif(PsicCategory[] psics)
        {
            driver = new ChromeDriver(); //открываем Хром
            driver.Manage().Window.Maximize(); //открыть в полном окне
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(20);
            driver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(10);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            driver.Navigate().GoToUrl("https://tasnif.soliq.uz");
            Click(_switchSaliqLanguage, 0);//жмем кнопку языка
            Click(_languageRu, 2);//выбираем русский
            Click(_buttonEnter, 0);
            Click(_buttonEnter, 0);
            Click(_buttonEnter, 1);
            while (driver.FindElements(By.XPath("//div[@class='ant-col ant-col-7 Header_avatarPart__1jsPv']")).Count == 0) { }

            Click(_labelEkpu);
            driver.Navigate().GoToUrl($"https://tasnif.soliq.uz/attribute/{psics[0]}");

            try
            {
                for (int i = 0; i < psics.Length; i++)
                {
                    if (psics[i].status==0)
                    {
                        driver.Navigate().GoToUrl($"https://tasnif.soliq.uz/attribute/{psics[i].psic_code}");
                        if (driver.FindElements(_buttonSaveCategory).Count != 0)
                        {
                            for (int j = 0; j < driver.FindElements(_buttonCategoryCountPage).Count; j++)//проходим по страницам категорий
                            {
                                for (int k = 0; k < driver.FindElements(_buttonSaveCategory).Count; k++)//проходим по кнопкам сохранить категории
                                {
                                    Click(_buttonSaveCategory, 0);
                                }

                                if (driver.FindElements(_buttonCategoryCountPage).Count>j+1)//если количество кнопок больше нуля
                                {
                                    Click(_buttonCategoryCountPage,j+1);//жмем на кнопку следующей страницы
                                }
                            }
                            psics[i].status=1;//по окончанию меняем статус
                        }
                        else
                        {
                            psics[i].status=0;
                        }
                    }
                }
                MessageBox.Show("Все чеки пройдены");//собщение о том, что чеки пройдены
            }
            catch (Exception e)
            {
                MessageBox.Show($"Ошибка {e}");//если пройзошла ошибка, выводим сообщение
            }
            return psics;
        }
        [Test]
        public void MySoligUniversal()
        {
            driver = new ChromeDriver(); //открываем Хром
            driver.Manage().Window.Maximize(); //открыть в полном окне
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(20);
            driver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(10);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            driver.Navigate().GoToUrl("https://my.soliq.uz/main/");
            Click(_buttonLanguageRu); //меняем язык
            Click(_buttonEnterCabinet);
            Click(_buttonsEsiOrUsb, 0);
            Click(_buttonsSignIn, 0);
            Thread.Sleep(2000); //ожидание на случай капчи
            while (driver.FindElements(By.XPath("//li[@class='type-18 ff-rCondensedBold']")).Count <= 0) {} //ожидаем, пока кнопка "войти" не исчезнет

            driver.Navigate().GoToUrl("https://my.soliq.uz/cashregister/check/edit/marketplays");
            try
            {
                
                for (int i = 0; i < checks.Count; i++)
                {
                    double totalPrice = 0f;
                    if (CheckStatus(checks[i].status,info._statusCheck))//проверка статус чека
                    {
                        Clear(_fieldcheckNumber); //очищаем поле номера чека
                        SendKeys(_fieldcheckNumber, checks[i].id); //вводим номер чека
                        Click(_buttonFindCheck); //жмем кнопку поиска чека
                        //проверка на случай зависания поиска чека
                        if (driver.FindElements(By.XPath("//div[@class='row no-gutters text-center']")).Count==0)
                        {
                            Click(_buttonFindCheck); //жмем кнопку поиска чека
                        }
                        if (driver.FindElements(By.XPath("//div[@class='toast toast-error']")).Count==0)
                        {
                            while (driver.FindElements(By.XPath("//div[@id='check-edit'][1]//input[@name='vat']")).Count==0) {} //ждем, пока кнопка с заливкой ПДФ не прогрузится

                            
                            int checkCount = driver.FindElements(_rowProducts).Count; //определяем количество товаров в чеке

                            for (int j = 0; j < checkCount; j++) //прохоим по всем товарам в чеке
                            {
                                Scroll(SelectForString(_row,j,_buttonPsicText));
                                string psic = "";
                                Clear(SelectForString(_row,j,_fieldVatText));
                                
                                SendKeys(SelectForString(_row,j,_fieldVatText), checks[i].product[j].vat);
                                psic = $"psic_code({checks[i].product[j].psic}) not found";//готовим статус, если ИКПУ не найден
                                driver.FindElement(SelectForString(_row,j,_buttonPsicText)).Click(); //открываем список ИКПУ
                               
                                Thread.Sleep(1000);
                                
                                Click(_labelSelectIkpu);
                                Thread.Sleep(1000);
                                driver.FindElement(SelectForString(_row,j,_buttonPsicText)).Click();//открываем список ИКПУ второй раз
                                SendKeys(_fieldIkpu, checks[i].product[j].psic);//заполняем поле ИКПУ
                                Thread.Sleep(200);
                                
                                if (info._auto)//если чек на автозамену ИКПУ включен, то начинаем исправлять
                                {
                                    if (driver.FindElements(_messageOfError).Count != 0)//проверяем на наличие ошибки ИКПУ
                                    {
                                        int coutChange = 4;//число попыток удалить крайнее значение
                                        while (coutChange!=0)//цикл крутится, пока не попыток не останется 0
                                        {
                                            SendKeys(_fieldIkpu,Keys.Backspace);//заполняем поле ИКПУ ,без одного символа
                                            if (driver.FindElements(_messageOfError).Count == 0)//если ошибки нет, и ПСИК прошел
                                            { 
                                                checks[i].product[j].psic = driver.FindElement(_fieldIkpu).GetAttribute("value");//если все-таки удаление чисел помогло - заменяем ИКПУ в джейсоне
                                                break;//выходим из цикла
                                            }
                                            coutChange--;//отнимаем попытку при рохождении цикла
                                        }
                                        if (driver.FindElements(_messageOfError).Count != 0)//если и после этого псика нет
                                        {
                                            checks[i].product[j].psic = checks[i - 1].product[0].psic;//заменяем псик ну псик из предыдущего чека
                                            Clear(_fieldIkpu);//чистим поле ИКПУ
                                            SendKeys(_fieldIkpu, checks[i].product[j].psic);//вбиваем старый, уже новый ИКПУ
                                        }
                                    }
                                }
                                
                                if (driver.FindElements(_messageOfError).Count == 0) //если нет поля "ИКПУ не найден"
                                {
                                    Click(_labelSelectIkpu); //жмем на лейбл ЕКПУ
                                    driver.FindElements(SelectForString(_row,j,_buttonUnitText))[0].Click();
                                    if (driver.FindElements(By.XPath($"{_row}[{j+1}]//ul[@class='dropdown-menu inner ']//a[@role='option']")).Count > 5) //Если нет лейбла об отсутсвия ед. измерения
                                    {
                                        
                                        driver.FindElements(SelectForString(_row,j,_labelUnitText))[1].Click(); //жмем на второе поле едюизмерени
                                        Click(SelectForString(_row,j,_buttonInnText));
                                        //Click(_buttonInn,1); //открываем вкладку с ИНН
                                        driver.FindElements(SelectForString(_row,j,_fieldINNtext))[1].SendKeys(checks[i].TIN); //вводим ИНН
                                        if (driver.FindElements(By.XPath($"{_row}[{j+1}]{_labelINN}")).Count != 0) //если нет сообщения об отсутствия поля ИНН
                                        {
                                            driver.FindElements(By.XPath($"//span[text()='{checks[i].TIN}']"))[j].Click(); //жмем на лейбл ИНН
                                            totalPrice += double.Parse(driver.FindElement(By.XPath("//input[@name='price']")).GetAttribute("value").Replace('.',','));
                                            if (checkCount - j == 1) //если мы заполнили последний товар в чеке
                                            {
                                               
                                                AttachFile(_loadPdf, info._adressPDF); //заливаем ПДФ-файл
                                                Scroll(_buttonSend);
                                                Thread.Sleep(200);
                                                
                                                Click(_buttonSend); //жмем кнопку отправить обновленные данные
                                                int countWhile = 0;
                                                bool success = true;
                                                while (driver.FindElements(By.Id("toast-container")).Count == 0)
                                                {
                                                    
                                                    Thread.Sleep(200);
                                                    countWhile++;
                                                    if (driver.FindElements(By.XPath("//div[@id='check-edit'][1]//input[@name='vat']")).Count!=0)
                                                    {
                                                        success = false;
                                                        break;
                                                    }
                                                    
                                                } //ждем, пока не появится сообщение о успешном сохранении
                                                if (success)
                                                {
                                                    checks[i].status = "Success"; //меняем статус чека в json
                                                }
                                            }
                                        }
                                        else
                                        {
                                            checks[i].status = "bug TIN field"; //назначаем статус ошибки поля ИНН
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        checks[i].status = $"not unit field{j + 1}"; //назначаем статус ошибки ед.значения
                                        break;
                                    }
                                }
                                else
                                {
                                    checks[i].status = psic; //статус ошибки ИКПУ не найден
                                    break;
                                }
                            }
                        }
                        else
                        {
                            checks[i].status = "Cancel";//меняем статус на "отмененный"
                        }
                    }
                    Clear(_fieldcheckNumber); //очищаем поле "номер чека"
                }
            }
            catch (Exception e) //при ошибке или сбое
            {
                Console.WriteLine(e);
                driver.Quit();
                //throw;
            }
            driver.Quit();
            MessageBox.Show("Все чеки пройдены");
            //SaveJson(checks, jsonName); //сохраняем json
        }

        public bool CheckStatus(string status,int indexStatus)//проверяем, проходит ли чек
        {
            bool flag=false;
            switch (indexStatus)
            {
                case 0:
                    if (status=="")//все, кто не прошел проверку, проходят
                    {
                        flag = true;
                    }
                    break;
                case 1:
                    if (status.Contains("Success"))//прогоняем успешные чеки
                    {
                        flag = true;
                    }
                    break;
                case 2:
                    if (status.Contains("psic_code"))//с ошибкой ИКПУ
                    {
                        flag = true;
                    }
                    break;
                case 3:
                    if (!status.Contains("Success"))//все, кроме успешно пройденных
                    {
                        flag = true;
                    }
                    break;
                case 4:
                    flag = true;//все чеки без исключения
                    break;
            }
            return flag;
        }

        public string AutoChangePsic(string psic)
        {
            psic.Remove(psic.Length-1);
            return psic;
        }
        public class Check
        {
            public string id { get; set; }
            public string TIN { get; set; }
            public string status = "";
            public Product[] product;

            public class Product
            {
                public string vat { get; set; }
                public string psic { get; set; }
                public string price { get; set; }
                public string old_vat {get;set;}
                public string old_price { get; set; }
            }
            
        }

        public class PsicInfo//класс, который мы вытаскиваем из ответа о псике
        {
            public Data data { get; set; }
            public class Data
            {
                public Content[] content { get; set; }
                public class Content
                {
                    public string brandName  {get;set;}//имя бренда, например, Apple
                    public string mxikName { get; set;}//категория и название продукта
                    public string attributeName { get; set; }//название продукта
                }
            }
        }

        public class PsicCategory
        {
            public string psic_code { get; set; }//получаем ИКПУ из json
            public string new_psic { get; set; }//вставляем новый ИКПУ с tasnif
            
            public string psic_text { get; set; }//название товара
            public  int status { get; set; }//0 - не пройден, 1 - пройден, 2 - изменен
        }

        public class InfoAboutMethod//класс, передающий информацию об имени файлов, включенных чекбоксах
        {
            public int _statusCheck;//передаем информацию о чекбоксах статусов
            public bool _auto;//статус включенной функции автозамены псика
            public string _adressPDF;//передаем адрес пдф-файла

            public InfoAboutMethod(int statusCheck, bool auto, string adressPdf)
            {
                _statusCheck = statusCheck;
                _auto = auto;
                _adressPDF = adressPdf;
            }
        }
    }
}