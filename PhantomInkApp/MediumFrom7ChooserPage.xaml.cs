namespace PhantomInkApp;

public partial class MediumFrom7ChooserPage : ContentPage
{
	public MediumFrom7ChooserPage(bool mediumOrSpiritChoose, List<MediumCard> mediumChoosenCards = null)
	{
		InitializeComponent();
        this.mediumOrSpiritChoose = mediumOrSpiritChoose;
        if (mediumOrSpiritChoose)
        {
            if (MediumCardLibrary.Instance.SunOrMoonCommand)
                cardsInView = MediumCardLibrary.Instance.SunHand;
            else
                cardsInView = MediumCardLibrary.Instance.MoonHand;
            maxCards = 7;
            CheckBox_ForSpirit.IsVisible = true;
            Button_Continue.Text = "Выбрать 2 карты для духа, передать ему";
        }
        else
        {
            cardsInView.AddRange(mediumChoosenCards);
            maxCards = 2;
            CheckBox_ForSpirit.IsVisible = false;
            Button_Continue.Text = "Одна карта выбрана, медиумы увидели (покажите им)";
            Button_Continue.IsEnabled = true;
        }
        SwitchCard(0);
        UpdateCardNum();

    }
    public string CardsInViewCount
    {
        get
        {
            return (maxCards).ToString();
        }
    }
    public string CurrentCardNum { get
        {
            return (cardId + 1).ToString();
        } 
    }
    public void SwitchCard(int cardId)
    {
        var card = cardsInView[cardId];
        Label_Text.Text = card.Question;
        Label_Title0.Text = card.Title;
        Label_Title1.Text = card.Title;
        this.cardId = cardId;

        if (choosenCardsIds.Count >= 2 && !choosenCardsIds.Contains(cardId))
            CheckBox_ForSpirit.IsEnabled = false;
        else
            CheckBox_ForSpirit.IsEnabled = true;

        if (choosenCardsIds.Contains(cardId)) 
        {
            CheckBox_ForSpirit.IsChecked = true;
        }
        else
        {
            CheckBox_ForSpirit.IsChecked = false;
        }
    }
    private bool mediumOrSpiritChoose;
    private int cardId = 0;
    private int maxCards;
    private List<int> choosenCardsIds = new List<int>();
    private List<MediumCard> cardsInView = new List<MediumCard>();

    private void CheckBox_ForSpirit_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        if (CheckBox_ForSpirit.IsEnabled == false)
            return;

        if (e.Value == true)
        {
            if (!choosenCardsIds.Contains(cardId))
                choosenCardsIds.Add(cardId);
        }
        if (e.Value == false)
        {
            if (choosenCardsIds.Contains(cardId))
                choosenCardsIds.Remove(cardId);
        }

        if (choosenCardsIds.Count == 2)
            Button_Continue.IsEnabled = true;
        else
            Button_Continue.IsEnabled = false;
    }

    private void Button_Prev_Clicked(object sender, EventArgs e)
    {
        cardId = cardId - 1 >= 0 ? cardId - 1 : maxCards - 1;
        SwitchCard(cardId);
        UpdateCardNum();
    }

    private void UpdateCardNum()
    {
        Label_CardNum.Text = CurrentCardNum;
        Label_CardCount.Text = CardsInViewCount;
    }

    private void Button_Next_Clicked(object sender, EventArgs e)
    {
        cardId = cardId + 1 < maxCards ? cardId + 1 : 0;
        SwitchCard(cardId);
        UpdateCardNum();
    }

    private void Button_Continue_Clicked(object sender, EventArgs e)
    {
        if (mediumOrSpiritChoose)
        {
            var cardsToGo = new List<MediumCard>();
            for (int i = 0; i < maxCards; i++)
            {
                if (choosenCardsIds.Contains(i))
                    cardsToGo.Add(cardsInView[i]);
            }
            Navigation.PushModalAsync(new MediumFrom7ChooserPage(false, cardsToGo));
        }
        else
        {
            MediumCardLibrary.Instance.RemoveCardFromHand(cardsInView[0], MediumCardLibrary.Instance.SunOrMoonCommand);
            MediumCardLibrary.Instance.RemoveCardFromHand(cardsInView[1], MediumCardLibrary.Instance.SunOrMoonCommand);
            MediumCardLibrary.Instance.AddNewCardToHand(MediumCardLibrary.Instance.SunOrMoonCommand);
            MediumCardLibrary.Instance.AddNewCardToHand(MediumCardLibrary.Instance.SunOrMoonCommand);
            Navigation.PushModalAsync(new MediumFrom7ChooserPage(true));
        }
    }
}