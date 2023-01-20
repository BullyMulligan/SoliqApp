
using OpenQA.Selenium;
namespace SoliqApp
{
    public class General
    {
        public IWebDriver driver;
        //MySoliq Page
        protected readonly By _buttonLanguageRu = By.XPath("//a[@class='rus ']");
        protected readonly By _buttonEnterCabinet = By.XPath("//a[@class='show_auth_modal_legal_entity_button']");
        protected readonly By _buttonsEsiOrUsb = By.XPath("//a[@class='thumbnail text-center dl-link']");
        protected readonly By _buttonsSignIn = By.XPath("//a[@class='btn btn-default sign-in']");
        protected readonly By _fieldcheckNumber = By.Id("checkNumber");
        protected readonly By _buttonFindCheck = By.Id("findButton");
        protected readonly By _fieldVat = By.XPath("//input[@name='vat']");
        protected readonly string _fieldVatText = "//input[@name='vat']";
        protected readonly By _arrowIkpu = By.XPath("//span[@class='select2-selection__arrow']");
        protected readonly By _fieldIkpu = By.XPath("//input[@class='select2-search__field']");
        protected readonly By _labelSelectIkpu = By.XPath("//li[@role='option']");
        
        
        protected readonly By _buttonUnit = By.XPath("//button[@data-toggle='dropdown']");
        protected readonly string _buttonUnitText = "//button[@data-toggle='dropdown']";
        protected readonly By _buttonInn = By.XPath("//button[@class='btn dropdown-toggle bs-placeholder btn-default']");//
        protected readonly string _buttonInnText = "//button[@class='btn dropdown-toggle bs-placeholder btn-default']";
        protected readonly string _labelUnitText = "//span[@class='text']";
        protected readonly By _labelUnit = By.XPath("//span[@class='text']");
        protected readonly By _loadPdf = By.Id("zipFile");
        protected readonly By _buttonCalculate = By.Id("btnCalc");
        protected readonly By _fieldInn = By.XPath("//input[@type='text']");
        protected readonly By _buttonSend = By.Id("btnSend");
        protected readonly By _fieldVatTotal=By.XPath("//input[@name='sumVatTotal']");
        protected readonly By _buttonsSelect = By.XPath("//button[@title='Выберите']");
        protected readonly By _fieldTotalPrice = By.XPath("//input[@name='cardTotal']");
        protected readonly By _rowProducts = By.XPath("//div[@class='row no-gutters text-center']");//продукт
        protected readonly By _buttonPsic = By.XPath("//span[@role='textbox']");
        protected readonly By _messageOfError = By.XPath("//li[@role='alert']");
        protected readonly string _row = "//div[@class='row no-gutters text-center']";
        protected readonly string _fieldINNtext = "//input[@role='textbox']";
        protected readonly string _labelINN = "//a[@style='overflow-wrap: break-word;']//span[@class='text']";

        protected readonly string _buttonPsicText = "//span[@role='textbox']";
        //Tasnif Page
        protected readonly By _buttonCategoryCountPage = By.XPath("//ul[@class='ant-pagination ant-pagination']//a[@rel='nofollow']");
        protected readonly By _switchSaliqLanguage =By.XPath("//span[@class='ant-dropdown-trigger Dropdown_linkStyle__2Ty3i']");
        protected readonly By _languageRu = By.XPath("//span[@class='ant-dropdown-menu-title-content']");
        protected readonly By _buttonEnter =By.XPath("//button[@type='button']");
        protected readonly By _labelEkpu = By.XPath("//a[@href='/activities']");
        protected readonly By _buttonSaveCategory = By.XPath("//span[text()='Сохранить категорию']");
        protected readonly By _flagFindByPsic = By.XPath("//input[@value='2']");//флаг "ищем по ИКПУ"
        protected readonly By _fieldFindPsic = By.XPath("//input[@class='ant-input ant-select-selection-search-input']");//поле ввода ИКПУ
        protected readonly By _messageAboutNeedChange = By.XPath("//div[@class='Search_infoText__3qrjB']");//сообщение о том, что нужно сменить икпу
        protected readonly By _newPsic = By.XPath("//div[@class='Search_infoText__3qrjB']/p/b");//номер ИКПУ на который нужно заменить текущий ИКПУ
        protected readonly By _messageAboutTryePSIC = By.XPath("//div[@class='rc-virtual-list-holder-inner']");//сообщение о том, что ИКПУ найден
        protected readonly By _productName = By.XPath("//div[@class='search-card_title_section__3qVun']/p");//название товара, найденное по псику
    }
}